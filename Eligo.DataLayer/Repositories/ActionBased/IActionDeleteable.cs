using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Eligo.DataLayer.Repositories.ActionBased
{
    public interface IActionDeleteable<KeyType, ObjectType>
    {
        bool Delete(KeyType id);
        bool Delete(ObjectType entity);

        bool DeleteRange(IEnumerable<ObjectType> entities);
    }
}
