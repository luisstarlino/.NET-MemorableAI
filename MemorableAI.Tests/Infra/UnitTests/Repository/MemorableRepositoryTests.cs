using MemorableAI.Infra.Repository;
using MemorableAI.Tests.Infra.UnitTests.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemorableAI.Tests.Infra.UnitTests.Repository
{
    public class MemorableRepositoryTests
    {
        [Fact]
        public async Task AddNewTask_Should_Add_Successfully()
        {
            //------------------------------------------------------------------------------------------------
            // --- Arrange
            //------------------------------------------------------------------------------------------------
            var context = new FakeMemorableDBContext().GetInMemoryDbContext();
            var titleMoc = "Integration Title Test";
            var repository = new MemorableRepository(context);

            var newTask = new MemorableAI.Domain.Models.Task(titleMoc, "Test");

            //------------------------------------------------------------------------------------------------
            // --- Act
            //------------------------------------------------------------------------------------------------
            var taskId = await repository.AddNewTask(newTask);

            //------------------------------------------------------------------------------------------------
            // --- Assert
            //------------------------------------------------------------------------------------------------
            var addedTask = await repository.GetUniqueTaskById(taskId);
            Assert.NotNull(addedTask);
            Assert.Equal(titleMoc, addedTask.Title);
        }
    }
}
