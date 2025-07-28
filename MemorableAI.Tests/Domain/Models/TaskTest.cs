using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemorableAI.Tests.Domain.Models
{
    public class TaskTest
    {
        [Fact]
        public void Should_Create_Task_With_Valid_Properties()
        {
            //------------------------------------------------------------------------------------------------
            // --- Arrange
            //------------------------------------------------------------------------------------------------
            var createdAt = DateTime.Now;
            var createdBy = "xUNIT TESTE";

            //------------------------------------------------------------------------------------------------
            // --- Act
            //------------------------------------------------------------------------------------------------
            var task = new MemorableAI.Domain.Models.Task
            {
                Id = 1,
                CreateBy = createdBy,
                Title = "Study Unit Tests",
                Description = "This is a arrange to test properties. Using Domain Drive Design",
                Date = createdAt
            };

            //------------------------------------------------------------------------------------------------
            // --- Assert
            //------------------------------------------------------------------------------------------------
            task.Id.Should().Be(1);
            task.CreateBy.Should().Be(createdBy);
            task.Description.Should().Contain("Domain Drive Design");
            
        }
    }
}
