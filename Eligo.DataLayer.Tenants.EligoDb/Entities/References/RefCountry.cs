using System;
using System.Collections.Generic;

namespace Eligo.DataLayer.Tenants.EligoDb.Entities.References
{
    public class RefCountry : Entity
    {
        public string Name { get; set; }
        public string Code { get; set; }

        public RefCountry()
        {
        }

        public RefCountry(string name, string code)
        {
            Name = name;
            Code = code;
        }
    }
}