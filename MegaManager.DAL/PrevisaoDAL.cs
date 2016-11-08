using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MegaManager.Data.Main;
using MegaManager.Domain.Main;

namespace MegaManager.DAL
{
    public class PrevisaoDAL : BaseDAL
    {
        private bool _disposed;
        
        public List<Previsao> GetAll()
        {
            var listResult = new List<Previsao>();

            using (DataContext ctx = new DataContext())
            {
                listResult = ctx.Previsoes.ToList();
            }


            return listResult;
        }

        public void Adicionar(Previsao previsao)
        {
            using (DataContext ctx = new DataContext())
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
