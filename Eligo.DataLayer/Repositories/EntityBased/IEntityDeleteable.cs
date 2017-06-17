using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eligo.DataLayer.Repositories.EntityBased
{
    public interface IEntityDeleteable<KeyType>
    {
        bool IsDeleted { get; set; }
        KeyType UserIdDeletedBy { get; set; }
        DateTime DeletedAt { get; set; }
    }
}
