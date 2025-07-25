using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemorableAI.Application.Interfaces
{
    public interface IOpenAIService
    {
        Task<List<Domain.Models.Task>?> GenerateTaskByPrompt(string prompt);
    }
}
