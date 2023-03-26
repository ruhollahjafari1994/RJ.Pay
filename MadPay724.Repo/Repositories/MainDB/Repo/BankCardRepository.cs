﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MadPay724.Data.DatabaseContext;
using MadPay724.Data.Models;
using MadPay724.Data.Models.MainDB;
using MadPay724.Repo.Infrastructure;
using MadPay724.Repo.Repositories.MainDB.Interface;
using Microsoft.EntityFrameworkCore;

namespace MadPay724.Repo.Repositories.MainDB.Repo
{
  public  class BankCardRepository : Repository<BankCard>, IBankCardRepository
    {
        private readonly DbContext _db;
        public BankCardRepository(DbContext dbContext) : base(dbContext)
        {
            _db ??= (Main_MadPayDbContext)dbContext;
        }

        public async Task<int> BankCardCountAsync(string userId)
        {
           return (await GetManyAsync(p => p.Id == userId, null, "")).Count();
        }
    }
}
