using Eligo.DataLayer.Tenants.EligoDb;
using Eligo.DataLayer.Repositories.EntityBased;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eligo.DataLayer.Tenants.EligoDb
{
    public abstract class BaseEntity<KeyType> :
        IBaseEntity<KeyType>,
        IEntityDeleteable<KeyType>,
        IEntityCreateable<KeyType>,
        IEntityUpdateable<KeyType>,
        IEntityVersionable<KeyType>
    {
        [Key]
        public KeyType ID { get; set; }
        public DateTime CreatedAt { get; set; }
        public KeyType UserIdCreatedBy { get; set; }
        public bool IsModified { get; set; }
        public DateTime ModifiedAt { get; set; }
        public KeyType UserIdModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeletedAt { get; set; }
        public KeyType UserIdDeletedBy { get; set; }
        public bool IsMasterRecord { get; set; }
        public DateTime VersionedAt { get; set; }
        public int VersionNumber { get; set; }
        public KeyType MasterRecordID { get; set; }
    }
}
