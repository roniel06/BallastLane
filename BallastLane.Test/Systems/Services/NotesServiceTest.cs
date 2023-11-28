using AutoFixture;
using BallastLane.Business.Services;
using BallastLane.Infrastructure.Models;
using BallastLane.Infrastructure.Repositories;
using FluentAssertions;
using Moq;

namespace BallastLane.Test.Systems.Services
{
    public class NotesServiceTest
    {
        private readonly NoteService _sut;

        private readonly Mock<INoteRepository> _noteRepositoryMock = new Mock<INoteRepository>();
        public NotesServiceTest()
        {
            _sut = new NoteService(_noteRepositoryMock.Object);
        }

        [Fact]
        public async Task GetAllNotes_ShouldReturnAllCreated_NonDeleted_Notes()
        {
            // Arrange
            var fixture = new Fixture();
            var notes = fixture.CreateMany<Note>(10);


            _noteRepositoryMock.Setup(x => x.GetAllAsync())
                .ReturnsAsync(notes);

            // Act
            var result = await _sut.GetAllAsync();

            // Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<IEnumerable<Note>>();
            result.Count().Should().BeGreaterThan(0);

        }

        [Fact]
        public async Task GetAllNotes_ShouldReturnEmptyLists_IfNoRecordsAreFound()
        {
            // Arrange
            var fixture = new Fixture();

            _noteRepositoryMock.Setup(x => x.GetAllAsync())
                .ReturnsAsync(new List<Note>());

            // Act
            var result = await _sut.GetAllAsync();

            // Assert
            result.Should().BeEmpty();
            result.Should().BeAssignableTo<IEnumerable<Note>>();
            result.Count().Should().Be(0);
        }

        [Fact]
        public async Task CreateNote_ShouldReturnCreatedNote()
        {
            // Arramge
            var fixture = new Fixture();
            var note = fixture.Create<Note>();

            _noteRepositoryMock.Setup(x => x.CreateAsync(It.IsAny<Note>()))
                .ReturnsAsync(note);

            // Act
            var result = await _sut.CreateAsync(note);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<Note>();
            result.Should().BeEquivalentTo(note);
        }

        [Fact]
        public async Task UpdateNote_ShouldReturnUpdatedNote()
        {
            // Arrange
            var fixture = new Fixture();
            var existingNote = fixture.Create<Note>();
            var updatedNote = fixture.Create<Note>();

            _noteRepositoryMock.Setup(x => x.GetByIdAsync(existingNote.Id))
                .ReturnsAsync(existingNote);

            _noteRepositoryMock.Setup(x => x.UpdateAsync(It.IsAny<Note>()))
                .ReturnsAsync((Note note) => note);

            // Act
            var existing = await _sut.GetByIdAsync(existingNote.Id);
            var result = await _sut.UpdateAsync(updatedNote);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<Note>();
            result.Should().BeEquivalentTo(updatedNote);
            existing.Title.Should().NotBe(updatedNote.Title);
            existing.Text.Should().NotBe(updatedNote.Text);

            _noteRepositoryMock.Verify(x => x.GetByIdAsync(existingNote.Id), Times.Once);
            _noteRepositoryMock.Verify(x => x.UpdateAsync(It.IsAny<Note>()), Times.Once);
        }

        [Fact]
        public async Task DeleteNote_ShouldReturnTrueOnDelete_ShouldBe_SoftDeleted()
        {
            // Arrange
            var fixture = new Fixture();
            var existingNote = fixture.Create<Note>();
            existingNote.IsDeleted = false;
            _noteRepositoryMock.Setup(x => x.GetByIdAsync(existingNote.Id)).ReturnsAsync(existingNote);
            _noteRepositoryMock.Setup(x => x.DeleteAsync(It.IsAny<int>())).ReturnsAsync(true);

            // Act
            var result = await _sut.DeleteAsync(existingNote.Id);
            // Assert
            result.Should().BeTrue();
        }
    }
}