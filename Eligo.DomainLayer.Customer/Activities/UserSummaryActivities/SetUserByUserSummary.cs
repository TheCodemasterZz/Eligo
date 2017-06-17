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

namespace Eligo.DomainLayer.Customer.Activies.UserSummaryActivities
{
    public sealed class SetUserByUserSummary : CodeActivity
    {
        // Define an activity input argument of type string
        [RequiredArgument]
        public InArgument<UserSummaryDto> UserSummary { get; set; }

        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.

        protected override void Execute(CodeActivityContext context)
        {
            var userSummary = context.GetValue(UserSummary);

            var unitOfWork = new UnitOfWork(new EligoDbContext());

            Mapper.Initialize(cfg => {
                cfg.CreateMap<UserSummaryDto, User>();
            });

            var userRepo = unitOfWork.Repository<Int32, User>().Get(userSummary.ID);

            var user = Mapper.Map<User>(userSummary);


            unitOfWork.Repository<Int32, User>().Update(user);
        }
    }
}
