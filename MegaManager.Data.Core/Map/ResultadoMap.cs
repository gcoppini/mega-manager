using System.Data.Entity.ModelConfiguration;
using MegaManager.Domain.Main;

namespace MegaManager.Data.Main.Map
{
    public class ResultadoMap : EntityTypeConfiguration<Resultado>
    {
        public ResultadoMap()
        {
            HasKey(x => x.Id);
            ToTable("Resultado");
        }
    }
}
