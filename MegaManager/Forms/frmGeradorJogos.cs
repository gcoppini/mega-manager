using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using MegaManager.Domain.Main;
using MegaManager.Infra.Data;
using MegaManager.Infra.CrossCutting;

namespace MegaManager
{
    public partial class frmGeradorJogos : Form
    {

        private static readonly Random getrandom = new Random();
        private static readonly object syncLock = new object();

        private int LOG_MAX_LINES = 10000;

        public static int RAND_MIN { get; set; }
        public static int RAND_MAX { get; set; }

        
        List<int> listaNumerosResultados = new List<int>();

        List<Gabarito> listaGabaritos = new List<Gabarito>();
        
        List<Resultado> jogosGerados = new List<Resultado>();

        List<Resultado> listaJogosSorteados = new List<Resultado>();
        
        Thread m_UIThread;
                  


        public frmGeradorJogos()
        {
            InitializeComponent();

            m_UIThread = Thread.CurrentThread;

            RAND_MIN = 1;
            RAND_MAX = 3;

            trackBarDesvioMedia.Minimum = 0;
            trackBarDesvioMedia.Maximum = 200;
            trackBarDesvioMedia.Value = 10;

            bgWorkerGerarNumeros.WorkerSupportsCancellation = true;
            bgWorkerGerarNumeros.WorkerReportsProgress = true;

            CarregaListaJogosSorteados();
            CarregaListaNumeros();
            CarrregaGabaritos();

            BindListBoxGabaritos();

        }
              
        
        private void BindListBoxGabaritos()
        {
            try
            {
                DataTable dt = Helpers.ToDataTable<Gabarito>(listaGabaritos);

                BindingSource bs = new BindingSource();
                bs.DataSource = dt;

                checkedListBoxGabaritos.DataSource = bs;
                checkedListBoxGabaritos.DisplayMember = "Numero";
                checkedListBoxGabaritos.ValueMember = "Numero";

                checkedListBoxGabaritos.DataSource = dt;
            }
            catch (Exception ex) { }
        }
        
        private void CarregaListaNumeros()
        {
            listaNumerosResultados.AddRange(listaJogosSorteados.Select(x => int.Parse(x.Dezena1)));
            listaNumerosResultados.AddRange(listaJogosSorteados.Select(x => int.Parse(x.Dezena2)));
            listaNumerosResultados.AddRange(listaJogosSorteados.Select(x => int.Parse(x.Dezena3)));
            listaNumerosResultados.AddRange(listaJogosSorteados.Select(x => int.Parse(x.Dezena4)));
            listaNumerosResultados.AddRange(listaJogosSorteados.Select(x => int.Parse(x.Dezena5)));
            listaNumerosResultados.AddRange(listaJogosSorteados.Select(x => int.Parse(x.Dezena6)));
           

            var noticesGrouped = listaNumerosResultados.GroupBy(n => n).
                    Select(group =>
                        new
                        {
                            Numero = group.Key,
                            Numeros = group.ToList(),
                            Count = group.Count(),
                            Data = (listaJogosSorteados.Where(x => int.Parse(x.Dezena1) == group.Key ||
                                                     int.Parse(x.Dezena2) == group.Key ||
                                                     int.Parse(x.Dezena3) == group.Key ||
                                                     int.Parse(x.Dezena4) == group.Key ||
                                                     int.Parse(x.Dezena5) == group.Key ||
                                                     int.Parse(x.Dezena6) == group.Key).Max(z => DateTime.Parse(z.DataSorteio))),
                            DataDif = Math.Round((DateTime.Now - (listaJogosSorteados.Where(x => int.Parse(x.Dezena1) == group.Key ||
                                                     int.Parse(x.Dezena2) == group.Key ||
                                                     int.Parse(x.Dezena3) == group.Key ||
                                                     int.Parse(x.Dezena4) == group.Key ||
                                                     int.Parse(x.Dezena5) == group.Key ||
                                                     int.Parse(x.Dezena6) == group.Key).Max(z => DateTime.Parse(z.DataSorteio)))).TotalDays)


                        }).OrderByDescending(z => z.Count);

        }

        private void CarregaListaJogosSorteados()
        {
            using (ResultadoRepository dal = new ResultadoRepository())
            {
                listaJogosSorteados = dal.GetAll();
            }
        }

        private void CarrregaGabaritos()
        {
            using (GabaritoRepository dal = new GabaritoRepository())
            {
                listaGabaritos = dal.GetAll();
            }
        }
        
        private void GerarNumeros()
        {

            ClearGridJogosGerados();
            

            var mostCommon = listaNumerosResultados.GroupBy(x => x)
               .OrderByDescending(g => g.Count())
               .Select(g => g.Key);


            var jogoMaisComum = listaNumerosResultados.GroupBy(x => x)
               .OrderByDescending(g => g.Count())
               .Select(g => g.Key).Take(6);
            


            int qtd = int.Parse(txtQtdJogos.Text);
            string gabNum = ((DataRowView)checkedListBoxGabaritos.CheckedItems[0])["Numero"].ToString();

            Gabarito ga = listaGabaritos.Where(x => x.Numero == int.Parse(gabNum)).First();

            int i = 0;
            int media = int.Parse(txtMediaSoma.Text);
            while (i != qtd)
            {
                Application.DoEvents();

                AddToLog(string.Format("Tentando Gerar jogo número: {0}", i + 1));
                Resultado res = GerarNumeros(ga);


                int start = media - GetDesvioMedia();
                int qty = ((media + GetDesvioMedia()) - start) + 1;

                IEnumerable<int> rangeMediaSomaDosResultados = Enumerable.Range(start, qty);

                //O  jogo gerado: já não foi gerado, está dentro da média e não foi sorteado ainda
                var jaFoiGerado = jogosGerados.Where(x => x.Dezena1 == res.Dezena1 &&
                                                    x.Dezena2 == res.Dezena2 &&
                                                    x.Dezena3 == res.Dezena3 &&
                                                    x.Dezena4 == res.Dezena4 &&
                                                    x.Dezena5 == res.Dezena5 &&
                                                    x.Dezena6 == res.Dezena6).Count() > 0;

                var estaDentroDaMedia = rangeMediaSomaDosResultados.Contains(res.Soma);
                
                var jogoJaFoisorteado = JogoJaFoiSorteado(res);

                
                if (!jaFoiGerado && estaDentroDaMedia && !jogoJaFoisorteado)
                {
                    jogosGerados.Add(res);
                    i++;
                    AddToLog(string.Format("Sucesso!!! jogo número: {0} gerado", i));
                    
                }
                else 
                {
                    AddToLog(string.Format("Falha! Não atende ao critério: Já gerado: {0} | Media: {1} | Já sorteado: {2}", jaFoiGerado, estaDentroDaMedia, jogoJaFoisorteado));

                    if (!estaDentroDaMedia)
                    {
                        UpdateDesvioMedia();
                    }

                }
            }

            jogosGerados.Sort((x, y) => x.Dezena1.CompareTo(y.Dezena1));

            
            
            /*
             int randomSkip;
             int randomTake;

                randomSkip = GenerateSomeAppropriateRandomNumber();
                randomTake = GenerateSomeAppropriateRandomNumber();

                resultSet = iEnumerable.Skip(randomSkip).Take(randomTake);
             */

        }



        public int GetDesvioMedia()
        {
            if (trackBarDesvioMedia.InvokeRequired)
            {
                return (int)trackBarDesvioMedia.Invoke(
                  new Func<int>(() => GetDesvioMedia())
                );
            }
            else
            {
                int varText = trackBarDesvioMedia.Value;
                return varText;
            }
        }


        private void UpdateDesvioMedia()
        {
            if (Thread.CurrentThread != m_UIThread)
            {
                // Need for invoke if called from a different thread
                this.BeginInvoke((ThreadStart)delegate()
                {
                    UpdateDesvioMedia();
                });
            }
            else
            {
                trackBarDesvioMedia.Value = trackBarDesvioMedia.Value + 5;
            }
        }

        private void BindGridJogosGerados()
        {
            if (Thread.CurrentThread != m_UIThread)
            {
                // Need for invoke if called from a different thread
                this.BeginInvoke((ThreadStart)delegate()
                    {
                        BindGridJogosGerados();
                    });
            }
            else
            {
                dataGridView1.DataSource = jogosGerados;
                dataGridView1.Refresh();
                Application.DoEvents();
            }
        }

        private void ClearGridJogosGerados() {
            
            if (Thread.CurrentThread != m_UIThread)
            {
                // Need for invoke if called from a different thread
                this.BeginInvoke((ThreadStart)delegate()
                    {
                        ClearGridJogosGerados();
                    });
            }
            else
            {
                jogosGerados.Clear();
                dataGridView1.DataSource = null;
                Application.DoEvents();
            }
        
        }

        public static int GetRandomNumber(int min, int max)
        {
            lock (syncLock)
            { 
                return getrandom.Next(min, max);
            }
        }

        
        private Resultado GerarNumeros2(Gabarito gabarito)
        {
            List<int> lista = new List<int>();

            // 1 - 9
            var dezenas1 = listaNumerosResultados.GroupBy(x => x)
               .OrderByDescending(g => g.Count())
               .Select(g => g.Key)
               .Where(x => x < 10)
               .Take(gabarito.Quantidade1);

            // 10 - 19
            var dezenas2 = listaNumerosResultados.GroupBy(x => x)
               .OrderByDescending(g => g.Count())
               .Select(g => g.Key)
               .Where(x => x > 9 && x < 20)
               .Take(gabarito.Quantidade2);

            // 20 - 29
            var dezenas3 = listaNumerosResultados.GroupBy(x => x)
               .OrderByDescending(g => g.Count())
               .Select(g => g.Key)
               .Where(x => x > 19 && x < 30)
               .Take(gabarito.Quantidade3);
            
            // 30 - 39
            var dezenas4 = listaNumerosResultados.GroupBy(x => x)
               .OrderByDescending(g => g.Count())
               .Select(g => g.Key)
               .Where(x => x > 29 && x < 40)
               .Take(gabarito.Quantidade4);

            // 40 - 49
            var dezenas5 = listaNumerosResultados.GroupBy(x => x)
               .OrderByDescending(g => g.Count())
               .Select(g => g.Key)
               .Where(x => x > 39 && x < 50)
               .Take(gabarito.Quantidade5);

            // 50 - 59
            var dezenas6 = listaNumerosResultados.GroupBy(x => x)
               .OrderByDescending(g => g.Count())
               .Select(g => g.Key)
               .Where(x => x > 49 && x < 60)
               .Take(gabarito.Quantidade6);

            // 60 - 69
            var dezenas7 = listaNumerosResultados.GroupBy(x => x)
              .OrderByDescending(g => g.Count())
              .Select(g => g.Key)
              .Where(x => x > 59 && x < 70)
              .Take(gabarito.Quantidade7);


            lista.AddRange(dezenas1.Select(x => x));
            lista.AddRange(dezenas2.Select(x => x));
            lista.AddRange(dezenas3.Select(x => x));
            lista.AddRange(dezenas4.Select(x => x));
            lista.AddRange(dezenas5.Select(x => x));
            lista.AddRange(dezenas6.Select(x => x));
            lista.AddRange(dezenas7.Select(x => x));


            Resultado res = new Resultado();
            res.Dezena1 = lista[0].ToString();
            res.Dezena2 = lista[1].ToString();
            res.Dezena3 = lista[2].ToString();
            res.Dezena4 = lista[3].ToString();
            res.Dezena5 = lista[4].ToString();
            res.Dezena6 = lista[5].ToString();


            return res;


        }
                
        private Resultado GerarNumeros(Gabarito gabarito)
        {
            List<int> lista = new List<int>();
            
            IEnumerable<int> dezenas1 = null;
            IEnumerable<int> dezenas2 = null;
            IEnumerable<int> dezenas3 = null;
            IEnumerable<int> dezenas4 = null;
            IEnumerable<int> dezenas5 = null;
            IEnumerable<int> dezenas6 = null;
            IEnumerable<int> dezenas7 = null;

            GerarDezena1(gabarito, ref dezenas1);
            GerarDezena2(gabarito, ref dezenas2);
            GerarDezena3(gabarito, ref dezenas3);
            GerarDezena4(gabarito, ref dezenas4);
            GerarDezena5(gabarito, ref dezenas5);
            GerarDezena6(gabarito, ref dezenas6);
            GerarDezena7(gabarito, ref dezenas7);


            lista.AddRange(dezenas1.Select(x => x));
            lista.AddRange(dezenas2.Select(x => x));
            lista.AddRange(dezenas3.Select(x => x));
            lista.AddRange(dezenas4.Select(x => x));
            lista.AddRange(dezenas5.Select(x => x));
            lista.AddRange(dezenas6.Select(x => x));
            lista.AddRange(dezenas7.Select(x => x));
            

            //Fix this - Zebra!
            while (lista.Count < 6)
                lista.Add(GetRandomNumber(1, 60));

            lista.Sort();

            Resultado res = new Resultado();
            res.Dezena1 = lista[0].ToString();
            res.Dezena2 = lista[1].ToString();
            res.Dezena3 = lista[2].ToString();
            res.Dezena4 = lista[3].ToString();
            res.Dezena5 = lista[4].ToString();
            res.Dezena6 = lista[5].ToString();


            dezenas1 = null;
            dezenas2 = null;
            dezenas3 = null;
            dezenas4 = null;
            dezenas5 = null;
            dezenas6 = null;
            dezenas7 = null;


            return res;
        }



        private void GerarDezena7(Gabarito gabarito, ref IEnumerable<int> dezenas7)
        {
            do
            {
                dezenas7 = listaNumerosResultados.GroupBy(x => x)
                  .OrderByDescending(g => g.Count())
                  .Select(g => g.Key)
                  .Where(x => x > 59 && x < 70)
                  .Skip(GetRandomNumber(RAND_MIN, RAND_MAX))
                  .Take(gabarito.Quantidade7)
                  .ToList();

                   RAND_MAX++;
            } while (gabarito.Quantidade7 != dezenas7.Count());
        }
                
        private void GerarDezena6(Gabarito gabarito, ref IEnumerable<int> dezenas6)
        {
            do
            {
                dezenas6 = listaNumerosResultados.GroupBy(x => x)
               .OrderByDescending(g => g.Count())
               .Select(g => g.Key)
               .Where(x => x > 49 && x < 60)
               .Skip(GetRandomNumber(RAND_MIN, RAND_MAX))
               .Take(gabarito.Quantidade6)
               .ToList();
                
                RAND_MAX++;
            
            } while (gabarito.Quantidade6 != dezenas6.Count());
        }

        private void GerarDezena5(Gabarito gabarito, ref IEnumerable<int> dezenas5)
        {
            do
            {
                dezenas5 = listaNumerosResultados.GroupBy(x => x)
               .OrderByDescending(g => g.Count())
               .Select(g => g.Key)
               .Where(x => x > 39 && x < 50)
               .Skip(GetRandomNumber(RAND_MIN, RAND_MAX))
               .Take(gabarito.Quantidade5)
               .ToList();
                
                RAND_MAX++;

            } while (gabarito.Quantidade5 != dezenas5.Count());
        }

        private void GerarDezena4(Gabarito gabarito, ref IEnumerable<int> dezenas4)
        {
            do
            {
                dezenas4 = listaNumerosResultados.GroupBy(x => x)
               .OrderByDescending(g => g.Count())
               .Select(g => g.Key)
               .Where(x => x > 29 && x < 40)
               .Skip(GetRandomNumber(RAND_MIN, RAND_MAX))
               .Take(gabarito.Quantidade4)
               .ToList();

                RAND_MAX++;
            } while (gabarito.Quantidade4 != dezenas4.Count());
        }

        private void GerarDezena3(Gabarito gabarito, ref IEnumerable<int> dezenas3)
        {
            do
            {
                dezenas3 = listaNumerosResultados.GroupBy(x => x)
               .OrderByDescending(g => g.Count())
               .Select(g => g.Key)
               .Where(x => x > 19 && x < 30)
               .Skip(GetRandomNumber(RAND_MIN, RAND_MAX))
               .Take(gabarito.Quantidade3)
               .ToList();

                RAND_MAX++;

                } while (gabarito.Quantidade3 != dezenas3.Count());
        }

        private void GerarDezena2(Gabarito gabarito, ref IEnumerable<int> dezenas2)
        {
            do
            {
                dezenas2 = listaNumerosResultados.GroupBy(x => x)
               .OrderByDescending(g => g.Count())
               .Select(g => g.Key)
               .Where(x => x > 9 && x < 20)
               .Skip(GetRandomNumber(RAND_MIN, RAND_MAX))
               .Take(gabarito.Quantidade2)
                .ToList();

                RAND_MAX++;

            } while (gabarito.Quantidade2 != dezenas2.Count());
        }

        private void GerarDezena1(Gabarito gabarito, ref IEnumerable<int> dezenas1)
        {
            do
            {
                dezenas1 = listaNumerosResultados.GroupBy(x => x)
                   .OrderByDescending(g => g.Count())
                   .Select(g => g.Key)
                   .Where(x => x < 10)
                   .Skip(GetRandomNumber(RAND_MIN, RAND_MAX))
                   .Take(gabarito.Quantidade1)
                   .ToList();

                    RAND_MAX++;

            } while (gabarito.Quantidade1 != dezenas1.Count());
        }

        
        
        private static void ResetRandomSettings()
        {
            RAND_MIN = 1;
            RAND_MAX = 2;
        }

        private bool JogoJaFoiSorteado(Resultado jogoGerado) {
            
            bool retorno = true;
            
            var jaSorteado = (from r in listaJogosSorteados
                         where r.Dezena1 == jogoGerado.Dezena1 &&
                               r.Dezena2 == jogoGerado.Dezena2 &&
                               r.Dezena3 == jogoGerado.Dezena3 &&
                               r.Dezena4 == jogoGerado.Dezena4 &&
                               r.Dezena5 == jogoGerado.Dezena5 &&
                               r.Dezena6 == jogoGerado.Dezena6
                               select r.Concurso
                         ).ToList();

            retorno = jaSorteado.Count != 0;
            
            return retorno;
        }
        
        public void AddToLog(String message)
        {
            if (Thread.CurrentThread != m_UIThread)
            {
                // Need for invoke if called from a different thread
                this.BeginInvoke((ThreadStart)delegate()
                    {
                        AddToLog(message);
                    });
            }
            else
            {
                // add this line at the top of the log
                lbLog.Items.Insert(0, message);

                // keep only a few lines in the log
                while (lbLog.Items.Count > LOG_MAX_LINES)
                {
                    lbLog.Items.RemoveAt(lbLog.Items.Count - 1);
                }
            }
        }
                
        private void UpdateRangeMedia()
        {
           
            int media = int.Parse(txtMediaSoma.Text);

            txtSomaMax.Text = (media + GetDesvioMedia()).ToString();
            txtSomaMin.Text = (media - GetDesvioMedia()).ToString();

        }
        


        private void btngerarNumeros_Click(object sender, EventArgs e)
        {
            bgWorkerGerarNumeros.RunWorkerAsync();
        }

        private void bgWorkerGerarNumeros_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            if ((worker.CancellationPending == true))
            {
                e.Cancel = true;
                return;
            }
            else
            {
                ResetRandomSettings();
                GerarNumeros();
                BindGridJogosGerados();
                
                //worker.ReportProgress((i * 10));
            }

            

        }

        private void txtMediaSoma_TextChanged(object sender, EventArgs e)
        {
            UpdateRangeMedia();
        }

        private void btnCancelarGeracao_Click(object sender, EventArgs e)
        {
            bgWorkerGerarNumeros.CancelAsync();
        }

        private void bgWorkerGerarNumeros_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            AddToLog("*** Processo finalizado ***");    
        }

        private void trackBarDesvioMedia_ValueChanged(object sender, EventArgs e)
        {
            txtDesvioMedia.Text = trackBarDesvioMedia.Value.ToString();
        }

    }
}
