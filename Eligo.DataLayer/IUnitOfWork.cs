    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eligo.DataLayer
{
    public interface IUnitOfWork
    {
        void Commit();
        void Dispose();
        void Dispose(bool disposing);
        IBaseRepository<KeyType, ObjectType> Repository<KeyType, ObjectType>()
           where KeyType : struct
           where ObjectType : class;
        IBaseRepository<KeyType, ObjectType> Repository<KeyType, ObjectType, RepositoryType>()
           where RepositoryType : class
           where KeyType : struct
           where ObjectType : class;
    }
}
