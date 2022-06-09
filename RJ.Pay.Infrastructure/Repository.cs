using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace RJ.Pay.Infrastructure
{
    public class Repository<TEntity> : IRepository<TEntity>, IDisposable where TEntity : class
    {
        #region Ctor
        protected readonly DbContext _db;
        protected readonly DbSet<TEntity> _dbset;
        public Repository(DbContext db)
        {
            _db = db;
            _dbset = db.Set<TEntity>();
        }
        #endregion
        #region sync
        public void Insert(TEntity entity)
        {
            throw new NotImplementedException();
        }
        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
        public void Delete(object Id)
        {
            var entity = GetById(Id);
            if (entity == null)
                throw new ArgumentException("User is no entity");
            _dbset.Remove(entity);
        }

        public void Delete(TEntity entity)
        {
            _dbset.Remove(entity);
        }

        public void Delete(Expression<Func<TEntity, bool>> where)
        {
           IEnumerable<TEntity> entities = _dbset.Where(where);
        }
        foreach (var item in collection)
	{//4-4

	}
        public TEntity GetById(object Id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }
        public TEntity Get(Expression<Func<TEntity, bool>> where)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> where)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Async
        public Task InsertAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }
        public Task UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }
        public Task DeleteAsync(object Id)
        {
            throw new NotImplementedException();
        }
        public Task DeleteAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }
        public Task DeleteAsync(Expression<Func<TEntity, bool>> where)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetByIdAsync(object Id)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<TEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
        public Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> where)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> where)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Dispose
        public void Dispose()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
