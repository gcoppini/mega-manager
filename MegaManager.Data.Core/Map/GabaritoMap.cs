using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
