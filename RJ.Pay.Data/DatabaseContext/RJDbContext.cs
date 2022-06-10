using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ.Pay.Data.DatabaseContext
{
    public class RJDbContext : DbContext
    {
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=GEEK\MASTER;Initial Catalog=RJPayDB;Integrated Security=True;MultipleActiveResultSets=True");


        }
        public DbSet<Models.User> Users { get; set; }
        public DbSet<Models.Photo> Photos { get; set; }
        public DbSet<Models.BankCard> BankCards { get; set; }
    }
}
