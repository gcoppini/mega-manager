using System.Collections.Generic;
using System.Linq;
using MegaManager.Data.Main;
using MegaManager.Domain.Main;

namespace MegaManager.DAL
{
    public class GabaritoDAL : BaseDAL
    {
        private bool _disposed;
        
        public List<Gabarito> GetAll()
        {
            var listResult = new List<Gabarito>();

            using (DataContext ctx = new DataContext())
            {
                listResult = ctx.Gabaritos.ToList();
            }

            return listResult;
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
