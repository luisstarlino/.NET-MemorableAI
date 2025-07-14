using MemorableAI.Application.Models;
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
        Task<Domain.Models.Task?> ProcessAndSaveNewTask(TaskRequestModel newTask, bool hasPrompt);
        Task<Domain.Models.Task> UpdateTaskById(int idTask, Domain.Models.Task updatedTask);
    }
}
