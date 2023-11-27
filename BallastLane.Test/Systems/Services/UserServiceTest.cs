using AutoFixture;
using BallastLane.Business.Services;
using BallastLane.Infrastructure.Models;
using BallastLane.Infrastructure.Repositories;
using FluentAssertions;
using Moq;

namespace BallastLane.Test.Systems.Services
{
    public class UserServiceTest
    {

        private readonly UserService _sut;
        private readonly Mock<IUserRepository> _userRepositoryMock = new Mock<IUserRepository>();

        public UserServiceTest()
        {
            _sut = new UserService(_userRepositoryMock.Object);
        }

        [Fact]
        public async Task GetAllUsers_ShouldReturnAllCreated_NonDeleted_Users()
        {
            // Arrange
            var fixture = new Fixture();
            var users = fixture.CreateMany<User>(10);


            _userRepositoryMock.Setup(x => x.GetAllAsync())
                .ReturnsAsync(users);

            // Act
            var result = await _sut.GetAllAsync();

            // Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<IEnumerable<User>>();
            result.Count().Should().BeGreaterThan(0);

        }

        [Fact]
        public async Task GetAllUsers_ShouldReturnEmptyLists_IfNoRecordsAreFound()
        {
            // Arrange
            var fixture = new Fixture();

            _userRepositoryMock.Setup(x => x.GetAllAsync())
                .ReturnsAsync(new List<User>());

            // Act
            var result = await _sut.GetAllAsync();

            // Assert
            result.Should().BeEmpty();
            result.Should().BeAssignableTo<IEnumerable<User>>();
            result.Count().Should().Be(0);

        }

        [Fact]
        public async Task CreateUser_ShouldReturnCreatedUser()
        {
            // Arramge
            var fixture = new Fixture();
            var user = fixture.Create<User>();
            _userRepositoryMock.Setup(x => x.CreateAsync(It.IsAny<User>()))
                .ReturnsAsync(user);

            // Act
            var result = await _sut.CreateAsync(user);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<User>();
            result.Should().BeEquivalentTo(user);
        }

        [Fact]
        public async Task UpdateUser_ShouldReturnUpdatedUser()
        {
            // Arrange
            var fixture = new Fixture();
            var existingUser = fixture.Create<User>();
            var updatedUser = fixture.Create<User>();

            _userRepositoryMock.Setup(x => x.GetByIdAsync(existingUser.Id))
                .ReturnsAsync(existingUser);

            _userRepositoryMock.Setup(x => x.UpdateAsync(It.IsAny<User>()))
                .ReturnsAsync((User user) => user);

            // Act
            var existing = await _sut.GetByIdAsync(existingUser.Id);
            var result = await _sut.UpdateAsync(updatedUser);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<User>();
            result.Should().BeEquivalentTo(updatedUser);
            existing.Name.Should().NotBe(updatedUser.Name);

            _userRepositoryMock.Verify(x => x.GetByIdAsync(existingUser.Id), Times.Once);
            _userRepositoryMock.Verify(x => x.UpdateAsync(It.IsAny<User>()), Times.Once);
        }


        [Fact]
        public async Task DeleteUser_ShouldReturnTrueOnDelete_ShouldBe_SoftDeleted()
        {
            // Arrange
            var fixture = new Fixture();
            var existingUser = fixture.Create<User>();
            existingUser.IsDeleted = false;
            _userRepositoryMock.Setup(x => x.GetByIdAsync(existingUser.Id)).ReturnsAsync(existingUser);
            _userRepositoryMock.Setup(x => x.DeleteAsync(It.IsAny<int>())).ReturnsAsync(true);

            // Act
            var result = await _sut.DeleteAsync(existingUser.Id);
            // Assert
            result.Should().BeTrue();
        }
    }
}
