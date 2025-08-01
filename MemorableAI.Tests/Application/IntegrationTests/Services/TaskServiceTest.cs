using MemorableAI.Application.Interfaces;
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
    }
}
