using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace RJ.Pay.Repo
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
            if (entity == null)
                throw new ArgumentException("there is no entity");
            _dbset.Add(entity);
        }
        public void Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentException("there is no entity");
            _dbset.Update(entity);
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
            foreach (var item in entities)
            {
                _dbset.Remove(item);
            }
        }

        public TEntity GetById(object Id)
        {
            return _dbset.Find(Id);
        }
        public IEnumerable<TEntity> GetAll()
        {
            return _dbset.AsEnumerable();
        }
        public TEntity Get(Expression<Func<TEntity, bool>> where)
        {
            return _dbset.FirstOrDefault();
        }

        public IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> where)
        {
            return _dbset.Where(where).AsEnumerable();
        }
        #endregion

        #region Async
        public async Task InsertAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentException("there is no entity");
            await _dbset.AddAsync(entity);
        }



        public async Task<TEntity> GetByIdAsync(object Id)
        {
            return await _dbset.FindAsync(Id);
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbset.ToListAsync();
        }
        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> where)
        {
            return await _dbset.Where(where).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> where)
        {
            return await _dbset.Where(where).ToListAsync();
        }
        #endregion

        #region Dispose
        private bool dispose = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!dispose)
            {
                _db.Dispose();
            }
            dispose = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        ~Repository()
        {
            Dispose(false);
        }
        #endregion
    }
}
