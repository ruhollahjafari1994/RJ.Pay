﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MadPay724.Data.Dtos.Common.Token;
using MadPay724.Data.Models;
using MadPay724.Data.Models.MainDB;
using Microsoft.AspNetCore.Http;

namespace MadPay724.Common.Helpers.Interface
{
    public interface IUtilities
    {
        string RemoveHtmlXss(string html);
        Task<string> GetDomainIpAsync(string domain);

        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);

        bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);
        Task<TokenResponseDto> GenerateNewTokenAsync(TokenRequestDto tokenRequestDto,bool needPassword);
        Task<TokenResponseDto> CreateAccessTokenAsync(User user, string refreshToken);
        Token CreateRefreshToken(string clientId, string userId, bool isRemember);

        Task<TokenResponseDto> RefreshAccessTokenAsync(TokenRequestDto tokenRequestDto);

        string FindLocalPathFromUrl(string url);
        bool IsFile(IFormFile file);


    }
}
