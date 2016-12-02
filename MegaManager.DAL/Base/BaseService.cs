using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace MegaManager.Services
{
    public abstract class BaseService : IBaseService
    {
        // Flag stating if the current instance is allready disposed.
        private bool _disposed;


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
            }

            _disposed = true;
        }
    }
}
