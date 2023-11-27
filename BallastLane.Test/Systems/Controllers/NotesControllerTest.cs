using AutoFixture;
using BallastLane.Api.Controllers;
using BallastLane.Business.Services;
using BallastLane.Infrastructure.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace BallastLane.Test.Systems.Controllers
{
    public class NotesControllerTest
    {
        private readonly NotesController _sut;

        private readonly Mock<INoteService> _noteMockService = new Mock<INoteService>();
        public NotesControllerTest()
        {
            _sut = new NotesController(_noteMockService.Object);
        }

        [Fact]
        public async Task GetAll_Notes_ShouldReturn200StatusCode()
        {
            // Arrange
            var fixture = new Fixture();
            var userList = fixture.Create<IEnumerable<Note>>();
            _noteMockService.Setup(x => x.GetAllAsync()).ReturnsAsync(userList);

            // Act
            var result = (OkObjectResult)await _sut.GetAll();
            // Assert
            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task GetAll_Notes_ShouldReturn_ListOfTypeUsers()
        {
            // Arrange
            var fixture = new Fixture();
            var noteList = fixture.Create<IEnumerable<Note>>();
            _noteMockService.Setup(x => x.GetAllAsync()).ReturnsAsync(noteList);

            //Act
            var result = (OkObjectResult)await _sut.GetAll();
            //Assert
            var model = result.Value.Should().BeAssignableTo<IEnumerable<Note>>().Subject;
            model.Count().Should().BeGreaterThan(0);
        }


        [Fact]
        public async Task GetById_ShouldReturnCreatedNotesAndStatusCode200()
        {
            // Arrange
            var fixture = new Fixture();
            var note = fixture.Create<Note>();
            _noteMockService.Setup(x => x.GetByIdAsync(note.Id)).ReturnsAsync(note);

            // Act
            var result = (OkObjectResult)await _sut.GetById(note.Id);


            // Assert
            result.StatusCode.Should().Be(200);
            var model = result.Value.Should().BeAssignableTo<Note>().Subject;
            model.Should().BeEquivalentTo(note);
        }


        [Fact]
        public async Task Update_ShouldReturn_UpdatedNote()
        {
            // Arrange
            var fixture = new Fixture();
            var note = fixture.Create<Note>();

            _noteMockService.Setup(x => x.UpdateAsync(It.IsAny<Note>())).ReturnsAsync(note);

            // Act
            var result = await _sut.Update(note);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var updatedNote = Assert.IsType<Note>(okResult.Value);

            updatedNote.Title.Should().Be(note.Title);
            updatedNote.Text.Should().Be(note.Text);


            _noteMockService.Verify(x => x.UpdateAsync(It.IsAny<Note>()), Times.Once);
        }

        [Fact]
        public async Task Delete_ShouldReturnTrue()
        {
            // Arrange
            var fixture = new Fixture();
            var note = fixture.Create<Note>();
            note.IsDeleted = false;
            _noteMockService.Setup(x => x.DeleteAsync(note.Id)).ReturnsAsync(true);

            // Act
            var result = (OkObjectResult)await _sut.Delete(note.Id);


            // Assert
            result.StatusCode.Should().Be(200);
            var model = result.Value.Should().BeAssignableTo<bool>().Subject;
            model.Should().BeTrue();
        }


        [Fact]
        public async Task Delete_ShouldReturnBadRequest_If_WrongParameter_IsPassed()
        {
            // Arrange
            var fixture = new Fixture();
            var note = fixture.Create<Note>();
            note.IsDeleted = false;
            _noteMockService.Setup(x => x.DeleteAsync(0)).ReturnsAsync(false);

            // Act
            var result = (BadRequestObjectResult)await _sut.Delete(0);

            // Assert
            result.StatusCode.Should().Be(400);
        }
    }
}
