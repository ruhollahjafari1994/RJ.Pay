using RJ.Pay.Common.Helpers;
using RJ.Pay.Data.DatabaseContext;
using RJ.Pay.Data.Models;
using RJ.Pay.Repo;
using RJ.Pay.Services.Auth.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ.Pay.Services.Auth.Repo
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork<RJDbContext> _db;
        public AuthService(IUnitOfWork<RJDbContext> dbContext)
        {
            _db = dbContext;
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

            await _db.UserRepository.InsertAsync(user);
            await _db.SaveAsync();
            return user;
        }
    }
}
