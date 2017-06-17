namespace Eligo.DataLayer.Tenants.EligoDb.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Eligo.DataLayer.Tenants.EligoDb.EligoDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Eligo.DataLayer.Tenants.EligoDb.EligoDbContext context)
        {
            Seeds.References.RefCountrySeed.Seed(context);
            context.SaveChanges();

            Seeds.References.RefCitySeed.Seed(context);
            context.SaveChanges();

            Seeds.UserSeed.Seed(context);
            context.SaveChanges();
        }
    }
}
