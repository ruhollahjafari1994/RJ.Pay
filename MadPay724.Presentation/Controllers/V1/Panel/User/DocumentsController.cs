﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using MadPay724.Data.DatabaseContext;
using MadPay724.Data.Dtos.Site.Panel.Document;
using MadPay724.Data.Models.MainDB;
using MadPay724.Presentation.Helpers.Filters;
using MadPay724.Common.Routes.V1.Site;
using MadPay724.Repo.Infrastructure;
using MadPay724.Services.Upload.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MadPay724.Presentation.Controllers.V1.Panel.User
{
    [ApiVersion("1")]
    [Route("api/v{v:apiVersion}")]
    [ApiExplorerSettings(GroupName = "v1_Site_Panel")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private readonly IUnitOfWork<Main_MadPayDbContext> _db;
        private readonly IMapper _mapper;
        private readonly ILogger<DocumentsController> _logger;
        private readonly IUploadService _uploadService;
        private readonly IWebHostEnvironment _env;

        public DocumentsController(IUnitOfWork<Main_MadPayDbContext> dbContext, IMapper mapper,
            ILogger<DocumentsController> logger, IUploadService uploadService,
            IWebHostEnvironment env)
        {
            _db = dbContext;
            _mapper = mapper;
            _logger = logger;
            _uploadService = uploadService;
            _env = env;
        }


        [Authorize(Policy = "RequireUserRole")]
        [HttpPost(SiteV1Routes.Document.AddDocument)]
        public async Task<IActionResult> AddDocument(string userId, [FromForm]DocumentForCreateDto documentForCreateDto)
        {
            var documentFromRepoApprove = await _db.DocumentRepository.GetAsync(p => p.Approve == 1 || p.Approve == 0);
            if (documentFromRepoApprove == null)
            {

               // var file = Request.Form.Files["file"];

                var uploadRes = await _uploadService.UploadFileToLocal(
                    documentForCreateDto.File,
                        userId,
                        _env.WebRootPath,
                        $"{Request.Scheme ?? ""}://{Request.Host.Value ?? ""}{Request.PathBase.Value ?? ""}",
                        "Files\\Documents\\" + DateTime.Now.Year + "\\" + DateTime.Now.Month + "\\" + DateTime.Now.Day
                    );
                if (uploadRes.Status)
                {
                    var documentForCreate = new Document()
                    {
                        UserId = userId,
                        Approve = 0,
                        PicUrl = uploadRes.Url,
                        Message = "بدون پیغام"
                    };
                    var document = _mapper.Map(documentForCreateDto, documentForCreate);

                    await _db.DocumentRepository.InsertAsync(document);

                    if (await _db.SaveAsync())
                    {
                        var documentForReturn = _mapper.Map<DocumentForReturnDto>(document);

                        return CreatedAtRoute("GetDocument", new { v = HttpContext.GetRequestedApiVersion().ToString(), id = document.Id, userId = userId }, documentForReturn);
                    }
                    else
                        return BadRequest("خطا در ثبت اطلاعات");
                }
                else
                {
                    return BadRequest(uploadRes.Message);
                }

            }
            {
                if(documentFromRepoApprove.Approve ==1)
                    return BadRequest("شما مدرک شناسایی تایید شده دارید و نمیتوانید دوباره آنرا ارسال کنید");
                else
                    return BadRequest("مدارک ارسالی قبلیه شما در حال بررسی میباشد");

            }


        }
        [Authorize(Policy = "RequireUserRole")]
        [ServiceFilter(typeof(UserCheckIdFilter))]
        [HttpGet(SiteV1Routes.Document.GetDocuments)]
        public async Task<IActionResult> GetDocuments(string userId)
        {
            var documentsFromRepo = await _db.DocumentRepository
                .GetManyAsync(p => p.UserId == userId, s => s.OrderByDescending(x => x.Approve), "");

            var documents = _mapper.Map<List<DocumentForReturnDto>>(documentsFromRepo);

            return Ok(documents);
        }

        [Authorize(Policy = "RequireUserRole")]
        [ServiceFilter(typeof(UserCheckIdFilter))]
        [HttpGet(SiteV1Routes.Document.GetDocument, Name = "GetDocument")]
        public async Task<IActionResult> GetDocument(string id, string userId)
        {
            var documentFromRepo = await _db.DocumentRepository.GetByIdAsync(id);
            if (documentFromRepo != null)
            {
                if (documentFromRepo.UserId == User.FindFirst(ClaimTypes.NameIdentifier).Value)
                {
                    var document = _mapper.Map<DocumentForReturnDto>(documentFromRepo);

                    return Ok(document);
                }
                else
                {
                    _logger.LogError($"کاربر   {userId} قصد دسترسی به مدرک دیگری را دارد");

                    return BadRequest("شما اجازه دسترسی به مدرک کاربر دیگری را ندارید");
                }
            }
            else
            {
                return BadRequest("مدرکی وجود ندارد");
            }

        }
    }
}