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
    }
}
