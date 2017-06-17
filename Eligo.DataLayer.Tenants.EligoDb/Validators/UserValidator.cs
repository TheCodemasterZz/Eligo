using FluentValidation;
using Eligo.DataLayer.Tenants.EligoDb.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eligo.DataLayer.Tenants.EligoDb.Resources;

namespace Eligo.DataLayer.Tenants.EligoDb.Validators
{
    public sealed class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.EmailAddress).EmailAddress()
                .WithLocalizedMessage(typeof(EligoDbResources), "EmailAddressMustHasAnEmailAddressFormat");
        }
    }
}
