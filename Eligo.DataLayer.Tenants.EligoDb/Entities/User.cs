using Eligo.DataLayer.Tenants.EligoDb.Entities.Enums;
using Eligo.DataLayer.Tenants.EligoDb.Entities.References;
using System;
using System.Collections.Generic;

namespace Eligo.DataLayer.Tenants.EligoDb.Entities
{
    public class User : Entity
    {
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int RefCityIDPlaceOfBirth { get; set; }
        public virtual RefCity RefCityPlaceOfBirth { get; set; }
        public int RefCountryIDPlaceOfBirth { get; set; }
        public virtual RefCity RefCountryPlaceOfBirth { get; set; }
        public string MobilePhoneNumber { get; set; }
        public UserType UserType { get; set; }

        public User()
        {
        }

        public User(string emailAddress, string firstName, string lastName)
        {
            EmailAddress = emailAddress;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
