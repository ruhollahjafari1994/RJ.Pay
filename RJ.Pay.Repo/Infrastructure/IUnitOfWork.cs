using Microsoft.EntityFrameworkCore; 
using RJ.Pay.Repo.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ.Pay.Repo
{
    public interface IUnitOfWork<TContext> : IDisposable where TContext : DbContext
    {
        IUserRepository UserRepository { get; }
        void Save();
        Task<int> SaveAsync();
    }
}
