using AutoFixture;
using BallastLane.Api.Controllers;
using BallastLane.Business.Services;
using BallastLane.Infrastructure.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace BallastLane.Test.Systems.Controllers
{
    public class UserControllerTest
    {
        private readonly UsersController _sut;
        private readonly Mock<IUserService> _userService = new Mock<IUserService>();
        public UserControllerTest()
        {
            _sut = new UsersController(_userService.Object);
        }

        [Fact]
        public async void GetAll_Users_ShouldReturn_StatusCode200_IfUsersAreCreated()
        {
            // Arrange
            var fixture = new Fixture();
            var userList = fixture.Create<IEnumerable<User>>();
            _userService.Setup(x => x.GetAllAsync()).ReturnsAsync(userList);

            // Act
            var result = (OkObjectResult)await _sut.GetAll();
            // Assert
            result.StatusCode.Should().Be(200);
        }


        [Fact]
        public async void GetAll_Users_ShouldReturn_ListOfTypeUsers()
        {
            // Arrange
            var fixture = new Fixture();
            var userList = fixture.Create<IEnumerable<User>>();
            _userService.Setup(x => x.GetAllAsync()).ReturnsAsync(userList);

            //Act
            var result = (OkObjectResult)await _sut.GetAll();
            //Assert
            var model = result.Value.Should().BeAssignableTo<IEnumerable<User>>().Subject;
            model.Count().Should().BeGreaterThan(0);
        }


        [Fact]
        public async void GetById_ShouldReturnCreatedUserAndStatusCode200()
        {
            // Arrange
            var fixture = new Fixture();
            var user = fixture.Create<User>();
            _userService.Setup(x => x.GetByIdAsync(user.Id)).ReturnsAsync(user);

            // Act
            var result = (OkObjectResult) await _sut.GetById(user.Id);


            // Assert
            result.StatusCode.Should().Be(200);
            var model = result.Value.Should().BeAssignableTo<User>().Subject;
            model.Should().BeEquivalentTo(user);
        }

        [Fact]
        public async void Update_ShouldReturn_UpdatedEntity()
        {
            // Arrange
            var fixture = new Fixture();
            var user = fixture.Create<User>();
            
            _userService.Setup(x => x.UpdateAsync(It.IsAny<User>())).ReturnsAsync(user);

            // Act
            var result = await _sut.Update(user); 

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var updatedUser = Assert.IsType<User>(okResult.Value);

            updatedUser.Name.Should().Be(user.Name); 
            updatedUser.LastName.Should().Be(user.LastName);


            _userService.Verify(x => x.UpdateAsync(It.IsAny<User>()), Times.Once);
        }

        [Fact]
        public async void Delete_ShouldReturnTrue()
        {
            // Arrange
            var fixture = new Fixture();
            var user = fixture.Create<User>();
            user.IsDeleted = false;
            _userService.Setup(x => x.DeleteAsync(user.Id)).ReturnsAsync(true);

            // Act
            var result = (OkObjectResult)await _sut.Delete(user.Id);


            // Assert
            result.StatusCode.Should().Be(200);
            var model = result.Value.Should().BeAssignableTo<bool>().Subject;
            model.Should().BeTrue();
        }

        [Fact]
        public async void Delete_ShouldReturnBadRequest_If_WrongParameter_IsPassed()
        {
            // Arrange
            var fixture = new Fixture();
            var user = fixture.Create<User>();
            user.IsDeleted = false;
            _userService.Setup(x => x.DeleteAsync(0)).ReturnsAsync(false);

            // Act
            var result = (BadRequestObjectResult)await _sut.Delete(0);

            // Assert
            result.StatusCode.Should().Be(400);
        }

        [Fact]
        public async void GetUser_IncludeNotes_ShouldIncludeNotes()
        {
            throw new NotImplementedException();
        }
    }
}
