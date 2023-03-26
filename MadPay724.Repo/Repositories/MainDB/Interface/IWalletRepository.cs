﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MadPay724.Data.Models;
using MadPay724.Data.Models.MainDB;
using MadPay724.Repo.Infrastructure;

namespace MadPay724.Repo.Repositories.MainDB.Interface
{
  public  interface IWalletRepository : IRepository<Wallet>
  {
      Task<int> WalletCountAsync(string userId);
      Task<bool> WalletCodeExistAsync(long code);
      Task<long> GetLastWalletCodeAsync();
  }
}
