using System.Data.Entity.ModelConfiguration;
using MegaManager.Domain.Main;

namespace MegaManager.Data.Main.Map
{
    public class GabaritoMap : EntityTypeConfiguration<Gabarito>
    {
        public GabaritoMap()
        {
            ToTable("Gabarito");
            HasKey(x => x.Id);
        }
    }
}
