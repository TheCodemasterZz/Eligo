using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eligo.DataLayer.Repositories.EntityBased
{
    public interface IEntityVersionable<KeyType>
    {
        bool IsMasterRecord { get; set; }
        DateTime VersionedAt { get; set; }
        int VersionNumber { get; set; }
        KeyType MasterRecordID { get; set; }
    }
}
