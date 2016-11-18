using System.Collections.Generic;
using System.Linq;
using MegaManager.Domain.Main;
using MegaManager.Data.Main;

namespace MegaManager.DAL
{
    public class ResultadoDAL : BaseDAL
    {
        private bool _disposed;

        public List<Resultado> GetAll() 
        {
            var listResult = new List<Resultado>();

            using (DataContext ctx = new DataContext())
            {
                listResult = ctx.Resultados.ToList();
            }


            return listResult;
        }

        public void ImportToDatabase(List<Resultado> listToImport)
        {
            using (DataContext ctx = new DataContext())
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
