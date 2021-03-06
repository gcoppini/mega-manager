﻿using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Windows.Forms;
using MegaManager.Domain.Main;
using MegaManager.Infra.Data;
using MegaManager.Infra.CrossCutting;

namespace MegaManager
{
    public partial class frmImportacaoResultados : Form
    {
        const string URL_GET_COOKIES = "http://www1.caixa.gov.br/loterias/loterias/megasena/download.asp";
        const string URL_ARQUIVO_RESULTADOS = "http://www1.caixa.gov.br/loterias/_arquivos/loterias/D_mgsasc.zip";
                
        const string PASTA_DOWNLOAD = "FILES\\DOWNLOAD";
        const string PASTA_EXTRACTED = "FILES\\EXTRACTED";
        const string FILE_EXTRACTED_NAME = "d_megasc.htm";
               

        private const string PROXY_LOGIN = @"foo\bar";
        private const string PROXY_PASS = "foo@bar";

        private const string PROXY_SERVER = "FOO.BAR.COM";
        private const int PROXY_PORT = 8080;


        public string PATH_DOWNLOAD 
        {
            get 
            {
                return Path.Combine(Application.StartupPath, PASTA_DOWNLOAD);
            }
        }
        
        public string PATH_EXTRACTED 
        {
            get
            {
                return Path.Combine(Application.StartupPath, PASTA_EXTRACTED);
            }
        }

        public string FILE_DOWNLOAD_NAME 
        {
            get
            {
                return DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + ".zip";
            }
        }
      
        public string FILE_COMPACTED { get; set; }

        public string FILE_EXTRACTED { get; set; }

        public string FILE_SELECTED { get; set; }


        List<Resultado> listToImport = new List<Resultado>();



        public frmImportacaoResultados()
        {
            InitializeComponent();
            
            ConfiguraListView();

            ExibeArquivoDownload();


            linkLabelDownloadFolder.Text = PASTA_DOWNLOAD;
            linkLabelDownloadFolder.Links.Add(0, PASTA_DOWNLOAD.Length, PASTA_DOWNLOAD);

            linkLabelExtractedFolder.Text = PASTA_EXTRACTED;
            linkLabelExtractedFolder.Links.Add(0, PASTA_EXTRACTED.Length, PASTA_EXTRACTED);
        }
        

        private void ConfiguraListView() 
        {
            listView1.Columns.Add("Arquivo", 100);
            listView1.Columns.Add("Hash", 100);
            listView1.Columns.Add("Data", 100);

            listView2.Columns.Add("Arquivo", 100);
            listView2.Columns.Add("Hash", 100);
            listView2.Columns.Add("Data", 100);
        }
                
        private bool CheckNumber(string s) 
        {
            if (string.IsNullOrEmpty(s)) return false;
            return s.All(Char.IsDigit);
        }
        
        
        private void CarregaGridResultados(List<Resultado> listToImport)
        {
            DataTable table = Helpers.ToDataTable<Resultado>(listToImport);
            dataGridView1.DataSource = table;
        }
        
        private void ExibeArquivoDownload()
        {
            listView1.Items.Clear();

            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(PATH_DOWNLOAD);
            foreach (System.IO.FileInfo f in dir.GetFiles("*.*"))
            {
                string[] v = new string[3];

                string p = Path.Combine(PATH_DOWNLOAD,f.Name);
                string hash = CalculateMD5(p);
                
                v[0] = f.Name;
                v[1] = hash;
                v[2] = File.GetCreationTime(p).ToString();

                listView1.Items.Add(new ListViewItem(v));
            }
        }
        
        private string DescompactaArquivoResultados(string file)
        {
            string filePath = Path.Combine(PATH_DOWNLOAD, file);
            string folder = Path.Combine(PATH_EXTRACTED, Path.GetFileNameWithoutExtension(file));

            string extratec_file = Path.Combine(folder, FILE_EXTRACTED_NAME);

            if (!File.Exists(extratec_file))
                ZipFile.ExtractToDirectory(filePath, folder);


            return extratec_file;
        }
        
        private void DownloadArquivoResultados()
        {
            string p = Path.Combine(PATH_DOWNLOAD, FILE_DOWNLOAD_NAME);

            CookieContainer cookieJar = new CookieContainer();

            WebRequest requestCookieCapture = WebRequest.Create(URL_GET_COOKIES);
            ((HttpWebRequest)requestCookieCapture).CookieContainer = cookieJar;

            WebProxy myproxy = new WebProxy(PROXY_SERVER, PROXY_PORT);
            myproxy.BypassProxyOnLocal = false;
            myproxy.Credentials = new NetworkCredential(PROXY_LOGIN, PROXY_PASS);
            //requestLogin.Proxy = myproxy;

            requestCookieCapture.ContentType = "application/x-www-form-urlencoded";
            requestCookieCapture.Method = "GET";
            

            WebResponse responseLogin = requestCookieCapture.GetResponse();
            //string cookieHeader = resp.Headers["Set-cookie"];

            
            string contentLogin = string.Empty;
            using (StreamReader sr = new StreamReader(responseLogin.GetResponseStream()))
            {
                contentLogin = sr.ReadToEnd();
            }
         

            WebRequest requestDownloadResultados = WebRequest.Create(URL_ARQUIVO_RESULTADOS);
            //requestBatePonto.Proxy = myproxy;
            ((HttpWebRequest)requestDownloadResultados).CookieContainer = cookieJar;
            HttpWebResponse responseDownloadResultados = (HttpWebResponse)requestDownloadResultados.GetResponse();

            using (Stream responseStream = responseDownloadResultados.GetResponseStream())
            {
                using (FileStream fileStream = new FileStream(p, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    byte[] buffer = new byte[4096];
                    int BytesRead;
                    
                    while (0 < (BytesRead = responseStream.Read(buffer, 0, buffer.Length)))
                    {
                        fileStream.Write(buffer, 0, BytesRead);
                    }
                }
            }

      
        }
        
        private List<Resultado> ParseArquivoResultado(string file)
        {

            List<Resultado> result = new List<Resultado>();


            var document = new HtmlAgilityPack.HtmlDocument();
            document.Load(file);

            foreach (HtmlNode table in document.DocumentNode.SelectNodes("//table"))
            {
                foreach (HtmlNode row in table.SelectNodes("tr"))
                {
                    Resultado res = new Resultado();
                    int i = 0;
                    //th|td
                    foreach (HtmlNode cell in row.SelectNodes("th|td"))
                    {
                        switch (i)
                        {
                            case 0:
                                res.Concurso = cell.InnerText;
                                break;

                            case 1:
                                res.DataSorteio = cell.InnerText;
                                break;
                            
                            case 2:
                                res.Dezena1 = cell.InnerText;
                                break;

                            case 3:
                                res.Dezena2 = cell.InnerText;
                                break;

                            case 4:
                                res.Dezena3 = cell.InnerText;
                                break;

                            case 5:
                                res.Dezena4 = cell.InnerText;
                                break;

                            case 6:
                                res.Dezena5 = cell.InnerText;
                                break;

                            case 7:
                                res.Dezena6 = cell.InnerText;
                                break;

                            default:
                                break;
                        }
                        i++;
                    }
                    result.Add(res);
                }

                break;
            }

            result = result.Where(x => CheckNumber(x.Concurso) == true).ToList();

            return result;
        }
        
        private void ShowInBrowser(string file)
        {
            if (File.Exists(file))
            {
                webBrowser1.Url = new Uri(file);
            }
        }
        
        private string CalculateMD5(string fileName)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(fileName))
                {
                    return BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", "").ToLower();
                }
            }
        }

        private void ImportarResultados()
        {
            List<Resultado> listaResultadosExistentes = App.Instance._resultadoRepository.GetAll().ToList();
            
            //Faz diff entre a lista existente com a lista com novos resultados
            var listaNovosResultados = (from r in listToImport
                         where !(from p in listaResultadosExistentes select p.Concurso).Contains(r.Concurso)
                         select r).ToList();
            
            if (listaNovosResultados.Count > 0)
            {
                string msg = string.Format("{0} novo resultado.  Deseja Importar?", listaNovosResultados.Count);

                if (MessageBox.Show(msg, "", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        listaNovosResultados.ForEach(App.Instance._resultadoRepository.Adicionar);
                        App.Instance._resultadoRepository.SalvarTodos();
                        MessageBox.Show("Importação realizada com sucesso");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Falha ao realizar a importação");
                        throw;
                    }
                }
            }
            else
            {
                MessageBox.Show("Sem novos resultado");
            }
        }

        private void CarregarResultados()
        {
            List<Resultado> lista = new List<Resultado>();

            using (ResultadoRepository dal = new ResultadoRepository())
            {
                lista = dal.GetAll();
            }


            DataTable table = Helpers.ToDataTable<Resultado>(lista);

            dataGridView1.DataSource = table;
        }






        private void btnImportarResultados_Click(object sender, EventArgs e)
        {
            ImportarResultados();
        }

        private void btnDownloadResultados_Click(object sender, EventArgs e)
        {
            DownloadArquivoResultados();
            ExibeArquivoDownload();
        }

        private void btnExibirResultados_Click(object sender, EventArgs e)
        {
            CarregarResultados();
        }
               

        private void btnExtrairResultados_Click(object sender, EventArgs e)
        {
            string arquivoCompactado = listView1.SelectedItems[0].Text;

            string arquivoDescompactado = DescompactaArquivoResultados(arquivoCompactado);
       
        }
        
        private void btnMerge_Click(object sender, EventArgs e)
        {
            List<Resultado> lista = new List<Resultado>();

            using (ResultadoRepository dal = new ResultadoRepository())
            {
                lista = dal.GetAll();
            }
            
            var query = from r in listToImport
                         where !(from p in lista select p.Concurso).Contains(r.Concurso)
                        select r;

        }



        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            listView2.Items.Clear();
            string arquivo = e.Item.Text;
            string pasta = Path.Combine(PATH_EXTRACTED, Path.GetFileNameWithoutExtension(arquivo));


            if (Directory.Exists(pasta))
            {
                System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(pasta);
                foreach (System.IO.FileInfo f in dir.GetFiles("*.*"))
                {
                    string[] v = new string[3];

                    string p = Path.Combine(pasta, f.Name);
                    string hash = CalculateMD5(p);

                    v[0] = f.Name;
                    v[1] = hash;
                    v[2] = File.GetCreationTime(p).ToString();

                    listView2.Items.Add(new ListViewItem(v));
                }
            }
            else
            {
                MessageBox.Show("Extrair!");
            }

            FILE_SELECTED = arquivo;
        }

        private void listView2_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            string file = e.Item.Text;
            string folder = Path.Combine(PATH_EXTRACTED, Path.GetFileNameWithoutExtension(FILE_SELECTED));

            string extratec_file = Path.Combine(folder, file);

            ShowInBrowser(extratec_file);

            List<Resultado> result = ParseArquivoResultado(extratec_file);

            CarregaGridResultados(result);
            
            listToImport = result;
        }


        private void linkLabelDownloadFolder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(e.Link.LinkData.ToString());
        }

        private void linkLabelExtractedFolder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(e.Link.LinkData.ToString());
        }

    }
}
