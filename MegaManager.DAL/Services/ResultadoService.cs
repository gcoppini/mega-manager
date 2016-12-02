using System.Collections.Generic;
using System.Linq;
using MegaManager.Domain.Main;
using MegaManager.Data.Main;

namespace MegaManager.Services
{
    public class ResultadoService : BaseService
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
