using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaManager.DAL
{
    public abstract class BaseDAL : IDisposable
    {

        internal DbConnection connection;
        

        // Flag stating if the current instance is allready disposed.
        private bool _disposed;

        public BaseDAL()
        {
            /*
            var connectionString = ConfigurationManager.ConnectionStrings["MegaManager"];
            var providerName = connectionString.ProviderName;
            var factory = DbProviderFactories.GetFactory(providerName);

            connection = factory.CreateConnection();
            connection.ConnectionString = connectionString.ToString();
                        
            connection.Open();
             */
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize((object)this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                // Dispose all managed resources here.
                //connection.Close();
            }

            _disposed = true;
        }

    }
}
