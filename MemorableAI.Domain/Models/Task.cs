using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemorableAI.Domain.Models
{
    public class Task
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public string CreateBy { get; set; }
        public DateTime Date { get; set; }
        
        protected Task()
        {
            // Default constructor for EF Core
        }

        public Task(string title, string description)
        {
            if(string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Title cannot be null or empty.", nameof(title));
            } 
            if(string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentException("Description cannot be null or empty.", nameof(description));
            }

            Title = title;
            Description = description;
            CreateBy = "MEMORABLE AI";
            Date = DateTime.Now;
        }

        public Task(string title, string description, string createdBy)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Title cannot be null or empty.", nameof(title));
            }
            if (string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentException("Description cannot be null or empty.", nameof(description));
            }

            Title = title;
            Description = description;
            CreateBy = createdBy;
            Date = DateTime.Now;
        }
    }
}
