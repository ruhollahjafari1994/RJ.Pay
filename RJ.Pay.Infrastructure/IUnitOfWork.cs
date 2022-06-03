using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ.Pay.Infrastructure
{
    public interface IUnitOfWork<TContext>:IDisposable where TContext :DbContext
    {
        void Save();
        Task<int> SaveAsync();
    }
}
