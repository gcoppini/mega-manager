using System.Data.Entity.ModelConfiguration;
using MegaManager.Domain.Main;

namespace MegaManager.Data.Main.Map
{
    public class PrevisaoMap : EntityTypeConfiguration<Previsao>
    {
        public PrevisaoMap()
        {
            HasKey(x => x.Id);

            Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Previsao");
            });
            
        }
    }
}
