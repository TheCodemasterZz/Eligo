using FizzWare.NBuilder;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Eligo.DataLayer.Mock
{
    public class MockRepository<KeyType, ObjectType>
        : IBaseRepository<KeyType, ObjectType>
            where KeyType : struct
            where ObjectType : class
    {
        private Random _random;
        private DbContext _context;
        private DbSet<ObjectType> _dbSet;

        public MockRepository(DbContext context)
        {
            this._random = new Random();
            this._context = context;
            this._dbSet = context.Set<ObjectType>();
        }

        public ObjectType Add(ObjectType entity)
        {
            return Builder<ObjectType>.CreateNew().Persist();
        }

        public bool AddRange(IEnumerable<ObjectType> entities)
        {
            return Builder<bool>.CreateNew().Build();
        }

        public bool Delete(ObjectType entity)
        {
            return Builder<bool>.CreateNew().Build();
        }

        public bool Delete(KeyType id)
        {
            return Builder<bool>.CreateNew().Build();
        }

        public bool DeleteRange(IEnumerable<ObjectType> entities)
        {
            return Builder<bool>.CreateNew().Build();
        }

        public IQueryable<ObjectType> Find(Expression<Func<ObjectType, bool>> pregs)
        {
            return Builder<ObjectType>.CreateListOfSize( _random.Next(1,100) ).Build().AsQueryable();
        }

        public IQueryable<ObjectType> Find(Expression<Func<ObjectType, bool>> pregs, DateTime date)
        {
            return Builder<ObjectType>.CreateListOfSize(_random.Next(1, 100)).Build().AsQueryable();
        }

        public IQueryable<ObjectType> Get(KeyType id)
        {
            return Builder<ObjectType>.CreateListOfSize(1).Build().AsQueryable();
        }

        public IQueryable<ObjectType> Get(KeyType id, DateTime date)
        {
            return Builder<ObjectType>.CreateListOfSize(1).Build().AsQueryable();
        }

        public ObjectType Update(ObjectType entity)
        {
            return entity;
        }

        public IEnumerable<ObjectType> UpdateRange(IEnumerable<ObjectType> entities)
        {
            return entities;
        }
    }
}
