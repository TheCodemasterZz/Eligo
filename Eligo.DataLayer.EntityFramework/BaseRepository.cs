using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Eligo.DataLayer.Repositories.ActionBased;

namespace Eligo.DataLayer.EntityFramework
{
    public class BaseRepository<KeyType, ObjectType> 
        : IBaseRepository<KeyType, ObjectType>
            where KeyType : struct
            where ObjectType : class
    {
        private DbContext _context;
        private DbSet<ObjectType> _dbSet;

        public BaseRepository(DbContext context)
        {
            this._context = context;
            this._dbSet = context.Set<ObjectType>();
        }

        public virtual bool Delete(ObjectType entity)
        {
            try
            {
                if (_context.Entry(entity).State == EntityState.Detached)
                {
                    _dbSet.Attach(entity);
                }
                _dbSet.Remove(entity);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public virtual bool Delete(KeyType id)
        {
            try
            {
                var entity = Get(id);
                Delete(entity.FirstOrDefault());
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public virtual IQueryable<ObjectType> Find(Expression<Func<ObjectType, bool>> pregs)
        {
            return _dbSet;
        }

        public virtual IQueryable<ObjectType> Find(Expression<Func<ObjectType, bool>> pregs, DateTime date)
        {
            throw new NotImplementedException();
        }


        public virtual IQueryable<ObjectType> Get(KeyType id)
        {
            IQueryable<ObjectType> query = _dbSet;
            var param = Expression.Parameter(typeof(ObjectType));
            var lambda = Expression.Lambda<Func<ObjectType, bool>>(
                    Expression.Equal(Expression.Property(param, "ID"), Expression.Constant(id)), param);
            return query.Where(lambda);
        }

        public virtual IQueryable<ObjectType> Get(KeyType id, DateTime date)
        {
            throw new NotImplementedException();
        }

        public virtual ObjectType Add(ObjectType entity)
        {
            return _dbSet.Add(entity);
        }

        public virtual ObjectType Update(ObjectType entity)
        {
            var dbEntityEntry = _context.Entry(entity);
            if (dbEntityEntry.State != EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            dbEntityEntry.State = EntityState.Modified;
            return dbEntityEntry.Entity;
        }

        public virtual IEnumerable<ObjectType> UpdateRange(IEnumerable<ObjectType> entities)
        {
            foreach (var entity in entities)
            {
                if (_context.Entry(entity).State == EntityState.Detached)
                {
                    _dbSet.Attach(entity);
                }
                _context.Entry(entity).State = EntityState.Modified;
            }
            return entities;
        }

        public virtual bool DeleteRange(IEnumerable<ObjectType> entities)
        {
            try
            {
                foreach (var item in entities.Where(en => _context.Entry(en).State == EntityState.Detached))
                    _dbSet.Attach(item);
                _dbSet.RemoveRange(entities);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public virtual bool AddRange(IEnumerable<ObjectType> entities)
        {
            throw new NotImplementedException();
        }
    }
}
