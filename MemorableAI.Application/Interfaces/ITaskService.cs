using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemorableAI.Application.Interfaces
{
    public interface ITaskService
    {
        Task<IEnumerable<Domain.Models.Task>> GetAllTask();
        Task<Domain.Models.Task> ProcessAndSaveNewTask(Domain.Models.Task newTask, string? taskByPrompt);
        Task<Domain.Models.Task> UpdateTaskById(int idTask, Domain.Models.Task updatedTask);
    }
}
