using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eligo.CrossCutting.TypeAdapting.AutoMapper
{
    public class AutoMapperFactory : ITypeFactory
    {
        public ITypeProvider Create()
        {
            return new AutoMapperProvider();
        }
    }
}
