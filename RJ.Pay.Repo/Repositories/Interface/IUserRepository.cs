using RJ.Pay.Data.Models;
using RJ.Pay.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ.Pay.Repo.Repositories.Interface
{
    public interface IUserRepository : IRepository<User>
    { 
        Task<bool> UserExist(string username); 
    }
}
