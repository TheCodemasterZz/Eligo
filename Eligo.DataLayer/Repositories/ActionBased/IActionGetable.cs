using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eligo.DataLayer.Repositories.ActionBased
{
    public interface IActionGetable<KeyType, ObjectType>
    {
        IQueryable<ObjectType> Get(KeyType id);
        IQueryable<ObjectType> Get(KeyType id, DateTime date);
    }
}
