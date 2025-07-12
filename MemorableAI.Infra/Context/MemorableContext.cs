using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MemorableAI.Infra.Context
{
    public class MemorableContext : DbContext
    {
        public MemorableContext(DbContextOptions<MemorableContext> options) : base(options){}

        public DbSet<MemorableAI.Domain.Models.Task> Tasks { get; set; }

    }
}
