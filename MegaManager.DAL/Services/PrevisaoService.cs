using System.Collections.Generic;
using System.Linq;
using MegaManager.Data.Main;
using MegaManager.Domain.Main;

namespace MegaManager.Services
{
    public class PrevisaoService : BaseService
    {
        private bool _disposed;
        

        protected override void Dispose(bool disposing)
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

            base.Dispose(disposing);
        }
                
    }
}
