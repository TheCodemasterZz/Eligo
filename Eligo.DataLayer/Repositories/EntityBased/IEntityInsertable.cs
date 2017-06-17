using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eligo.DataLayer.Repositories.EntityBased
{
    public interface IEntityCreateable<KeyType>
    {
        KeyType UserIdCreatedBy { get; set; }
        DateTime CreatedAt { get; set; }
    }
}
