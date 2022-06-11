using Microsoft.EntityFrameworkCore;
using RJ.Pay.Data.Repositories.Interface;
using RJ.Pay.Data.Repositories.Repo;

namespace RJ.Pay.Infrastructure
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext> where TContext : DbContext, new()
    {
        #region Ctor
        protected readonly DbContext _db;
        public UnitOfWork()
        {
            _db = new TContext();
        }
        #endregion

        #region PrivateRepository
        private IUserRepository userRepository;
        public IUserRepository UserRepository
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(_db);
                return userRepository;
            }
        }
        #endregion

        #region Save 
        public void Save()
        {
            _db.SaveChanges();
        }
        public Task<int> SaveAsync()
        {
            return _db.SaveChangesAsync();
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
        ~UnitOfWork()
        {
            Dispose(false);
        }
        #endregion
    }
}
