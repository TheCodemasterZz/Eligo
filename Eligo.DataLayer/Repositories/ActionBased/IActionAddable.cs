using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eligo.DataLayer.Repositories.ActionBased
{
    public interface IActionAddable<ObjectType>
    {
        ObjectType Add(ObjectType entity);

        bool AddRange(IEnumerable<ObjectType> entities);
    }
}
