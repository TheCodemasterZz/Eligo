using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Eligo.CrossCutting.TypeAdapting
{
    public static class TypeFactory
    {
        static ITypeFactory _currentTypeFactory = null;

        public static void SetCurrent(ITypeFactory typeFactory)
        {
            _currentTypeFactory = typeFactory;
        }

        public static ITypeProvider Create()
        {
            return (_currentTypeFactory != null) ? _currentTypeFactory.Create() : null;
        }
    }
}
