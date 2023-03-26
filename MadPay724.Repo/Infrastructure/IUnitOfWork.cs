﻿using MadPay724.Repo.Repositories.FinancialDB.Interface;
using MadPay724.Repo.Repositories.MainDB.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace MadPay724.Repo.Infrastructure
{
    public interface IUnitOfWork<TContext> : IDisposable where TContext:DbContext
    {
        IUserRepository UserRepository { get;}
        IPhotoRepository PhotoRepository { get;}
        ISettingRepository SettingRepository { get; }
        IRoleRepository RoleRepository { get; }
        ITokenRepository TokenRepository { get; }
        INotificationRepository NotificationRepository { get; }
        IBankCardRepository BankCardRepository { get; }
        IDocumentRepository DocumentRepository { get; }
        IWalletRepository WalletRepository { get; }
        ITicketRepository TicketRepository { get; }
        ITicketContentRepository TicketContentRepository { get; }
        IGateRepository GateRepository { get; }
        IEasyPayRepository EasyPayRepository { get; }
        IBlogRepository BlogRepository { get; }
        IBlogGroupRepository BlogGroupRepository { get; }
        IEntryRepository EntryRepository { get; }
        IFactorRepository FactorRepository { get; }
        IVerificationCodeRepository VerificationCodeRepository { get; }
        bool Save();
        Task<bool> SaveAsync();

    }
}
