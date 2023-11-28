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
    public class NoteRepositoryTest
    {
        private readonly NoteRepository _sut;
        Mock<ILogger<Repository<Note>>> loggerMock = new Mock<ILogger<Repository<Note>>>();
        private readonly ProjectDbContext _context = DatabaseHelper.CreateDbContex();
        private int userId = 0;
        public NoteRepositoryTest()
        {
            _sut = new NoteRepository(_context, loggerMock.Object);
            Setup();
        }


        [Fact]
        public async Task CreateAsync_ShouldReturnCreatedEntity()
        {
            // Arrange
            var fixture = new Fixture();
            var note = fixture.Build<Note>().With(x => x.Id, 0).Create();
            note.IsDeleted = false;
            note.UserId = userId;


            // Act
            var result = await _sut.CreateAsync(note);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<Note>();
            result.Should().BeEquivalentTo(note);
        }

        [Fact]
        public async Task GetAll_ShouldReturnAll_NonDeleted_Entities()
        {
            // Arrange
            var fixture = new Fixture();

            var notes = fixture.Build<Note>().With(x => x.Id, 0).CreateMany(10);


            // Act
            foreach (var note in notes)
            {
                note.UserId = userId;
                await _sut.CreateAsync(note);
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
            var note = fixture.Build<Note>().With(x => x.Id, 0).Create();
            note.IsDeleted = false;
            note.UserId = userId;

            // Act 
            await _sut.CreateAsync(note);
            var result = await _sut.GetByIdAsync(note.Id);


            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(note);
        }


        [Fact]
        public async Task Update_ShouldReturn_Updated_Record()
        {
            // Arrange
            var fixture = new Fixture();
            var note = fixture.Build<Note>().With(x => x.Id, 0).Create();
            note.IsDeleted = false;
            note.UserId = userId;



            // Act 
            var createdNote = await _sut.CreateAsync(note);
            createdNote!.Title = "New Title";
            createdNote.Text = "New Text";

            // Assert
            var updatedUser = await _sut.UpdateAsync(createdNote);
            updatedUser.Should().NotBeNull();
            updatedUser!.Title.Should().BeEquivalentTo(createdNote.Title);
            updatedUser.Text.Should().BeEquivalentTo(createdNote.Text);
        }

        [Fact]
        public async Task Delete_ShouldReturn_True_IfDeleted()
        {
            // Arrange
            var fixture = new Fixture();
            var note = fixture.Build<Note>().With(x => x.Id, 0).Create();
            note.IsDeleted = false;
            note.UserId = userId;


            // Act 
            var createdNote = await _sut.CreateAsync(note);

            // Assert
            var updatedUser = await _sut.DeleteAsync(createdNote.Id);
            updatedUser.Should().BeTrue();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(25)]
        public async Task Delete_ShouldReturn_False_IfRecord_DoesntExist(int id)
        {
            // Arrange

            // Act 
            var updatedNote = await _sut.DeleteAsync(id);

            // Assert
            updatedNote.Should().BeFalse();
        }


        private async void Setup()
        {
            try
            {
                var fixture = new Fixture();
                var user = fixture.Build<User>().With(x => x.Id, 0).Create();
                await _context.AddAsync(user);
                await _context.SaveChangesAsync();
                userId = user.Id;
            }
            catch (Exception ex) { throw; }
        }

    }
}
