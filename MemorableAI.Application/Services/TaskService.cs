using MemorableAI.Application.Interfaces;
using MemorableAI.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemorableAI.Application.Services
{
    public class TaskService : ITaskService
    {
        private readonly IMemorableRepository _repository;

        public TaskService(IMemorableRepository repository)
        {
            _repository = repository;
        }

        async public Task<IEnumerable<Domain.Models.Task>> GetAllTask()
        {
            // ------------------------------------
            // --- R1. Get info
            // ------------------------------------
            var tasks = await _repository.GetAllTask();

            return tasks;
        }

        public Task<Domain.Models.Task> ProcessAndSaveNewTask(Domain.Models.Task newTask, string? taskByPrompt)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Models.Task> UpdateTaskById(int idTask, Domain.Models.Task updatedTask)
        {
            throw new NotImplementedException();
        }
    }
}
