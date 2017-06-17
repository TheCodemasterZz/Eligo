using Eligo.DataLayer.EntityFramework;
using Eligo.DataLayer.Tenants.EligoDb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Eligo.DataLayer.Tenants.EligoDb.Repositories
{
    class UserReporsitory : BaseRepository<Int32, User>
    {
        private DbContext _context;
        private DbSet<User> _dbSet;

        public UserReporsitory(DbContext context) : base(context)
        {
            this._context = context;
            this._dbSet = context.Set<User>();
        }

        public virtual IQueryable<User> GetByFirstAndLastName(string firstName, string lastName)
        {
            return _dbSet.Where(x => x.FirstName == firstName && x.LastName == lastName);
        }
    }
}
