﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MegaManager.Data.Main.Map;
using MegaManager.Domain.Main;

namespace MegaManager.Data.Main
{
    public class DataContext : DbContext
    {
             public DataContext() : base("DataContext")
             {
                  Configuration.LazyLoadingEnabled = false;
                  Configuration.ProxyCreationEnabled = false;
             }

             public DbSet<Gabarito> Gabaritos { get; set; }
             public DbSet<Resultado> Resultados { get; set; }
             public DbSet<Previsao> Previsoes { get; set; }


             protected override void OnModelCreating(DbModelBuilder modelBuilder)
             {
                 modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
                 modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
                 modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
                        

                 modelBuilder.Properties()
                        .Where(p => p.Name == "Id") //p.ReflectedType.Name
                        .Configure(p => p.IsKey());

                 modelBuilder.Properties()
                        .Where(p => p.Name == "Id")
                        .Configure(p => p.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity));

                 modelBuilder.Properties<string>()
                        .Configure(p => p.HasColumnType("varchar"));

                 modelBuilder.Properties<string>()
                       .Configure(p => p.HasMaxLength(255));

                 modelBuilder.Configurations.Add(new GabaritoMap());
                 modelBuilder.Configurations.Add(new ResultadoMap());
                 modelBuilder.Configurations.Add(new PrevisaoMap());
             }
    }
}

