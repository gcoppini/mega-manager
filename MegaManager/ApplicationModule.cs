using MegaManager.Data.Main;
using Ninject.Modules;

namespace MegaManager
{
    public class ApplicationModule : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(IRepository<>)).To(typeof(BaseRepository<>));
        }
    }
}
