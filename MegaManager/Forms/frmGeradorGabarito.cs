using Combinatorics.Collections;
using MegaManager.Models;
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

namespace MegaManager
{
    public partial class frmGeradorGabarito : Form
    {
        public frmGeradorGabarito()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {




            int[] inputSet2 = Enumerable.Range(1, 60).ToArray();

            Combinations<int> combinations = new Combinations<int>(inputSet2,6,GenerateOption.WithoutRepetition);
            string cformat = "Permutations: size = {0}";
            label1.Text = String.Format(cformat, combinations.Count);

            List<object> result = new List<object>();
            foreach (IList<int> c in combinations)
            {
                Resultado g = new Resultado();
                g.Dezena1 = c[0].ToString();
                g.Dezena1 = c[1].ToString();
                g.Dezena1 = c[2].ToString();
                g.Dezena1 = c[3].ToString();
                g.Dezena1 = c[4].ToString();
                g.Dezena1 = c[5].ToString();
                
                result.Add(g);
                GC.Collect();
            }
            

            dataGridView1.DataSource = result;
        }
    }
}
