using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MegaManager.Data.Main;
using MegaManager.Domain.Main;
using MegaManager.Infra.Data;

namespace MegaManager
{
    public partial class frmMain : BaseForm
    {
        private int childFormNumber = 0;
        

        public frmMain(IRepository<Resultado> resultadoRepository,
                       IRepository<Gabarito> gabaritoRepository)
        {
            App.Instance._resultadoRepository = resultadoRepository;
            App.Instance._gabaritoRepository = gabaritoRepository;
                        
            InitializeComponent();
        }

        

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

  

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }
                

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void importarResultadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmImportacaoResultados form = new frmImportacaoResultados();
            form.MdiParent = this;
            form.Show();
        }

        private void geradorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGeradorJogos form = new frmGeradorJogos();
            form.MdiParent = this;
            form.Show();
        }

        private void gabaritosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGabaritos form = new frmGabaritos();
            form.MdiParent = this;
            form.Show();
        }

        private void resultadosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void análiseToolStripMenuItem_Click(object sender, EventArgs e)
        {

          

        }

        private void geradorGabaritosToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmGeradorGabarito form = new frmGeradorGabarito();
            form.MdiParent = this;
            form.Show();


        }

        private void analíticoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAnaliseResultados form = new frmAnaliseResultados();
            form.MdiParent = this;
            form.Show();
        }

        private void rToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAnaliseR form = new frmAnaliseR();
            form.MdiParent = this;
            form.Show();
        }

        private void análisePrevisõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPrevisao form = new frmPrevisao();
            form.MdiParent = this;
            form.Show();
        }

      
    }
}
