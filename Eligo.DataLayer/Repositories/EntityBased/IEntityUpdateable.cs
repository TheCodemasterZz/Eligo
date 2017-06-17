using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eligo.DataLayer.Repositories.EntityBased
{
    public interface IEntityUpdateable<KeyType>
    {
        bool IsModified { get; set; }
        KeyType UserIdModifiedBy { get; set; }
        DateTime ModifiedAt { get; set; }
    }
}
