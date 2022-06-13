using Microsoft.AspNetCore.Mvc;
using RJ.Pay.Data.DatabaseContext;
using RJ.Pay.Data.Models;
using RJ.Pay.Repo;
using RJ.Pay.Services.Auth.Interface;
using RJ.Pay.Services.Auth.Repo;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RJ.Pay.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IUnitOfWork<RJDbContext> _db;
        private readonly IAuthService _authService;
        public ValuesController(IUnitOfWork<RJDbContext> dbContext, IAuthService authService)
        {
            _db = dbContext;
            _authService = authService;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Get()
        {
            var user = new User()
            {
                Address = "",
                City = "",
                IsActive = true,
                Gender = "",
                DateOfBirth = "",
                Name = "",
                PasswordHash = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 },
                PasswordSalt = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 },
                PhoneNumber = "",
                Status = true,
                UserName = ""
            };
         

            var u = await _authService.Register(user,"");
            return Ok(u);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
