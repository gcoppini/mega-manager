using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using MegaManager.Domain.Main;
using MegaManager.Infra.CrossCutting;

namespace MegaManager
{
    public partial class frmAnaliseResultados : Form
    {


        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }

        List<Resultado> listaResultados = new List<Resultado>();
        List<Gabarito> listaGabaritos = new List<Gabarito>();
        List<int> listaNumerosResultados = new List<int>();


        public frmAnaliseResultados()
        {
            InitializeComponent();
            
            listaResultados = App.Instance._resultadoRepository.GetAll().ToList();
            listaGabaritos = App.Instance._gabaritoRepository.GetAll().ToList();
            
            IdentificaGabarito();
            CarregaListaNumeros();

            monthCalendarDataInicial.SetDate(DateTime.Now.AddYears(-1));
            monthCalendarDataFinal.SetDate(DateTime.Now);

            
        }
        
        private void CarregaListaNumeros()
        {
            List<Resultado> lista = App.Instance._resultadoRepository.GetAll().ToList();
            
            listaNumerosResultados.AddRange(lista.Select(x => int.Parse(x.Dezena1)));
            listaNumerosResultados.AddRange(lista.Select(x => int.Parse(x.Dezena2)));
            listaNumerosResultados.AddRange(lista.Select(x => int.Parse(x.Dezena3)));
            listaNumerosResultados.AddRange(lista.Select(x => int.Parse(x.Dezena4)));
            listaNumerosResultados.AddRange(lista.Select(x => int.Parse(x.Dezena5)));
            listaNumerosResultados.AddRange(lista.Select(x => int.Parse(x.Dezena6)));
            
            var noticesGrouped = listaNumerosResultados.GroupBy(n => n).
                    Select(group =>
                        new
                        {
                            Numero = group.Key,
                            Numeros = group.ToList(),
                            Count = group.Count(),
                            Data = (lista.Where(x => int.Parse(x.Dezena1) == group.Key ||
                                                     int.Parse(x.Dezena2) == group.Key ||
                                                     int.Parse(x.Dezena3) == group.Key ||
                                                     int.Parse(x.Dezena4) == group.Key ||
                                                     int.Parse(x.Dezena5) == group.Key ||
                                                     int.Parse(x.Dezena6) == group.Key).Max(z => DateTime.Parse(z.DataSorteio))),
                            DataDif = Math.Round((DateTime.Now - (lista.Where(x => int.Parse(x.Dezena1) == group.Key ||
                                                     int.Parse(x.Dezena2) == group.Key ||
                                                     int.Parse(x.Dezena3) == group.Key ||
                                                     int.Parse(x.Dezena4) == group.Key ||
                                                     int.Parse(x.Dezena5) == group.Key ||
                                                     int.Parse(x.Dezena6) == group.Key).Max(z => DateTime.Parse(z.DataSorteio)))).TotalDays)

                            
                          }).OrderByDescending(z => z.Count);



            dataGridViewNumeros.DataSource = noticesGrouped.ToList();


        }
        
        private void IdentificaGabarito()
        {
                    
            foreach (var resultado in listaResultados)
            {

                var dezenas = new List<string> { resultado.Dezena1,resultado.Dezena2,resultado.Dezena3, resultado.Dezena4, resultado.Dezena5, resultado.Dezena6 };
                
                var qtd1 = dezenas.Count(x => int.Parse(x) < 10);
                var qtd2 = dezenas.Count(x => int.Parse(x) > 9 && int.Parse(x) < 20);
                var qtd3 = dezenas.Count(x => int.Parse(x) > 19 && int.Parse(x) < 30);
                var qtd4 = dezenas.Count(x => int.Parse(x) > 29 && int.Parse(x) < 40);
                var qtd5 = dezenas.Count(x => int.Parse(x) > 39 && int.Parse(x) < 50);
                var qtd6 = dezenas.Count(x => int.Parse(x) > 49 && int.Parse(x) < 60);
                var qtd7 = dezenas.Count(x => int.Parse(x) > 59 && int.Parse(x) < 70);

                var gaba = listaGabaritos.Where(x => x.Quantidade1 == qtd1)
                                         .Where(x => x.Quantidade2 == qtd2)
                                         .Where(x => x.Quantidade3 == qtd3)
                                         .Where(x => x.Quantidade4 == qtd4)
                                         .Where(x => x.Quantidade5 == qtd5)
                                         .Where(x => x.Quantidade6 == qtd6)
                                         .Where(x => x.Quantidade7 == qtd7).First();
                
                resultado.Gabarito = gaba.Numero;
                                         

            }

        }

        private string SomaMedia()
        {
            if (DataInicial == DateTime.MinValue || DataFinal == DateTime.MinValue || (DataInicial > DataFinal))
                return string.Empty;
                

            var max = listaResultados.Where(x => DateTime.Parse(x.DataSorteio) >= DataInicial && DateTime.Parse(x.DataSorteio) <= DataFinal).Max(x => x.Soma);
            var min = listaResultados.Where(x => DateTime.Parse(x.DataSorteio) >= DataInicial && DateTime.Parse(x.DataSorteio) <= DataFinal).Min(x => x.Soma);
            var media = (max + min) / 2;
            
            var mediaDiferenca = listaResultados.Where(x => DateTime.Parse(x.DataSorteio) >= DataInicial && DateTime.Parse(x.DataSorteio) <= DataFinal).Average(x => x.DiferencaSomaAnteior);

            lblSomaMax.Text = max.ToString();
            lblSomaMin.Text = min.ToString();
            lblSomaMedia.Text = media.ToString();

            lblMediaDiferSoma.Text = Math.Round(mediaDiferenca).ToString();
            lblMediaSomaMaisMediaDif.Text = (Math.Round(media + mediaDiferenca)).ToString();
            lblMediaSomaMenosMediaDif.Text = (Math.Round(media - mediaDiferenca)).ToString();

            return media.ToString();

        }

        private void ShowGraficoMediaSoma()
        {

            if (chart1.Series.Count > 0)
            {
                chart1.Series[0].Points.Clear();
                chart1.Series.Clear();
                chart1.ChartAreas[0].AxisY.StripLines.Clear();
            }

            if (this.chart1.Titles.Count == 0)
                this.chart1.Titles.Add("Média da Soma");


            Series serie = new Series();
            serie.XValueType = ChartValueType.Int32;
            serie.ChartType = SeriesChartType.Column;
            chart1.Series.Add(serie);
            chart1.ChartAreas[0].AxisY.IsStartedFromZero = false;


            StripLine sl = new StripLine();
            sl.BorderColor = Color.Red;
            sl.BackColor = Color.Red;
            sl.IntervalOffset = Double.Parse(SomaMedia());
            chart1.ChartAreas[0].AxisY.StripLines.Add(sl);

            List<Resultado> lista = listaResultados.Where(x => DateTime.Parse(x.DataSorteio) >= DataInicial && DateTime.Parse(x.DataSorteio) <= DataFinal).ToList();

            foreach (var resultado in lista)
            {
                DataPoint dp = new DataPoint();
                dp.XValue = Double.Parse(resultado.Concurso);
                dp.YValues = new double[] { resultado.Soma };

                dp.Label = resultado.Soma.ToString();
                dp.AxisLabel = resultado.DataSorteio;

                chart1.Series[0].Points.Add(dp);
            }

            chart1.DataBind();
            chart1.Update();


        }

        private void AgrupaResultadosPorGabarito()
        {
            var noticesGrouped = listaResultados
                    .Where(x => DateTime.Parse(x.DataSorteio) >= DataInicial && DateTime.Parse(x.DataSorteio) <= DataFinal)
                    .GroupBy(n => n.Gabarito).
                     Select(group =>
                         new
                         {
                             Gabarito = group.Key,
                             Gabaritos = string.Join(",",group.GroupBy(x => x.Gabarito).Select(y=>y.First().Gabarito)),
                             Concursos = string.Join(",", group.Select(x => x.Concurso)),
                             Count = group.Count(),
                             UltimaOcorrencia = group.Max(x => DateTime.Parse(x.DataSorteio)),
                             DateDiff = Math.Round((DateTime.Now - group.Max(x => DateTime.Parse(x.DataSorteio))).TotalDays),
                             Tipo = group.Select(x => x.Tipo).First()
                         }).OrderByDescending(z => z.Count);



            DataTable table = Helpers.ToDataTable(noticesGrouped.ToList());

            dataGridView2.DataSource = table;

            foreach (DataGridViewColumn column in dataGridView2.Columns)
            {

                dataGridView2.Columns[column.Name].SortMode = DataGridViewColumnSortMode.Automatic;
            }
        }





        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            DataInicial = monthCalendarDataInicial.SelectionRange.Start;
        }

        private void monthCalendar2_DateChanged(object sender, DateRangeEventArgs e)
        {
            DataFinal = monthCalendarDataFinal.SelectionRange.Start;
        }



        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (e.ColumnIndex < 2 || e.ColumnIndex > 7)
                return;

            int valor;
            Color back = e.CellStyle.BackColor;

            if (e.Value != null && int.TryParse(e.Value.ToString(), out valor))
            {

                if (valor < 10)
                {
                    back = Color.Gold;
                }
                else if (valor > 9 && valor < 20)
                {
                    back = Color.CornflowerBlue;
                }
                else if (valor > 19 && valor < 30)
                {
                    back = Color.LightGray;
                }
                else if (valor > 29 && valor < 40)
                {
                    back = Color.LightGreen;
                }
                else if (valor > 39 && valor < 50)
                {
                    back = Color.LightPink;
                }
                else if (valor > 49 && valor < 60)
                {
                    back = Color.PapayaWhip;
                }
                else if (valor > 59 && valor < 70)
                {
                    back = Color.IndianRed;
                }


            }
            e.CellStyle.BackColor = back;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            DataTable table = Helpers.ToDataTable<Resultado>(listaResultados);

            dataGridView1.DataSource = table;

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {

                dataGridView1.Columns[column.Name].SortMode = DataGridViewColumnSortMode.Automatic;
            }

            


            SomaMedia();

            ShowGraficoMediaSoma();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            AgrupaResultadosPorGabarito();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SomaMedia();
        }

        private void btnParesImpares_Click(object sender, EventArgs e)
        {
            AgrupaResultadosPorParesImpares();
        }

        private void AgrupaResultadosPorParesImpares()
        {
            var noticesGrouped = listaResultados
                   .Where(x => DateTime.Parse(x.DataSorteio) >= DataInicial && DateTime.Parse(x.DataSorteio) <= DataFinal)
                   .GroupBy(n => new { n.QuantidadePares, n.QuantidadeImpares }).
                    Select(group =>
                        new
                        {

                            QuantidadePares = group.Key.QuantidadePares,
                            QuantidadeImpares = group.Key.QuantidadeImpares,
                            Count = group.Count(),
                            UltimaOcorrencia = group.Max(x => DateTime.Parse(x.DataSorteio)),
                            DateDiff = Math.Round((DateTime.Now - group.Max(x => DateTime.Parse(x.DataSorteio))).TotalDays)
                            
                        }).OrderByDescending(z => z.Count);

            DataTable table = Helpers.ToDataTable(noticesGrouped.ToList());

            dataGridViewParesImpares.DataSource = table;

            foreach (DataGridViewColumn column in dataGridViewParesImpares.Columns)
            {

                dataGridViewParesImpares.Columns[column.Name].SortMode = DataGridViewColumnSortMode.Automatic;
            }
        
        }



        

    }
}
