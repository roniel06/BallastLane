using AutoFixture;
using BallastLane.Infrastructure.Context;
using BallastLane.Infrastructure.Models;
using BallastLane.Infrastructure.Repositories;
using BallastLane.Infrastructure.Repositories.Core;
using BallastLane.Test.Helpers;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;

namespace BallastLane.Test.Systems.Repository
{
    public class UserRepositoryTest
    {
        private readonly UserRepository _sut;
        Mock<ILogger<Repository<User>>> loggerMock = new Mock<ILogger<Repository<User>>>();
        private readonly ProjectDbContext _context = DatabaseHelper.CreateDbContex();

        public UserRepositoryTest()
        {
            _sut = new UserRepository(_context, loggerMock.Object);
        }


        [Fact]
        public async Task CreateAsync_ShouldReturnCreatedEntity()
        {
            // Arrange
            var fixture = new Fixture();
            var user = fixture.Create<User>();
            user.IsDeleted = false;

            // Act
            var result = await _sut.CreateAsync(user);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<User>();
            result.Should().BeEquivalentTo(user);
        }

        [Fact]
        public async Task GetAll_ShouldReturnAll_NonDeleted_Entities()
        {
            // Arrange
            var fixture = new Fixture();
            var users = fixture.CreateMany<User>(10);


            // Act
            foreach (var user in users)
            {
                await _sut.CreateAsync(user);
            }

            // Assert
            var result = await _sut.GetAllAsync();
            result.Should().NotBeNull();
            result.Count().Should().BeGreaterThan(0);
        }

        [Fact]
        public async Task GetById_ShouldReturn_Created_Record()
        {
            // Arrange
            var fixture = new Fixture();
            var user = fixture.Create<User>();


            // Act 
            await _sut.CreateAsync(user);

            // Assert
            var result = await _sut.GetByIdAsync(user.Id);
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(user);
        }


        [Fact]
        public async Task Update_ShouldReturn_Updated_Record()
        {
            // Arrange
            var fixture = new Fixture();
            var user = fixture.Create<User>();
            user.IsDeleted = false;

            // Act 
            var createdUser = await _sut.CreateAsync(user);
            createdUser!.Name = "Roniel_Test";
            createdUser.LastName = "Test_LastName";

            // Assert
            var updatedUser = await _sut.UpdateAsync(createdUser);
            updatedUser.Should().NotBeNull();
            updatedUser!.Name.Should().BeEquivalentTo(createdUser.Name);
            updatedUser.LastName.Should().BeEquivalentTo(createdUser.LastName);
        }

        [Fact]
        public async Task Delete_ShouldReturn_True_IfDeleted()
        {
            // Arrange
            var fixture = new Fixture();
            var user = fixture.Create<User>();
            user.IsDeleted = false;

            // Act 
            var createdUser = await _sut.CreateAsync(user);

            // Assert
            var updatedUser = await _sut.DeleteAsync(createdUser.Id);
            updatedUser.Should().BeTrue();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(25)]
        public async Task Delete_ShouldReturn_False_IfRecord_DoesntExist(int id)
        {
            // Arrange

            // Act 
            var updatedUser = await _sut.DeleteAsync(id);

            // Assert
            updatedUser.Should().BeFalse();
        }

    }
}
