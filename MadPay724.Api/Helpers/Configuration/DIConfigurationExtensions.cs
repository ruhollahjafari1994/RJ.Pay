﻿using MadPay724.Common.Helpers.Interface;
using MadPay724.Common.Helpers.Utilities;
using MadPay724.Common.OnlineChat.Storage;
using MadPay724.Api.Helpers.Filters;
using MadPay724.Repo.Infrastructure;
using MadPay724.Services.Common;
using MadPay724.Services.Seed.Service;
using MadPay724.Services.Site.Panel.Auth.Interface;
using MadPay724.Services.Site.Panel.Auth.Service;
using MadPay724.Services.Site.Panel.User.Interface;
using MadPay724.Services.Site.Panel.User.Service;
using MadPay724.Services.Site.Panel.Wallet.Interface;
using MadPay724.Services.Site.Panel.Wallet.Service;
using MadPay724.Services.Upload.Interface;
using MadPay724.Services.Upload.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using DnsClient;

namespace MadPay724.Api.Helpers.Configuration
{
    public static class DIConfigurationExtensions
    {
        public static void AddMadDI(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
            //
            services.AddTransient<SeedService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUploadService, UploadService>();
            services.AddScoped<IWalletService, WalletService>();
            services.AddScoped<IUtilities, Utilities>();
            services.AddScoped<ISmsService, SmsService>();
            //
            services.AddSingleton<ILookupClient, LookupClient>();
            //
            services.AddScoped<DocumentApproveFilter>();

            //services.AddScoped<TokenSetting>();

        }
    }
}
