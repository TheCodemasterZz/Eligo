using Eligo.DataLayer.EntityFramework;
using Eligo.DataLayer.Tenants.EligoDb.Entities.References;
using Eligo.DataLayer.Tenants.EligoDb.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eligo.DataLayer.Tenants.EligoDb.Seeds.References
{
    public class RefCountrySeed : BaseSeed
    {
        public static bool CanExecute(EligoDbContext context)
        {
            return !context.RefCountryTbl.Any();
        }

        public static void Seed(EligoDbContext context)
        {
            if (!CanExecute(context))
                return;

            foreach (var line in ParseCsv(EligoDbResources.RefCountry))
            {
                var countryCode = line[0];
                var countryName = line[1];
                context.RefCountryTbl.Add(new RefCountry(countryName, countryCode));
            }
        }
    }
}
