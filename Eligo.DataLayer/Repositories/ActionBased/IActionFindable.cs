using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Eligo.DataLayer.Repositories.ActionBased
{
    public interface IActionFindable<ObjectType>
    {
        IQueryable<ObjectType> Find(Expression<Func<ObjectType, bool>> pregs);
        IQueryable<ObjectType> Find(Expression<Func<ObjectType, bool>> pregs, DateTime date);
    }
}
