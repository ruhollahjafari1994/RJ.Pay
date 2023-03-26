﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MadPay724.Data.DatabaseContext;
using MadPay724.Data.Dtos.Site.Panel.BankCards;
using MadPay724.Data.Models.MainDB;
using MadPay724.Presentation.Controllers.V1.Panel.User;
using MadPay724.Repo.Infrastructure;
using MadPay724.Test.DataInput;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace MadPay724.Test.UnitTests.ControllersTests
{
    public class BankCardsControllerUnitTests
    {
        private readonly Mock<IUnitOfWork<Main_MadPayDbContext>> _mockRepo;
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<ILogger<BankCardsController>> _mockLogger;
        private readonly BankCardsController _controller;

        public BankCardsControllerUnitTests()
        {
            _mockRepo = new Mock<IUnitOfWork<Main_MadPayDbContext>>();
            _mockMapper = new Mock<IMapper>();
            _mockLogger = new Mock<ILogger<BankCardsController>>();
            //_controller = new BankCardsController(_mockRepo.Object, _mockMapper.Object, _mockLogger.Object);
        }

        #region GetBankCardTests
        [Fact]
        public async Task GetBankCard_Success()
        {
            //Arrange------------------------------------------------------------------------------------------------------------------------------
            _mockRepo.Setup(x => x.BankCardRepository.GetByIdAsync(It.IsAny<string>()))
                .ReturnsAsync(UnitTestsDataInput.Users.First().BankCards.First());

            _mockMapper.Setup(x => x.Map<BankCardForReturnDto>(It.IsAny<BankCard>()))
                .Returns(new BankCardForReturnDto());




            var rout = new RouteData();
            rout.Values.Add("userId", UnitTestsDataInput.userLogedInId);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,UnitTestsDataInput.userLogedInId),
            };
            var identity = new ClaimsIdentity(claims);
            var claimsPrincipal = new ClaimsPrincipal(identity);
            var mockContext = new Mock<HttpContext>();

            mockContext.SetupGet(x => x.User).Returns(claimsPrincipal);

            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = mockContext.Object,
                RouteData = rout
            };


            //Act----------------------------------------------------------------------------------------------------------------------------------
            var result = await _controller.GetBankCard(It.IsAny<string>(), It.IsAny<string>());
            var okResult = result as OkObjectResult;
            //Assert-------------------------------------------------------------------------------------------------------------------------------
            Assert.NotNull(okResult);
            Assert.IsType<BankCardForReturnDto>(okResult.Value);
            Assert.Equal(200, okResult.StatusCode);
        }
        [Fact]
        public async Task GetBankCard_Fail_SeeAnOtherOneCard()
        {
            //Arrange------------------------------------------------------------------------------------------------------------------------------
            _mockRepo.Setup(x => x.BankCardRepository.GetByIdAsync(It.IsAny<string>()))
                .ReturnsAsync(UnitTestsDataInput.Users.First().BankCards.First());


            var rout = new RouteData();
            rout.Values.Add("userId", UnitTestsDataInput.userLogedInId);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,UnitTestsDataInput.userAnOtherId),
            };
            var identity = new ClaimsIdentity(claims);
            var claimsPrincipal = new ClaimsPrincipal(identity);
            var mockContext = new Mock<HttpContext>();

            mockContext.SetupGet(x => x.User).Returns(claimsPrincipal);

            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = mockContext.Object,
                RouteData = rout
            };

            //Act----------------------------------------------------------------------------------------------------------------------------------
            var result = await _controller.GetBankCard(It.IsAny<string>(), It.IsAny<string>());
            var okResult = result as BadRequestObjectResult;
            //Assert-------------------------------------------------------------------------------------------------------------------------------
            Assert.NotNull(okResult);
            Assert.IsType<string>(okResult.Value);

            Assert.Equal("شما اجازه دسترسی به کارت کاربر دیگری را ندارید", okResult.Value);
            Assert.Equal(400, okResult.StatusCode);
        }

        [Fact]
        public async Task GetBankCard_Fail_NullBankCard()
        {
            //Arrange------------------------------------------------------------------------------------------------------------------------------
            _mockRepo.Setup(x => x.BankCardRepository.GetByIdAsync(It.IsAny<string>()))
                .ReturnsAsync(It.IsAny<BankCard>());


            //Act----------------------------------------------------------------------------------------------------------------------------------
            var result = await _controller.GetBankCard(It.IsAny<string>(), It.IsAny<string>());
            var okResult = result as BadRequestObjectResult;
            //Assert-------------------------------------------------------------------------------------------------------------------------------
            Assert.NotNull(okResult);
            Assert.IsType<string>(okResult.Value);
            Assert.Equal("کارتی وجود ندارد", okResult.Value);
            Assert.Equal(400, okResult.StatusCode);
        }

        #endregion
        #region GetBankCardsTests
        [Fact]
        public async Task GetBankCards_Success()
        {
            //Arrange------------------------------------------------------------------------------------------------------------------------------
            //_mockRepo.Setup(x => x.BankCardRepository.GetManyAsync(
            //        It.IsAny<Expression<Func<BankCard, bool>>>(),
            //        It.IsAny<Func<IQueryable<BankCard>, IOrderedQueryable<BankCard>>>(),
            //        It.IsAny<string>()))
            //    .ReturnsAsync(new List<BankCard>());

            _mockMapper.Setup(x => x.Map<List<BankCardForUserDetailedDto>>(It.IsAny<List<BankCard>>()))
                .Returns(new List<BankCardForUserDetailedDto>());

            //Act----------------------------------------------------------------------------------------------------------------------------------
            var result = await _controller.GetBankCards(It.IsAny<string>());
            var okResult = result as OkObjectResult;
            //Assert-------------------------------------------------------------------------------------------------------------------------------
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }


        #endregion
        #region UpdateBankCardTests
        [Fact]
        public async Task UpdateBankCard_Success()
        {
            //Arrange------------------------------------------------------------------------------------------------------------------------------
            _mockRepo.Setup(x => x.BankCardRepository.GetByIdAsync(It.IsAny<string>()))
                .ReturnsAsync(UnitTestsDataInput.Users.First().BankCards.First());

            _mockRepo.Setup(x => x.BankCardRepository.Update(It.IsAny<BankCard>()));

            _mockRepo.Setup(x => x.SaveAsync()).ReturnsAsync(true);

            _mockMapper.Setup(x => x.Map(It.IsAny<BankCardForUpdateDto>(), It.IsAny<BankCard>()))
                .Returns(new BankCard());

            var rout = new RouteData();
            rout.Values.Add("userId", UnitTestsDataInput.userLogedInId);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,UnitTestsDataInput.userLogedInId),
            };
            var identity = new ClaimsIdentity(claims);
            var claimsPrincipal = new ClaimsPrincipal(identity);
            var mockContext = new Mock<HttpContext>();

            mockContext.SetupGet(x => x.User).Returns(claimsPrincipal);

            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = mockContext.Object,
                RouteData = rout
            };


            //Act----------------------------------------------------------------------------------------------------------------------------------
            var result = await _controller.UpdateBankCard(It.IsAny<string>(), It.IsAny<BankCardForUpdateDto>());
            var okResult = result as NoContentResult;
            //Assert-------------------------------------------------------------------------------------------------------------------------------
            Assert.Equal(204, okResult.StatusCode);
        }
        [Fact]
        public async Task UpdateBankCard_Fail_DataBaseError()
        {
            //Arrange------------------------------------------------------------------------------------------------------------------------------
            _mockRepo.Setup(x => x.BankCardRepository.GetByIdAsync(It.IsAny<string>()))
                .ReturnsAsync(UnitTestsDataInput.Users.First().BankCards.First());

            _mockRepo.Setup(x => x.BankCardRepository.Update(It.IsAny<BankCard>()));

            _mockRepo.Setup(x => x.SaveAsync()).ReturnsAsync(false);

            _mockMapper.Setup(x => x.Map(It.IsAny<BankCardForUpdateDto>(), It.IsAny<BankCard>()))
                .Returns(new BankCard());

            var rout = new RouteData();
            rout.Values.Add("userId", UnitTestsDataInput.userLogedInId);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,UnitTestsDataInput.userLogedInId),
            };
            var identity = new ClaimsIdentity(claims);
            var claimsPrincipal = new ClaimsPrincipal(identity);
            var mockContext = new Mock<HttpContext>();

            mockContext.SetupGet(x => x.User).Returns(claimsPrincipal);

            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = mockContext.Object,
                RouteData = rout
            };


            //Act----------------------------------------------------------------------------------------------------------------------------------
            var result = await _controller.UpdateBankCard(It.IsAny<string>(), It.IsAny<BankCardForUpdateDto>());
            var okResult = result as BadRequestObjectResult;
            //Assert-------------------------------------------------------------------------------------------------------------------------------
            Assert.NotNull(okResult);
            Assert.IsType<string>(okResult.Value);

            Assert.Equal("خطا در ثبت اطلاعات", okResult.Value);
            Assert.Equal(400, okResult.StatusCode);
        }
        [Fact]
        public async Task UpdateBankCard_Fail_SeeAnOtherOneCard()
        {
            //Arrange------------------------------------------------------------------------------------------------------------------------------
            _mockRepo.Setup(x => x.BankCardRepository.GetByIdAsync(It.IsAny<string>()))
                .ReturnsAsync(UnitTestsDataInput.Users.First().BankCards.First());


            var rout = new RouteData();
            rout.Values.Add("userId", UnitTestsDataInput.userLogedInId);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,UnitTestsDataInput.userAnOtherId),
            };
            var identity = new ClaimsIdentity(claims);
            var claimsPrincipal = new ClaimsPrincipal(identity);
            var mockContext = new Mock<HttpContext>();

            mockContext.SetupGet(x => x.User).Returns(claimsPrincipal);

            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = mockContext.Object,
                RouteData = rout
            };

            //Act----------------------------------------------------------------------------------------------------------------------------------
            var result = await _controller.UpdateBankCard(It.IsAny<string>(), It.IsAny<BankCardForUpdateDto>());
            var okResult = result as BadRequestObjectResult;
            //Assert-------------------------------------------------------------------------------------------------------------------------------
            Assert.NotNull(okResult);
            Assert.IsType<string>(okResult.Value);

            Assert.Equal("شما اجازه اپدیت کارت کاربر دیگری را ندارید", okResult.Value);
            Assert.Equal(400, okResult.StatusCode);
        }

        [Fact]
        public async Task UpdateBankCard_Fail_NullBankCard()
        {
            //Arrange------------------------------------------------------------------------------------------------------------------------------
            _mockRepo.Setup(x => x.BankCardRepository.GetByIdAsync(It.IsAny<string>()))
                .ReturnsAsync(It.IsAny<BankCard>());


            //Act----------------------------------------------------------------------------------------------------------------------------------
            var result = await _controller.UpdateBankCard(It.IsAny<string>(), It.IsAny<BankCardForUpdateDto>());
            var okResult = result as BadRequestObjectResult;
            //Assert-------------------------------------------------------------------------------------------------------------------------------
            Assert.NotNull(okResult);
            Assert.IsType<string>(okResult.Value);
            Assert.Equal("کارتی وجود ندارد", okResult.Value);
            Assert.Equal(400, okResult.StatusCode);
        }

        #endregion

        #region DeleteBankCardTests
        [Fact]
        public async Task DeleteBankCard_Success()
        {
            //Arrange------------------------------------------------------------------------------------------------------------------------------
            _mockRepo.Setup(x => x.BankCardRepository.GetByIdAsync(It.IsAny<string>()))
                .ReturnsAsync(UnitTestsDataInput.Users.First().BankCards.First());

            _mockRepo.Setup(x => x.BankCardRepository.Delete(It.IsAny<BankCard>()));

            _mockRepo.Setup(x => x.SaveAsync()).ReturnsAsync(true);

            var rout = new RouteData();
            rout.Values.Add("userId", UnitTestsDataInput.userLogedInId);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,UnitTestsDataInput.userLogedInId),
            };
            var identity = new ClaimsIdentity(claims);
            var claimsPrincipal = new ClaimsPrincipal(identity);
            var mockContext = new Mock<HttpContext>();

            mockContext.SetupGet(x => x.User).Returns(claimsPrincipal);

            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = mockContext.Object,
                RouteData = rout
            };


            //Act----------------------------------------------------------------------------------------------------------------------------------
            var result = await _controller.DeleteBankCard(It.IsAny<string>());
            var okResult = result as NoContentResult;
            //Assert-------------------------------------------------------------------------------------------------------------------------------
            Assert.Equal(204, okResult.StatusCode);
        }
        [Fact]
        public async Task DeleteBankCard_Fail_DataBaseError()
        {
            //Arrange------------------------------------------------------------------------------------------------------------------------------
            _mockRepo.Setup(x => x.BankCardRepository.GetByIdAsync(It.IsAny<string>()))
                .ReturnsAsync(UnitTestsDataInput.Users.First().BankCards.First());

            _mockRepo.Setup(x => x.BankCardRepository.Update(It.IsAny<BankCard>()));

            _mockRepo.Setup(x => x.SaveAsync()).ReturnsAsync(false);


            var rout = new RouteData();
            rout.Values.Add("userId", UnitTestsDataInput.userLogedInId);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,UnitTestsDataInput.userLogedInId),
            };
            var identity = new ClaimsIdentity(claims);
            var claimsPrincipal = new ClaimsPrincipal(identity);
            var mockContext = new Mock<HttpContext>();

            mockContext.SetupGet(x => x.User).Returns(claimsPrincipal);

            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = mockContext.Object,
                RouteData = rout
            };


            //Act----------------------------------------------------------------------------------------------------------------------------------
            var result = await _controller.DeleteBankCard(It.IsAny<string>());
            var okResult = result as BadRequestObjectResult;
            //Assert-------------------------------------------------------------------------------------------------------------------------------
            Assert.NotNull(okResult);
            Assert.IsType<string>(okResult.Value);

            Assert.Equal("خطا در حذف اطلاعات", okResult.Value);
            Assert.Equal(400, okResult.StatusCode);
        }
        [Fact]
        public async Task DeleteBankCard_Fail_SeeAnOtherOneCard()
        {
            //Arrange------------------------------------------------------------------------------------------------------------------------------
            _mockRepo.Setup(x => x.BankCardRepository.GetByIdAsync(It.IsAny<string>()))
                .ReturnsAsync(UnitTestsDataInput.Users.First().BankCards.First());


            var rout = new RouteData();
            rout.Values.Add("userId", UnitTestsDataInput.userLogedInId);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,UnitTestsDataInput.userAnOtherId),
            };
            var identity = new ClaimsIdentity(claims);
            var claimsPrincipal = new ClaimsPrincipal(identity);
            var mockContext = new Mock<HttpContext>();

            mockContext.SetupGet(x => x.User).Returns(claimsPrincipal);

            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = mockContext.Object,
                RouteData = rout
            };

            //Act----------------------------------------------------------------------------------------------------------------------------------
            var result = await _controller.DeleteBankCard(It.IsAny<string>());
            var okResult = result as BadRequestObjectResult;
            //Assert-------------------------------------------------------------------------------------------------------------------------------
            Assert.NotNull(okResult);
            Assert.IsType<string>(okResult.Value);

            Assert.Equal("شما اجازه حذف کارت کاربر دیگری را ندارید", okResult.Value);
            Assert.Equal(400, okResult.StatusCode);
        }

        [Fact]
        public async Task DeleteBankCard_Fail_NullBankCard()
        {
            //Arrange------------------------------------------------------------------------------------------------------------------------------
            _mockRepo.Setup(x => x.BankCardRepository.GetByIdAsync(It.IsAny<string>()))
                .ReturnsAsync(It.IsAny<BankCard>());


            //Act----------------------------------------------------------------------------------------------------------------------------------
            var result = await _controller.DeleteBankCard(It.IsAny<string>());
            var okResult = result as BadRequestObjectResult;
            //Assert-------------------------------------------------------------------------------------------------------------------------------
            Assert.NotNull(okResult);
            Assert.IsType<string>(okResult.Value);
            Assert.Equal("کارتی وجود ندارد", okResult.Value);
            Assert.Equal(400, okResult.StatusCode);
        }

        #endregion

        #region AddBankCardTests
        [Fact]
        public async Task AddBankCard_Success()
        {
            //Arrange------------------------------------------------------------------------------------------------------------------------------
            _mockRepo.Setup(x => x.BankCardRepository.GetAsync(It.IsAny<Expression<Func<BankCard, bool>>>()))
                .ReturnsAsync(It.IsAny<BankCard>());

            _mockRepo.Setup(x => x.BankCardRepository.BankCardCountAsync(It.IsAny<string>()))
                .ReturnsAsync(5);


            _mockRepo.Setup(x => x.BankCardRepository.InsertAsync(It.IsAny<BankCard>()));

            _mockRepo.Setup(x => x.SaveAsync()).ReturnsAsync(true);


            _mockMapper.Setup(x => x.Map(It.IsAny<BankCardForUpdateDto>(), It.IsAny<BankCard>()))
                .Returns(new BankCard());

            _mockMapper.Setup(x => x.Map<BankCardForReturnDto>(It.IsAny<BankCard>()))
                .Returns(new BankCardForReturnDto());

            //Act----------------------------------------------------------------------------------------------------------------------------------
            var result = await _controller.AddBankCard(It.IsAny<string>(),
                UnitTestsDataInput.bankCardForUpdateDto);
            var okResult = result as CreatedAtRouteResult;
            //Assert-------------------------------------------------------------------------------------------------------------------------------
            Assert.NotNull(okResult);
            Assert.IsType<BankCardForReturnDto>(okResult.Value);
            Assert.Equal(201, okResult.StatusCode);
        }
        [Fact]
        public async Task AddBankCard_Fail_KarNumberRepeat()
        {
            //Arrange------------------------------------------------------------------------------------------------------------------------------
            //Arrange------------------------------------------------------------------------------------------------------------------------------
            _mockRepo.Setup(x => x.BankCardRepository.GetAsync(It.IsAny<Expression<Func<BankCard, bool>>>()))
                .ReturnsAsync(new BankCard());
            //Act----------------------------------------------------------------------------------------------------------------------------------
            var result = await _controller.AddBankCard(It.IsAny<string>(),
                UnitTestsDataInput.bankCardForUpdateDto);
            var okResult = result as BadRequestObjectResult;
            //Assert-------------------------------------------------------------------------------------------------------------------------------
            Assert.NotNull(okResult);
            Assert.IsType<string>(okResult.Value);
            Assert.Equal("این کارت قبلا ثبت شده است", okResult.Value.ToString());
            Assert.Equal(400, okResult.StatusCode);
        }
        [Fact]
        public async Task AddBankCard_Fail_MoreThan10Card()
        {
            //Arrange------------------------------------------------------------------------------------------------------------------------------
            _mockRepo.Setup(x => x.BankCardRepository.GetAsync(It.IsAny<Expression<Func<BankCard, bool>>>()))
                .ReturnsAsync(It.IsAny<BankCard>());

            _mockRepo.Setup(x => x.BankCardRepository.BankCardCountAsync(It.IsAny<string>()))
                .ReturnsAsync(11);


            //Act----------------------------------------------------------------------------------------------------------------------------------
            var result = await _controller.AddBankCard(It.IsAny<string>(),
            UnitTestsDataInput.bankCardForUpdateDto);
            var okResult = result as BadRequestObjectResult;
            //Assert-------------------------------------------------------------------------------------------------------------------------------
            Assert.NotNull(okResult);
            Assert.IsType<string>(okResult.Value);
            Assert.Equal("شما اجازه وارد کردن بیش از 10 کارت را ندارید", okResult.Value.ToString());
            Assert.Equal(400, okResult.StatusCode);
        }
        #endregion


       
    }
}
