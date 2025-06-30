using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemorableAI.Infra.Context
{
    public class MemorableContextFactory : IDesignTimeDbContextFactory<MemorableContext>
    {
        public MemorableContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MemorableContext>();

            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=memorabledb;Username=admin;Password=admin123");

            return new MemorableContext(optionsBuilder.Options);

        }
    }
}
