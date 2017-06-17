using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eligo.CrossCutting.TypeAdapting
{
    public interface ITypeProvider
    {
        TTarget Adapt<TSource, TTarget>(TSource source) where TTarget : class, new() where TSource : class;
        TTarget Adapt<TTarget>(object source) where TTarget : class;
    }
}
