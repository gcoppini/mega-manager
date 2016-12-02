using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MegaManager.Data.Main;
using MegaManager.Domain.Main;
using MegaManager.Infra.Data;

namespace MegaManager
{
    public sealed class App
    {
        private static volatile App instance;
        private static object syncRoot = new Object();

        //Repos
        internal IRepository<Resultado> _resultadoRepository;
        internal IRepository<Gabarito> _gabaritoRepository;

        private App()
        {
        }

        public static App Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new App();
                    }
                }

                return instance;
            }
        }


    }
}
