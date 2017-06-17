using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eligo.DataLayer.Tenants.EligoDb.Entities
{
    public class Entity : BaseEntity<Int32>
    {
        public Entity()
        {
            CreatedAt = DateTime.Now;
            DeletedAt = DateTime.Now;
            ModifiedAt = DateTime.Now;
            VersionedAt = DateTime.Now;
            UserIdCreatedBy = 1;
            UserIdDeletedBy = 1;
            UserIdModifiedBy = 1;
            IsDeleted = false;
            IsModified = false;
            IsMasterRecord = true;
            MasterRecordID = 0;
            VersionNumber = 1;
        }
    }
}
