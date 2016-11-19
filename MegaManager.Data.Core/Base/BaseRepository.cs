using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MegaManager.Data.Main
{
    public class BaseRepository<TEntity> : IDisposable, IRepository<TEntity> where TEntity : class
    {
        // Flag stating if the current instance is allready disposed.
        private bool _disposed;

        DataContext ctx = new DataContext();
        
        public IQueryable<TEntity> GetAll()
        {
            return ctx.Set<TEntity>();
        }

        public IQueryable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return GetAll().Where(predicate).AsQueryable();
        }

        public TEntity Find(params object[] key)
        {
            return ctx.Set<TEntity>().Find(key);
        }

        public void Atualizar(TEntity obj)
        {
            ctx.Entry(obj).State = EntityState.Modified;
        }

        public void SalvarTodos()
        {
            ctx.SaveChanges();
        }

        public void Adicionar(TEntity obj)
        {
            ctx.Set<TEntity>().Add(obj);
        }

        public void Excluir(Func<TEntity, bool> predicate)
        {
            ctx.Set<TEntity>()
                .Where(predicate).ToList()
                .ForEach(del => ctx.Set<TEntity>().Remove(del));
        }

        public override string ToString()
        {
            return "Repository with type : " + typeof(TEntity).Name;
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
                ctx.Dispose();
            }

            _disposed = true;
        }
              
    }
}
