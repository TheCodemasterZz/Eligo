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
    public class RefCountryMap : EntityTypeConfiguration<RefCountry>
    {
        public RefCountryMap()
        {
            Property(p => p.Code)
                .IsRequired()
                .HasMaxLength(20);

            Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(150);
        }
    }
}
