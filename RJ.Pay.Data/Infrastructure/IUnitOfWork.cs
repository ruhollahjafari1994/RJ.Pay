using Microsoft.EntityFrameworkCore;
using RJ.Pay.Data.Repositories.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ.Pay.Infrastructure
{
    public interface IUnitOfWork<TContext> : IDisposable where TContext : DbContext
    {
        UserRepository UserRepository { get; }
        void Save();
        Task<int> SaveAsync();
    }
}
