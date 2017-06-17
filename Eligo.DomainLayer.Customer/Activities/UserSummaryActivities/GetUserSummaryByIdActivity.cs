using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using Eligo.DomainLayer.Customer.Models;
using Eligo.DataLayer.Tenants.EligoDb;
using Eligo.DataLayer.EntityFramework;
using Eligo.DataLayer.Tenants.EligoDb.Entities;
using AutoMapper;
using Eligo.DataLayer.Mock;

namespace Eligo.DomainLayer.Customer.Activies.UserSummaryActivities
{
    public sealed class GetUserSummaryByIdActivity : CodeActivity<UserSummaryDto>
    {
        // Define an activity input argument of type string
        [RequiredArgument]
        public InArgument<Int32> UserId { get; set; }

        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.

        protected override UserSummaryDto Execute(CodeActivityContext context)
        {
            var unitOfWork = new UnitOfWork(new EligoDbContext());

            var userRepo = unitOfWork.Repository<Int32, User, MockRepository<Int32, User>>().Find(null).ToList();

            //var userId = context.GetValue(UserId);

            //var userRepo = unitOfWork.Repository<Int32, User>().Get(userId).FirstOrDefault();

            //if ( userRepo == null )
            //{
            //    throw new KeyNotFoundException();
            //}

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<User, UserSummaryDto>();
            });

            var userSummary = Mapper.Map<UserSummaryDto>(userRepo);

            return userSummary;
        }
    }
}
