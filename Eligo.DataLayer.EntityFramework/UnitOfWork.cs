using Eligo.DataLayer.Exceptions;
using Eligo.DataLayer.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Eligo.DataLayer.EntityFramework
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext _context;
        private bool _disposed;
        private Hashtable _repositories;

        public UnitOfWork(DbContext context)
        {
            _context = context;
            _repositories = new Hashtable();
        }

        public void Commit()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                var innerEx = e.InnerException;

                while (innerEx?.InnerException != null)
                    innerEx = innerEx.InnerException;

                SqlException ex = innerEx as SqlException;
                if (ex != null)
                {
                    var sqlEx = ex;
                    switch (sqlEx.Errors[0].Number)
                    {
                        case 547:
                            throw new ForeignKeyViolationException(sqlEx.Errors[0].Message);
                        case 2601:
                            throw new PrimaryKeyViolationException(sqlEx.Errors[0].Message);
                        case 2627:
                            throw new UniqueKeyViolationException(sqlEx.Errors[0].Message);
                        default:
                            throw new Exception(sqlEx.Message.ToString());
                    }
                }
                else
                {
                    throw;
                }
            }
            catch (DbEntityValidationException e)
            {
                var sb = new StringBuilder();
                foreach (var entry in e.EntityValidationErrors)
                {
                    foreach (var error in entry.ValidationErrors)
                    {
                        sb.AppendLine($"{entry.Entry.Entity}-{error.PropertyName}-{error.ErrorMessage}");
                    }
                }
                throw new Exception(sb.ToString());
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
                if (disposing)
                    _context.Dispose();
            _disposed = true;
        }

        public IBaseRepository<KeyType, ObjectType> Repository<KeyType, ObjectType>()
            where KeyType : struct
            where ObjectType : class
        {
            return Repository<KeyType, ObjectType, BaseRepository<KeyType, ObjectType>>();
        }


        public IBaseRepository<KeyType, ObjectType> Repository<KeyType, ObjectType, RepositoryType>()
            where RepositoryType : class
            where KeyType : struct
            where ObjectType : class
        {
            var objectType = typeof(ObjectType).FullName;

            if (!_repositories.ContainsKey(objectType))
            {
                var repositoryType = typeof(RepositoryType);
                var repositoryInstance = Activator.CreateInstance(repositoryType, _context);
                _repositories.Add(objectType, repositoryInstance);
            }
            return _repositories[objectType] as IBaseRepository<KeyType, ObjectType>;
        }
    }
}
