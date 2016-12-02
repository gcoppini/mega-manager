using System.Collections.Generic;
using System.Linq;
using MegaManager.Domain.Main;
using MegaManager.Data.Main;

namespace MegaManager.Infra.Data
{
    public class ResultadoRepository : BaseRepository<Resultado>
    {
        private bool _disposed;

        public List<Resultado> GetAll() 
        {
            return base.GetAll().ToList();
        }

        public void ImportToDatabase(List<Resultado> listToImport)
        {
            using (MegaManagerContext ctx = new MegaManagerContext())
            {
                foreach (var item in listToImport)
                {
                    ctx.Resultados.Add(item);
                }

                ctx.SaveChanges();
            }
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
