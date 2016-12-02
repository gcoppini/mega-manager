using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MegaManager.Domain.Main;
using MegaManager.Infra.Data;
using MegaManager.Infra.CrossCutting;

namespace MegaManager
{
    public partial class frmPrevisao : Form
    {

        List<Previsao> listaPrevisoes = new List<Previsao>();

        public frmPrevisao()
        {
            InitializeComponent();
        }


        private void CarregaPrevisoes()
        {
            using (PrevisaoRepository dal = new PrevisaoRepository())
            {
                listaPrevisoes = dal.GetAll();
            }
        }
        
        public void BindGridPrevisoes()
        {
            DataTable table = Helpers.ToDataTable<Previsao>(listaPrevisoes);

            dataGridView1.DataSource = table;

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {

                dataGridView1.Columns[column.Name].SortMode = DataGridViewColumnSortMode.Automatic;
            }
        }

        public void RefreshPrevisoes() {
            CarregaPrevisoes();
            BindGridPrevisoes();
        }

        public void AdiconarPrevisao(Previsao previsao) {

            using (PrevisaoRepository previsaoDal = new PrevisaoRepository())
            {
                previsaoDal.Adicionar(previsao);
            }
        }


        private void frmPrevisao_Load(object sender, EventArgs e)
        {
            RefreshPrevisoes();
        }

        private void btnAdicionarPrevisao_Click(object sender, EventArgs e)
        {
            Previsao novaPrevisao = new Previsao();
            novaPrevisao.Concurso = txtConcurso.Text;
            novaPrevisao.Dezena1 = txtDezena1.Text;
            novaPrevisao.Dezena2 = txtDezena2.Text;
            novaPrevisao.Dezena3 = txtDezena3.Text;
            novaPrevisao.Dezena4 = txtDezena4.Text;
            novaPrevisao.Dezena5 = txtDezena5.Text;
            novaPrevisao.Dezena6 = txtDezena6.Text;

            AdiconarPrevisao(novaPrevisao);

            RefreshPrevisoes();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex < 4 || e.ColumnIndex > 9)
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

        
    }
}
