using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MegaManager.Domain.Main;
using RDotNet;
using MegaManager.Infra.Data;

namespace MegaManager
{
    public partial class frmAnaliseR : Form
    {

        string PASTA_R_DLL = @"C:\Program Files\R\R-3.1.2\bin\x64";

        const string PASTA_DATA = "FILES\\R\\DATA";
        const string PASTA_SCRIPTS = "FILES\\R\\SCRIPTS";
        const string PASTA_R = "FILES\\R";

        const string ARQUIVO_MEGA_SEQ_VAR_R = "MegaSeqPorVariaveis.csv";
        const string ARQUIVO_MEGA_SEQ_SORTEIO_R = "MegaSeqPorSorteio.csv";
        const string ARQUIVO_MEGA_VAR_SORTEIO_R = "MegaVarPorSorteio.csv";

        public string FILE_SELECTED { get; set; }

        public string PATH_DATA
        {
            get
            {
                return Path.Combine(Application.StartupPath, PASTA_DATA);
            }
        }

        public string PATH_SCRIPTS
        {
            get
            {
                return Path.Combine(Application.StartupPath, PASTA_SCRIPTS);
            }
        }

        public string PATH_R
        {
            get
            {
                return Path.Combine(Application.StartupPath, PASTA_R);
            }
        }

        public string PATH_ARQUIVO_MEGA_SEQ_VAR_R
        {
            get
            {
                return Path.Combine(PATH_DATA, ARQUIVO_MEGA_SEQ_VAR_R);
            }
        }

        public string PATH_ARQUIVO_MEGA_SEQ_SORTEIO_R
        {
            get
            {
                return Path.Combine(PATH_DATA, ARQUIVO_MEGA_SEQ_SORTEIO_R);
            }
        }

        public string PATH_ARQUIVO_MEGA_VAR_SORTEIO_R
        {
            get
            {
                return Path.Combine(PATH_DATA, ARQUIVO_MEGA_VAR_SORTEIO_R);
            }
        }




        List<Resultado> lista = new List<Resultado>();

        REngine REngine_Instance = null;
        
        public frmAnaliseR()
        {
            InitializeComponent();
        }


        private void ConfiguraListView()
        {
            listView1.Columns.Add("Arquivo", 100);
            listView1.Columns.Add("Data", 100);
        }

        private void ExibeArquivoScripts()
        {
            listView1.Items.Clear();

            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(PASTA_SCRIPTS);
            foreach (System.IO.FileInfo f in dir.GetFiles("*.*"))
            {
                string[] v = new string[3];

                string p = Path.Combine(PASTA_SCRIPTS, f.Name);
                

                v[0] = f.Name;
                v[1] = File.GetCreationTime(p).ToString();

                listView1.Items.Add(new ListViewItem(v));
            }
        }

        private void ConfigureR() {

            
            bool r_located = false;

            while (r_located == false)
            {
                try
                {

                    REngine.SetEnvironmentVariables(PASTA_R_DLL, PATH_R);
                    REngine_Instance = REngine.GetInstance();
                    r_located = true;
                }

                catch
                {
                    MessageBox.Show(@"Unable to find R installation's \bin\x64 folder. Press OK to attempt to locate it.");

                    if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                    {
                        PASTA_R_DLL = @folderBrowserDialog1.SelectedPath;
                    }

                }
            }
        }



        private void frmAnaliseR_Load(object sender, EventArgs e)
        {
            ConfiguraListView();
            ExibeArquivoScripts();

        }

        private void btnProcessar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(FILE_SELECTED))
            {
                string r_script = string.Format(@"source('{0}')", FILE_SELECTED);
                REngine_Instance.Evaluate(r_script);
            }
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            string file = e.Item.Text;

            FILE_SELECTED = Path.Combine(PATH_SCRIPTS, file);
        }

        private void btnGerarCSV_Click(object sender, EventArgs e)
        {
            using (ResultadoRepository dal = new ResultadoRepository())
            {
                lista = dal.GetAll();
            }

            GenerateDataFileMegaSeqVar();
            GenerateDataFileSeqVarSorteio();
            GenerateDataFileVariaveisPorSorteio();

        }

        

        

        private void GenerateDataFileMegaSeqVar()
        {
            var csv = new StringBuilder();

            
            var x1 = string.Join(",", lista.Select(x => Int32.Parse(x.Dezena1)));
            var x2 = string.Join(",", lista.Select(x => Int32.Parse(x.Dezena2)));
            var x3 = string.Join(",", lista.Select(x => Int32.Parse(x.Dezena3)));
            var x4 = string.Join(",", lista.Select(x => Int32.Parse(x.Dezena4)));
            var x5 = string.Join(",", lista.Select(x => Int32.Parse(x.Dezena5)));
            var x6 = string.Join(",", lista.Select(x => Int32.Parse(x.Dezena6)));

            var linha0 = string.Format("\"{0}\",\"{1}\"", "Id", "Sequence");
            var linha1 = string.Format("{0},\"{1}\"", 1, x1);
            var linha2 = string.Format("{0},\"{1}\"", 2, x2);
            var linha3 = string.Format("{0},\"{1}\"", 3, x3);
            var linha4 = string.Format("{0},\"{1}\"", 4, x4);
            var linha5 = string.Format("{0},\"{1}\"", 5, x5);
            var linha6 = string.Format("{0},\"{1}\"", 6, x6);

            csv.AppendLine(linha0);
            csv.AppendLine(linha1);
            csv.AppendLine(linha2);
            csv.AppendLine(linha3);
            csv.AppendLine(linha4);
            csv.AppendLine(linha5);
            csv.AppendLine(linha6);

            File.WriteAllText(PATH_ARQUIVO_MEGA_SEQ_VAR_R, csv.ToString(), Encoding.Default);
        }

        private void GenerateDataFileSeqVarSorteio()
        {

            var csv = new StringBuilder();
            
            var linha0 = string.Format("\"{0}\",\"{1}\"", "Id", "Sequence");
            csv.AppendLine(linha0);

            foreach (var item in lista)
            {
                csv.AppendLine(string.Format("{0},\"{1},{2},{3},{4},{5},{6}\"",
                                          item.Id, Int32.Parse(item.Dezena1), Int32.Parse(item.Dezena2), Int32.Parse(item.Dezena3), 
                                                   Int32.Parse(item.Dezena4), Int32.Parse(item.Dezena5), Int32.Parse(item.Dezena6)));
            }

            File.WriteAllText(PATH_ARQUIVO_MEGA_SEQ_SORTEIO_R, csv.ToString(), Encoding.Default);
        }

        private void GenerateDataFileVariaveisPorSorteio()
        {
            var csv = new StringBuilder();

            var linha0 = string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\",\"{8}\",\"{9}\",\"{10}\",\"{11}\"", 
                                            "Id", "x1", "x2", "x3", "x4", "x5", "x6", 
                                            "Soma","Pares","Impares","Gabarito","DataSorteio");
            csv.AppendLine(linha0);

            foreach (var item in lista)
            {


                csv.AppendLine(string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}",
                                          item.Id, Int32.Parse(item.Dezena1), Int32.Parse(item.Dezena2), Int32.Parse(item.Dezena3), 
                                                   Int32.Parse(item.Dezena4), Int32.Parse(item.Dezena5), Int32.Parse(item.Dezena6),
                                                   item.Soma, item.QuantidadePares, item.QuantidadeImpares,item.Gabarito,
                                                   item.DataSorteio));
            }

            File.WriteAllText(PATH_ARQUIVO_MEGA_VAR_SORTEIO_R, csv.ToString(), Encoding.Default);
            
        }

   
    }
}
