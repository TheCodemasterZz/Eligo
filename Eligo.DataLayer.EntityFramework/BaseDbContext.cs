using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eligo.DataLayer.EntityFramework
{
    public class BaseDbContext: DbContext
    {
        public BaseDbContext(string ConnectionStringName)
            : base(ConnectionStringName)
        {
        }
        
        protected override bool ShouldValidateEntity(DbEntityEntry entityEntry)
        {
            return base.ShouldValidateEntity(entityEntry);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var addMethod = typeof(ConfigurationRegistrar)
              .GetMethods()
              .Single(m =>  m.Name == "Add" && m.GetGenericArguments()
              .Any(a => a.Name == "TEntityType"));

            foreach (var assembly in AppDomain.CurrentDomain
              .GetAssemblies()
              .Where(a => a.GetName().Name != "EntityFramework"))
            {
                var configTypes = assembly
                  .GetTypes()
                  .Where(t => t.BaseType != null && t.BaseType.IsGenericType && t.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));

                foreach (var type in configTypes)
                {
                    var entityType = type.BaseType.GetGenericArguments().Single();

                    var entityConfig = assembly.CreateInstance(type.FullName);
                    addMethod.MakeGenericMethod(entityType)
                      .Invoke(modelBuilder.Configurations, new object[] { entityConfig });
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
