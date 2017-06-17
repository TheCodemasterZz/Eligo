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
    public class RefCitySeed : BaseSeed
    {
        public static bool CanExecute(EligoDbContext context)
        {
            return context.RefCountryTbl.Any() && !context.RefCityTbl.Any();
        }

        public static void Seed(EligoDbContext context)
        {
            if (!CanExecute(context))
            {
                return;
            }

            foreach (var line in ParseCsv(EligoDbResources.RefCity))
            {
                var cityCode = line[0];
                var cityName = line[1];
                var countryCode = line[2];
                var country = context.RefCountryTbl.First(c => c.Code == countryCode);
                context.RefCityTbl.Add(new RefCity(cityName, cityCode, country));
            }
        }
    }
}
