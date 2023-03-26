﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using MadPay724.Common.Helpers.Utilities;
using MadPay724.Data.DatabaseContext;
using MadPay724.Data.Dtos.Site.Panel.EasyPay;
using MadPay724.Data.Dtos.Site.Panel.Gate;
using MadPay724.Data.Dtos.Site.Panel.Wallet;
using MadPay724.Data.Models.MainDB.UserModel;
using MadPay724.Presentation.Helpers.Filters;
using MadPay724.Common.Routes.V1.Site;
using MadPay724.Repo.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MadPay724.Presentation.Controllers.V1.Panel.Admin
{
    [ApiVersion("1")]
    [Route("api/v{v:apiVersion}")]
    [ApiExplorerSettings(GroupName = "v1_Site_Panel_Admin")]
    [ApiController]
    public class EasyPaysController : ControllerBase
    {
        private readonly IUnitOfWork<Main_MadPayDbContext> _db;
        private readonly IMapper _mapper;
        private readonly ILogger<EasyPaysController> _logger;

        public EasyPaysController(IUnitOfWork<Main_MadPayDbContext> dbContext, IMapper mapper,
            ILogger<EasyPaysController> logger)
        {
            _db = dbContext;
            _mapper = mapper;
            _logger = logger;
        }


        [Authorize(Policy = "RequireAdminRole")]
        [HttpGet(SiteV1Routes.AdminEasyPay.GetEasyPays)]
        public async Task<IActionResult> GetEasyPays(string userId)
        {
            var easyPaysFromRepo = await _db.EasyPayRepository
                .GetManyAsync(p => p.UserId == userId, s => s.OrderByDescending(x => x.DateModified), "");

            var bankcards = _mapper.Map<List<EasyPayForReturnDto>>(easyPaysFromRepo);

            return Ok(bankcards);
        }

        [Authorize(Policy = "RequireAdminRole")]
        [HttpGet(SiteV1Routes.AdminEasyPay.GetEasyPay)]
        public async Task<IActionResult> GetEasyPay(string easypayId)
        {
            var easyPayFromRepo = await _db.EasyPayRepository.GetByIdAsync(easypayId);
            if (easyPayFromRepo != null)
            {
                var easyPay = _mapper.Map<EasyPayForReturnDto>(easyPayFromRepo);

                return Ok(easyPay);
            }
            else
            {
                return BadRequest("ایزی پیی وجود ندارد");
            }

        }
        [Authorize(Policy = "RequireAdminRole")]
        [HttpDelete(SiteV1Routes.AdminEasyPay.DeleteEasyPay)]
        public async Task<IActionResult> DeleteEasyPay(string easypayId)
        {
            var easyPayFromRepo = await _db.EasyPayRepository.GetByIdAsync(easypayId);
            if (easyPayFromRepo != null)
            {
                _db.EasyPayRepository.Delete(easyPayFromRepo);

                if (await _db.SaveAsync())
                    return NoContent();
                else
                    return BadRequest("خطا در حذف اطلاعات");
            }
            else
            {
                return BadRequest("ایزی پیی وجود ندارد");
            }
        }
    }
}