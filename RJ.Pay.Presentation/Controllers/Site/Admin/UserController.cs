using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RJ.Pay.Common.Helpers;
using RJ.Pay.Data.DatabaseContext;
using RJ.Pay.Data.Models;
using RJ.Pay.Data.ViewModels.Site.Admin;
using RJ.Pay.Repo;
using RJ.Pay.Services.Site.Admin.Auth.Interface;

namespace RJ.Pay.Presentation.Controllers.Site.Admin
{
    [Authorize]
    [Route("site/admin/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork<RJDbContext> _db;
        public IConfiguration _configuration { get; }
        public UserController(IUnitOfWork<RJDbContext> dbContext, IAuthService authService, IConfiguration configuration)
        {
            _db = dbContext;
            _configuration = configuration;
        }
        [AllowAnonymous]
        [HttpPost("GetAll")]
        public async Task<ReturnResult<List<User>>> GetAll()
        {

            var users =await _db.UserRepository.GetAllAsync();
            var destObject = users..Adapt<UserVm>();
            return new ReturnResult<List<User>>() {  Success=true, Result=users.ToList() };
        }
    }
}
