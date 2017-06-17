using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eligo.DataLayer.Repositories.ActionBased
{
    public interface IActionUpdateable<ObjectType>
    {
        ObjectType Update(ObjectType entity);

        IEnumerable<ObjectType> UpdateRange(IEnumerable<ObjectType> entities);
    }
}
