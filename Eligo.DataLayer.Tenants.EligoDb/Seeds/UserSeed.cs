using Eligo.DataLayer.Tenants.EligoDb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eligo.DataLayer.Tenants.EligoDb.Seeds
{
    public class UserSeed
    {
        public static bool CanExecute(EligoDbContext context)
        {
            return !context.UserTbl.Any();
        }

        public static void Seed(EligoDbContext context)
        {
            if (!CanExecute(context))
                return;

            var user = new User()
            {
                EmailAddress = "thecodemasterzz@gmail.com",
                FirstName = "Baris",
                LastName = "Kalaycioglu",
                DateOfBirth = DateTime.Now,
                RefCityIDPlaceOfBirth = context.RefCityTbl.First(c => c.Name == "Ankara").ID,
                RefCountryIDPlaceOfBirth = context.RefCountryTbl.First(c => c.Name == "Turkey").ID,
            };

            context.UserTbl.Add(user);
        }
    }
}
