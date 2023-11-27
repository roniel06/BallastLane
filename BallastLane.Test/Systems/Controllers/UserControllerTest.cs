using BallastLane.Api.Controllers;
using BallastLane.Infrastructure.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace BallastLane.Test.Systems.Controllers
{
    public class UserControllerTest
    {
        [Fact]
        public async void GetAll_Users_ShouldReturn_StatusCode200()
        {
            // Arrange
            var sut = new UsersController();
            // Act
            var result = (OkObjectResult)await sut.GetAll();
            // Assert
            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async void GetAll_Users_ShouldReturn_ListOfTypeUsers()
        {
            // Arrange
            var sut = new UsersController();

            //Act
            var result = (OkObjectResult)await sut.GetAll();
            var records = result.Value as List<User>;
            //Assert
            records.Should().NotBeNull();
            records.Count.Should().BeGreaterThan(0);
            
        }
    }
}
