using MemorableAI.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemorableAI.Tests.Infra.UnitTests.Context
{
    public class FakeMemorableDBContext
    { 
        public MemorableContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<MemorableContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Banco novo por teste
                .Options;

            var context = new MemorableContext(options);
            context.Database.EnsureCreated();
            return context;
        }
    }
}
