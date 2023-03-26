﻿using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MadPay724.Common.Helpers.Utilities.Extensions;
using MadPay724.Data.DatabaseContext;
using MadPay724.Data.Dtos.Common.Pagination;
using MadPay724.Data.Dtos.Site.Panel.Gate;
using MadPay724.Common.Routes.V1.Site;
using MadPay724.Repo.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MadPay724.Presentation.Controllers.V1.Panel.Accountant
{
    [ApiVersion("1")]
    [Route("api/v{v:apiVersion}")]
    [ApiExplorerSettings(GroupName = "v1_Site_Panel_Accountant")]
    [ApiController]
    public class GatesController : ControllerBase
    {
        private readonly IUnitOfWork<Main_MadPayDbContext> _db;
        private readonly IMapper _mapper;
        private readonly ILogger<GatesController> _logger;



        public GatesController(IUnitOfWork<Main_MadPayDbContext> dbContext,
            IMapper mapper,
            ILogger<GatesController> logger)
        {
            _db = dbContext;
            _mapper = mapper;
            _logger = logger;
        }



        [Authorize(Policy = "AccessAccounting")]
        [HttpGet(SiteV1Routes.Accountant.GetWalletGates)]
        public async Task<IActionResult> GetWalletGates(string walletId, [FromQuery]PaginationDto paginationDto)
        {
            var gatesFromRepo = await _db.GateRepository
                 .GetAllPagedListAsync(
                 paginationDto,
                 paginationDto.Filter.ToGateExpression(true, walletId),
                 paginationDto.SortHe.ToOrderBy(paginationDto.SortDir),
                 "");

            Response.AddPagination(gatesFromRepo.CurrentPage, gatesFromRepo.PageSize,
                gatesFromRepo.TotalCount, gatesFromRepo.TotalPage);

            var gates = _mapper.Map<List<GateForReturnDto>>(gatesFromRepo);


            return Ok(gates);
        }
        [Authorize(Policy = "AccessAccounting")]
        [HttpGet(SiteV1Routes.Accountant.GetGates)]
        public async Task<IActionResult> GetGates([FromQuery]PaginationDto paginationDto)
        {
            var gatesFromRepo = await _db.GateRepository
                 .GetAllPagedListAsync(
                 paginationDto,
                 paginationDto.Filter.ToGateExpression(false),
                 paginationDto.SortHe.ToOrderBy(paginationDto.SortDir),
                 "");

            Response.AddPagination(gatesFromRepo.CurrentPage, gatesFromRepo.PageSize,
                gatesFromRepo.TotalCount, gatesFromRepo.TotalPage);

            var gates = _mapper.Map<List<GateForReturnDto>>(gatesFromRepo);


            return Ok(gates);
        }



        [Authorize(Policy = "AccessAccounting")]
        [HttpPatch(SiteV1Routes.Accountant.ChangeActiveGate)]
        public async Task<IActionResult> ChangeActiveGate(string gateId, GateStatusDto gateStatusDto)
        {
            var gateFromRepo = await _db.GateRepository.GetByIdAsync(gateId);
            if (gateFromRepo != null)
            {
                gateFromRepo.IsActive = gateStatusDto.Flag;
                _db.GateRepository.Update(gateFromRepo);
                if (await _db.SaveAsync())
                    return NoContent();
                else
                    return BadRequest("خطا در ثبت اطلاعات");
            }
            {
                return BadRequest("درگاهی وجود ندارد");
            }
        }
        [Authorize(Policy = "AccessAccounting")]
        [HttpPatch(SiteV1Routes.Accountant.ChangeDirectGate)]
        public async Task<IActionResult> ChangeDirectGate(string gateId, GateStatusDto gateStatusDto)
        {
            var gateFromRepo = await _db.GateRepository.GetByIdAsync(gateId);
            if (gateFromRepo != null)
            {
                gateFromRepo.IsDirect = gateStatusDto.Flag;
                _db.GateRepository.Update(gateFromRepo);
                if (await _db.SaveAsync())
                    return NoContent();
                else
                    return BadRequest("خطا در ثبت اطلاعات");
            }
            {
                return BadRequest("درگاهی وجود ندارد");
            }
        }
        [Authorize(Policy = "AccessAccounting")]
        [HttpPatch(SiteV1Routes.Accountant.ChangeIpGate)]
        public async Task<IActionResult> ChangeIpGate(string gateId, GateStatusDto gateStatusDto)
        {
            var gateFromRepo = await _db.GateRepository.GetByIdAsync(gateId);
            if (gateFromRepo != null)
            {
                gateFromRepo.IsIp = gateStatusDto.Flag;
                _db.GateRepository.Update(gateFromRepo);
                if (await _db.SaveAsync())
                    return NoContent();
                else
                    return BadRequest("خطا در ثبت اطلاعات");
            }
            {
                return BadRequest("درگاهی وجود ندارد");
            }
        }
    }
}