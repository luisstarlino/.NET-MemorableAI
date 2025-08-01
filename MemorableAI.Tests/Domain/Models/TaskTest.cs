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
            var createdBy = "xUNIT TEST";

            //------------------------------------------------------------------------------------------------
            // --- Act
            //------------------------------------------------------------------------------------------------
            var task = new MemorableAI.Domain.Models.Task("Study Unit Tests", "This is a arrange to test properties. Using Domain Drive Design", createdBy);

            //------------------------------------------------------------------------------------------------
            // --- Assert
            //------------------------------------------------------------------------------------------------
            task.Id.Should().Be(0);
            task.CreateBy.Should().Be(createdBy);
            task.Description.Should().Contain("Domain Drive Design");
            
        }

        /// <summary>
        /// TODO: ADJUST DOMAIN TO FAIL IN THIS TEST. TITLE NEVER CAN BE NULL
        /// </summary>
        [Fact]
        public void Should_Throw_When_Title_Is_Empty()
        {
            //------------------------------------------------------------------------------------------------
            // --- Arrange
            //------------------------------------------------------------------------------------------------
            // Arrange
            var title = "";
            var description = "Fake Description";
            var createdBy = "xUNIT TESTE";

            //------------------------------------------------------------------------------------------------
            // --- Act
            //------------------------------------------------------------------------------------------------
            Action act = () => new MemorableAI.Domain.Models.Task(title, description, createdBy);

            //------------------------------------------------------------------------------------------------
            // --- Assert
            //------------------------------------------------------------------------------------------------
            act.Should().Throw<ArgumentException>().WithMessage("*Title cannot be null or empty*");
        }

        /// <summary>
        /// TODO: DO NOT ADD THE TASK WHEN THE DATA IS OLDER THAN TODAY.
        /// </summary>
        [Fact]
        public void Should_Allow_Past_Dates_But_Not_Too_Old()
        {
            //var task = new MemorableAI.Domain.Models.Task()
            //{
            //    Title = "Old Task",
            //    Date = new DateTime(2000, 1, 1)
            //};

            //task.Date.Year.Should().BeLessThan(2020); // Exploratory Validation Example
        }


    }
}
