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
        public string Title { get; set; }
        public string Description { get; set; }
        public string CreateBy { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        //public EnumStatusTarefa Status { get; set; }
    }
}
