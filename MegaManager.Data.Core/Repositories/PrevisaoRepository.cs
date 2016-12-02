using System.Collections.Generic;
using System.Linq;
using MegaManager.Data.Main;
using MegaManager.Domain.Main;

namespace MegaManager.Infra.Data
{
    public class PrevisaoRepository : BaseRepository<Previsao>
    {
        private bool _disposed;
        
        public List<Previsao> GetAll()
        {
            var listResult = new List<Previsao>();

            using (MegaManagerContext ctx = new MegaManagerContext())
            {
                listResult = ctx.Previsoes.ToList();
            }


            return listResult;
        }

        public void Adicionar(Previsao previsao)
        {
            using (MegaManagerContext ctx = new MegaManagerContext())
            {
                ctx.Previsoes.Add(previsao);
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
