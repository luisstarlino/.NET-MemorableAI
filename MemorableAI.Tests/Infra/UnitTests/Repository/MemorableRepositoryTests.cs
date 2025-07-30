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

        [Fact]
        public async Task GetAllTask_Should_Return_All_Tasks()
        {
            //------------------------------------------------------------------------------------------------
            // --- Arrange
            //------------------------------------------------------------------------------------------------
            var context = new FakeMemorableDBContext().GetInMemoryDbContext();
            var repository = new MemorableRepository(context);
            var task1 = new MemorableAI.Domain.Models.Task("Task 1", "Some description 1");
            var task2 = new MemorableAI.Domain.Models.Task("Task 2", "Some description 2");

            //------------------------------------------------------------------------------------------------
            // --- Act
            //------------------------------------------------------------------------------------------------
            await repository.AddNewTask(task1);
            await repository.AddNewTask(task2);

            //------------------------------------------------------------------------------------------------
            // --- Assert
            //------------------------------------------------------------------------------------------------
            var taskCount = await repository.GetAllTask();

            Assert.Equal(2, taskCount.Count);
        }

        [Fact]
        public async Task DeleteTask_Should_Remove_Task()
        {
            //------------------------------------------------------------------------------------------------
            // --- Arrange
            //------------------------------------------------------------------------------------------------
            var context = new FakeMemorableDBContext().GetInMemoryDbContext();
            var repository = new MemorableRepository(context);
            var task1 = new MemorableAI.Domain.Models.Task("Task Temporary", "Task to delete");

            //------------------------------------------------------------------------------------------------
            // --- Act
            //------------------------------------------------------------------------------------------------
            var taskId = await repository.AddNewTask(task1);
            var hasDeletedTask = await repository.DeleteTask(taskId);

            //------------------------------------------------------------------------------------------------
            // --- Assert
            //------------------------------------------------------------------------------------------------
            Assert.NotNull(hasDeletedTask);
            Assert.Null(await repository.GetUniqueTaskById(taskId));

        }
    }
}
