using Microsoft.EntityFrameworkCore;
using RJ.Pay.Data.DatabaseContext;
using RJ.Pay.Data.Models;
using RJ.Pay.Repo.Repositories.Interface;
using RJ.Pay.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RJ.Pay.Common.Helpers;

namespace RJ.Pay.Repo.Repositories.Repo
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly DbContext _db;
        public UserRepository(DbContext dbContext) : base(dbContext)
        {
            _db = (_db ?? (RJDbContext)_db);
        }

        public async Task<User> Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<User> Register(User user, string password)
        {
            byte[] passwordHash, passwordSalt;
            Utilities.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await InsertAsync(user);
            await _db.SaveChanges();
            return user;
        }

        public async Task<User> UserExist(User username)
        {
            throw new NotImplementedException();
        }
    }
}
