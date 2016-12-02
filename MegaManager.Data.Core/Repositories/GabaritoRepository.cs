using System.Collections.Generic;
using System.Linq;
using MegaManager.Data.Main;
using MegaManager.Domain.Main;

namespace MegaManager.Infra.Data
{
    public class GabaritoRepository : BaseRepository<Gabarito>
    {
        private bool _disposed;
        
        public List<Gabarito> GetAll()
        {
            return base.GetAll().ToList();
        }

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
