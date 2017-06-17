using Eligo.DataLayer.Repositories.EntityBased;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eligo.DataLayer.Tenants.EligoDb.Entities;
using Eligo.DataLayer.Tenants.EligoDb.Entities.References;

namespace Eligo.DataLayer.Tenants.EligoDb.Configurations.References
{
    public class RefCityMap : EntityTypeConfiguration<RefCity>
    {
        public RefCityMap()
        {
            Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(250);

            HasRequired(e => e.RefCountry)
                .WithMany()
                .HasForeignKey(e => e.RefCountryID)
                .WillCascadeOnDelete(false);
        }
    }
}
