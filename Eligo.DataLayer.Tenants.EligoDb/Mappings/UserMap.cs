using Eligo.DataLayer.Repositories.EntityBased;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eligo.DataLayer.Tenants.EligoDb.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eligo.DataLayer.Tenants.EligoDb.Configurations
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            Property(p => p.EmailAddress)
                .IsRequired()
                .HasMaxLength(100);

            Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(100);

            Property(p => p.MobilePhoneNumber)
                .HasMaxLength(25);

            HasRequired(e => e.RefCityPlaceOfBirth)
                .WithMany()
                .HasForeignKey(e => e.RefCityIDPlaceOfBirth)
                .WillCascadeOnDelete(false);

            HasRequired(e => e.RefCountryPlaceOfBirth)
                .WithMany()
                .HasForeignKey(e => e.RefCountryIDPlaceOfBirth)
                .WillCascadeOnDelete(false);
        }
    }
}
