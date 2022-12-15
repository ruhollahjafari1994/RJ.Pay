using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ.Pay.Data.DatabaseContext
{
    public class RJDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public RJDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("RJConnectionString"));
        }
        public DbSet<Models.User> Users { get; set; }
        public DbSet<Models.Photo> Photos { get; set; }
        public DbSet<Models.BankCard> BankCards { get; set; }
    }
}
