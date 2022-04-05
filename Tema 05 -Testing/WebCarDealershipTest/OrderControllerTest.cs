using CarDealership.Data;
using CarDealership.Data.Models;
using Moq;
using WebCarDealership.Controllers;
using WebCarDealership.Requests;
using Xunit;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace WebCarDealershipTest
{
    public class OrderControllerTest
    {
        private readonly Mock<IRepository> repoMock;
        private readonly OrderController controllerSut;
        public OrderControllerTest()
        {
            repoMock = new Mock<IRepository>();
            controllerSut = new OrderController(repoMock.Object);

        }
        [Fact]
        public async void GiveAValidRequestModel_WhenCallingPost_ThenGettingAResponse()
        {
            //Arrange
            var offer = new CarOffer()
            {
                Id = 1,
                Model = "Test Model"
            };
            repoMock.Setup(repo => repo.GetCarOfferById(It.IsAny<int>())).ReturnsAsync(offer);

            var requestModel = new OrderRequestModel()
            {
                CarOfferId = 1,
            };

            //Act
            var result = await controllerSut.Post(requestModel);

            //Asert
            result.Should().NotBeNull();
        }
        [Fact]
        public async void GiveAnInvalidRequestModel_WhenCallingPost_ThenGetBadRequest()
        {
            //Arrange
            var offer = new CarOffer()
            {
                Id = 1,
                Model = "Test Model"
            };

            repoMock.Setup(repo => repo.GetCarOfferById(It.IsAny<int>())).ReturnsAsync(offer);

            var requestModel = new OrderRequestModel()
            {
            };

            //Act
            var result = await controllerSut.Post(requestModel);

            //Asert
            result.Should().BeOfType<BadRequestObjectResult>();

        }
        [Fact]
        public async void GiveAnInvalidCarOfferId_WhenWhenCallingPost_ThenGetNotFoundRequest()
        {
            //Arrange
            repoMock.Setup(repo => repo.GetCarOfferById(It.IsAny<int>())).ReturnsAsync((CarOffer) null);

            var requestModel = new OrderRequestModel()
            {
            };

            //Act
            var result = await controllerSut.Post(requestModel);

            //Assert
            result.Should().BeOfType<NotFoundObjectResult>();
        }
        [Fact]
        public async void GiveAnInvalidAvailableStock_WhenWhenCallingPost_ThenGetBadRequest()
        {
            //Arrange
            var offer = new CarOffer()
            {
                Id = 1,
                Model = "Test Model",
                AvailableStock = 10
            };
            repoMock.Setup(repo => repo.GetCarOfferById(It.IsAny<int>())).ReturnsAsync(offer);

            var requestModel = new OrderRequestModel()
            {
                CarOfferId = 1,
                Quantity = 11
            };

            //Act
            var result = await controllerSut.Post(requestModel);

            //Assert
            result.Should().BeOfType<BadRequestObjectResult>();

        }
        [Fact]
        public async void GiveAValidRequestModel_WhenWhenCallingPost_ThenGetOkRequest()
        {
            //Arrange
            var offer = new CarOffer()
            {
                Id = 1,
                Model = "Test Model",
                AvailableStock = 10
            };
            repoMock.Setup(repo => repo.GetCarOfferById(It.IsAny<int>())).ReturnsAsync(offer);

            var requestModel = new OrderRequestModel()
            {
                CarOfferId = 1,
                Quantity = 1
            };

            //Act
            var result = await controllerSut.Post(requestModel);

            //Assert
            result.Should().BeOfType<OkObjectResult>();

        }
    }
}