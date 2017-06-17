using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Data.Entity.ModelConfiguration;
using Eligo.DataLayer.EntityFramework;
using Eligo.DataLayer.Tenants.EligoDb.Validators;
using FluentValidation;
using Eligo.DataLayer.Tenants.EligoDb.Entities;
using System.Data.Entity.Design.PluralizationServices;
using System.Data.Entity.ModelConfiguration.Conventions;
using Eligo.DataLayer.Tenants.EligoDb.Entities.References;

namespace Eligo.DataLayer.Tenants.EligoDb
{
    public class EligoDbContext : BaseDbContext
    {
        public EligoDbContext() 
            : base("EligoDbContext") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var service = PluralizationService.CreateService(new System.Globalization.CultureInfo("en-En"));
            modelBuilder.Types().Configure(entity => entity.ToTable(EligoDbConfiguration.TablePrefix + service.Pluralize(entity.ClrType.Name)));
            base.OnModelCreating(modelBuilder);
        }

        protected override bool ShouldValidateEntity(DbEntityEntry entityEntry)
        {
            return base.ShouldValidateEntity(entityEntry);
        }

        protected override DbEntityValidationResult ValidateEntity(DbEntityEntry entityEntry, IDictionary<object, object> items)
        {
            //var validator = new UserValidator();
            //if (validator != null)
            //{
            //    var validationResult = validator.Validate((User)entityEntry.Entity);
            //    var validationErrors =
            //        validationResult.IsValid
            //            ? Enumerable.Empty<DbValidationError>()
            //            : validator.Validate((User)entityEntry.Entity)
            //                .Errors.Select(x => new DbValidationError(x.PropertyName, x.ErrorMessage));

            //    return new DbEntityValidationResult(entityEntry, validationErrors);
            //}

            return base.ValidateEntity(entityEntry, items);
        }

        public DbSet<User> UserTbl { get; set; }
        public DbSet<RefCity> RefCityTbl { get; set; }
        public DbSet<RefCountry> RefCountryTbl { get; set; }
    }
}
