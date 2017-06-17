using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eligo.CrossCutting.TypeAdapting.AutoMapper
{
    public class AutoMapperProvider : ITypeProvider
    {
        public TTarget Adapt<TSource, TTarget>(TSource source)
            where TSource : class
            where TTarget : class, new()
        {
            return Mapper.Map<TSource, TTarget>(source);
        }

        public TTarget Adapt<TTarget>(object source) where TTarget : class
        {
            return Mapper.Map<TTarget>(source);
        }
    }
}
