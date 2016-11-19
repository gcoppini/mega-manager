using Combinatorics.Collections;
using MegaManager.DAL;
using MegaManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MegaManager.Domain.Main;

namespace MegaManager
{
    public partial class frmGabaritos : Form
    {
        public frmGabaritos()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Gabarito> lista = new List<Gabarito>();

            using (GabaritoDAL dal = new GabaritoDAL())
            {
                lista = dal.GetAll();
            }


            
            DataTable table = Helpers.ToDataTable<Gabarito>(lista);

            dataGridView1.DataSource = table;
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex < 4 || e.ColumnIndex > 10)
                return;

            int valor;
            Color back = e.CellStyle.BackColor;

            if (e.Value != null && int.TryParse(e.Value.ToString(), out valor))
            {

                if (valor == 0)
                {
                    back = Color.Gold;
                }
                else if (valor == 1)
                {
                    back = Color.CornflowerBlue;
                }
                else if (valor ==2)
                {
                    back = Color.LightGray;
                }
                else if (valor == 3)
                {
                    back = Color.LightGreen;
                }
                else if (valor == 4)
                {
                    back = Color.LightPink;
                }
                else if (valor ==5 )
                {
                    back = Color.PapayaWhip;
                }
                else if (valor ==6)
                {
                    back = Color.IndianRed;
                }


            }
            e.CellStyle.BackColor = back;
        }

       

    }
}
