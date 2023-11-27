using BallastLane.Infrastructure.Models;
using BallastLane.Test.Helpers;
using BallastLane.Infrastructure.Repositories.Core;
using Moq;
using Castle.Core.Logging;
using Microsoft.Extensions.Logging;
using BallastLane.Infrastructure.Repositories;
using FluentAssertions;

namespace BallastLane.Test.Systems.Repository
{
    public class UserRepositoryTest
    {
        [Fact]
        public async void CreateAsync_ShouldReturnCreatedEntity()
        {
            // Arrange
            var guid = Guid.NewGuid().ToString();
            var dbContext = DatabaseHelper.CreateDbContex();
            var loggerMock = new Mock<ILogger<Repository<User>>>();
            var repository = new UserRepository(dbContext, loggerMock.Object);
            var user = new User
            {
                Name = $"Test_{guid}",
                LastName = $"LastName_{guid}",
                Address = $"Address_{guid}",
                DateOfBirth = DateTime.Parse("2023-01-01"),
                PhoneNumber = "1234567890"
            };

            // Act
            var result = await repository.CreateAsync(user);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<User>();
        }


    }
}
