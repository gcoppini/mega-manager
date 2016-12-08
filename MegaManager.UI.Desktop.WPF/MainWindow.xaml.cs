using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MegaManager.UI.Desktop.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SubsribeEvents();
        }


        private void SubsribeEvents() {
            btnOK.Click += BtnOK_Click;
        }

        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("OK NOK!");
        }
    }
}
