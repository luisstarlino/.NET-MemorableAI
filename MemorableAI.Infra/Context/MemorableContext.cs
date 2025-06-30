using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemorableAI.Infra.Context
{
    public class MemorableContext : DbContext
    {
        public MemorableContext(DbContextOptions<MemorableContext> options) : base(options){}

        public DbSet<Task> Tasks { get; set; }

    }
}
