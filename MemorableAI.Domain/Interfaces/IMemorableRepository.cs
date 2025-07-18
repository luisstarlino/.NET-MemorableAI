using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemorableAI.Domain.Interfaces
{
    public interface IMemorableRepository
    {
        Task<int> AddNewTask(Models.Task newTaskModel);
        Task<Models.Task?> DeleteTask(int idTask);
        Task<Models.Task?> UpdateTask(Models.Task updatedTask, int idTask);
        Task<List<Models.Task>> GetAllTask();
        Task<Models.Task?> GetUniqueTaskById(int idTask);
        Task<IEnumerable<Models.Task?>> GetUniqueTaskByTitle(string title);
        Task<IEnumerable<Models.Task?>> GetUniqueTaskByDescription(string description);
    }
}
