using System.Linq.Expressions;

namespace RJ.Pay.Infrastructure
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Insert(TEntity entity);
        Task InsertAsync(TEntity entity);

        void Update(TEntity entity);

        void Delete(object Id);

        void Delete(TEntity entity);
        

        TEntity GetById(object Id);
        Task<TEntity> GetByIdAsync(object Id);

        IEnumerable<TEntity> GetAll();
        Task<IEnumerable<TEntity>> GetAllAsync();

        TEntity Get(Expression<Func<TEntity, bool>> where);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> where);

        IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> where);
        Task<IEnumerable<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> where);
    }

}
