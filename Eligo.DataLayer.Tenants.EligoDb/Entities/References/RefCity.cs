using System;

namespace Eligo.DataLayer.Tenants.EligoDb.Entities.References
{
    public class RefCity : Entity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int RefCountryID { get; set; }
        public virtual RefCountry RefCountry { get; set; }

        public RefCity()
        {
        }

        public RefCity(string name, string code, RefCountry country)
        {
            Name = name;
            Code = code;
            RefCountry = country;
        }
    }
}