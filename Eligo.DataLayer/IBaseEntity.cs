using Eligo.DataLayer.Repositories.EntityBased;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eligo.DataLayer
{
    public interface IBaseEntity<KeyType>
    {
        KeyType ID { get; set; }
    }
}
