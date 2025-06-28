using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemorableAI.Domain.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CreateBy { get; set; }
        public DateTime Date { get; set; }
        //public EnumStatusTarefa Status { get; set; }
    }
}
