using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RJ.Pay.Data.DatabaseContext;
using RJ.Pay.Data.Dtos.Site.Admin;
using RJ.Pay.Data.Models;
using RJ.Pay.Repo;
using RJ.Pay.Services.Site.Admin.Auth.Interface;

namespace RJ.Pay.Presentation.Controllers.Site.Admin
{
    [Route("site/admin/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork<RJDbContext> _db;
        private readonly IAuthService _authService;
        public AuthController(IUnitOfWork<RJDbContext> dbContext, IAuthService authService)
        {
            _db = dbContext;
            _authService = authService;
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            userForRegisterDto.UserName = userForRegisterDto.UserName.ToLower();
            if (await _db.UserRepository.UserExist(userForRegisterDto.UserName))
                return BadRequest("This Username Exist!");
            var userToCreate = new User()
            {
                UserName = userForRegisterDto.UserName,
                Address = "",
                City = "",
                IsActive = true,
                Gender = true,
                DateOfBirth = DateTime.Now,
                Name = "",
                PhoneNumber = "",
                Status = true
            };
            var createdUser = await _authService.Register(userToCreate, userForRegisterDto.Password);
            return StatusCode(201);
        }


    }
}
