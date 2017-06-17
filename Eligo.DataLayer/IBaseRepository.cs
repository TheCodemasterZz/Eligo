using Eligo.DataLayer.Repositories.ActionBased;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eligo.DataLayer
{
    public interface IBaseRepository<KeyType, ObjectType> :
        IActionAddable<ObjectType>,
        IActionGetable<KeyType, ObjectType>,
        IActionUpdateable<ObjectType>,
        IActionDeleteable<KeyType, ObjectType>,
        IActionFindable<ObjectType>
    {
    }
}
