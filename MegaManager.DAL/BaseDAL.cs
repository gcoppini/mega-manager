using System;
using System.Data.Common;

namespace MegaManager.DAL
{
    public abstract class BaseDAL : IDisposable
    {

        internal DbConnection connection;
        

        // Flag stating if the current instance is allready disposed.
        private bool _disposed;

        public BaseDAL()
        {

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
