using FluentAssertions;
using MemorableAI.Application.Interfaces;
using MemorableAI.Application.Models;
using MemorableAI.Application.Services;
using MemorableAI.Domain.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemorableAI.Tests.Application.IntegrationTests.Services
{
    public class TaskServiceTest
    {
        private Mock<IMemorableRepository> _repositoryMock;
        private readonly TaskService _service;

        public TaskServiceTest()
        {
            _repositoryMock = new Mock<IMemorableRepository>();
            _service = new TaskService(_repositoryMock.Object);
        }

        [Fact]
        public async Task ProcessAndSaveNewTask_Should_Return_Task_When_Success()
        {
            //------------------------------------------------------------------------------------------------
            // --- Arrange
            //------------------------------------------------------------------------------------------------
            var request = new TaskRequestModel { Title = "Test", Description = "Some Description" };

            // --- Arrange the repository mock to return '1' as the new task ID when AddNewTask is called with any Task object
            _repositoryMock.Setup(repo => repo.AddNewTask(It.IsAny<MemorableAI.Domain.Models.Task>())).ReturnsAsync(1);

            //------------------------------------------------------------------------------------------------
            // --- Act
            //------------------------------------------------------------------------------------------------
            var result = await _service.ProcessAndSaveNewTask(request);

            //------------------------------------------------------------------------------------------------
            // --- Arrange
            //------------------------------------------------------------------------------------------------
            result.Should().NotBeNull();
            result.Title.Should().Be("Test");
            result.Description.Should().Contain("Description");
        }

        [Fact]
        public async Task GetAllTask_Should_Return_List_Of_Tasks()
        {
            //------------------------------------------------------------------------------------------------
            // --- Arrange
            //------------------------------------------------------------------------------------------------
            var tasks = new List<MemorableAI.Domain.Models.Task>()
            {
                new MemorableAI.Domain.Models.Task("Task One", "Description One"),
                new MemorableAI.Domain.Models.Task("Task Two", "Description Two"),
            };

            // --- Arrange the repository mock to return a list of task
            _repositoryMock.Setup(repo => repo.GetAllTask()).ReturnsAsync(tasks);

            //------------------------------------------------------------------------------------------------
            // --- Act
            //------------------------------------------------------------------------------------------------
            var getTaks = await _service.GetAllTask();

            //------------------------------------------------------------------------------------------------
            // --- Arrange
            //------------------------------------------------------------------------------------------------
            getTaks.Should().HaveCount(2);
        }

        [Fact]
        public async Task GetTaskById_Should_Return_Task_When_Found()
        {
            //------------------------------------------------------------------------------------------------
            // --- Arrange
            //------------------------------------------------------------------------------------------------
            var task = new MemorableAI.Domain.Models.Task("Test", "Description") { Id = 1 };

            // --- Arrange the repository mock to return a task
            _repositoryMock.Setup(repo => repo.GetUniqueTaskById(1)).ReturnsAsync(task);

            //------------------------------------------------------------------------------------------------
            // --- Act
            //------------------------------------------------------------------------------------------------
            var result = await _service.GetTaskById(1);

            //------------------------------------------------------------------------------------------------
            // --- Assert
            //------------------------------------------------------------------------------------------------
            result.Should().NotBeNull();
            result!.Id.Should().Be(1);
        }

        [Fact]
        public async Task GetTaskById_Should_Return_Null_When_Exception_Occurs()
        {
            //------------------------------------------------------------------------------------------------
            // --- Arrange
            //------------------------------------------------------------------------------------------------
            _repositoryMock.Setup(repo => repo.GetUniqueTaskById(It.IsAny<int>())).ThrowsAsync(new Exception("DB error"));

            //------------------------------------------------------------------------------------------------
            // --- Act
            //------------------------------------------------------------------------------------------------
            var result = await _service.GetTaskById(99);

            //------------------------------------------------------------------------------------------------
            // --- Assert
            //------------------------------------------------------------------------------------------------
            result.Should().BeNull();
        }

        [Fact]
        public async Task DeleteTask_Should_Return_Deleted_Task()
        {
            //------------------------------------------------------------------------------------------------
            // --- Arrange
            //------------------------------------------------------------------------------------------------
            var task = new MemorableAI.Domain.Models.Task("DeleteMe", "Will be deleted") { Id = 5 };

            // --- Prepare the mock / repository to run this method and reeturn a task
            _repositoryMock.Setup(repo => repo.DeleteTask(5)).ReturnsAsync(task);

            //------------------------------------------------------------------------------------------------
            // --- Act
            //------------------------------------------------------------------------------------------------
            var result = await _service.DeleteTask(5);

            //------------------------------------------------------------------------------------------------
            // --- Assert
            //------------------------------------------------------------------------------------------------
            result.Should().NotBeNull();
            result!.Title.Should().Be("DeleteMe");
        }

        [Fact]
        public async Task UpdateTaskById_Should_Return_Updated_Task()
        {
            //------------------------------------------------------------------------------------------------
            // --- Arrange
            //------------------------------------------------------------------------------------------------
            var update = new TaskSearchRequestModel
            {
                Title = "Updated Title",
                Description = "Updated Description"
            };

            var updated = new MemorableAI.Domain.Models.Task("Updated Title", "Updated Description") { Id = 3 };

            // --- Prepare the mock / repository to run this method and update a task
            _repositoryMock.Setup(repo => repo.UpdateTask(It.IsAny<MemorableAI.Domain.Models.Task>(), 3)).ReturnsAsync(updated);

            //------------------------------------------------------------------------------------------------
            // --- Act
            //------------------------------------------------------------------------------------------------
            var result = await _service.UpdateTaskById(3, update);

            //------------------------------------------------------------------------------------------------
            // --- Arrange
            //------------------------------------------------------------------------------------------------
            result.Should().NotBeNull();
            result!.Title.Should().Be("Updated Title");
        }




    }
}
