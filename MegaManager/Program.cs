using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MegaManager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += new UnhandledExceptionEventHandler(GlobalExceptionHandler);

            CompositionRoot.Wire(new ApplicationModule());

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(CompositionRoot.Resolve<frmMain>());
        }

        private static void GlobalExceptionHandler(object sender, UnhandledExceptionEventArgs args)
        {
            Exception e = (Exception)args.ExceptionObject;
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Ocorreu um erro não previsto : {0}", e.Message);
            sb.AppendFormat("Runtime terminating: {0}", args.IsTerminating);
            MessageBox.Show(sb.ToString());

        }
    }
}
