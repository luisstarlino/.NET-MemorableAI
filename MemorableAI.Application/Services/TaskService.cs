using MemorableAI.Application.Interfaces;
using MemorableAI.Application.Models;
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

        async public Task<Domain.Models.Task?> ProcessAndSaveNewTask(TaskRequestModel newTask, bool hasPrompt)
        {
            try
            {

                if (hasPrompt)
                {
                    // TODO: INTEGRATE IA
                    return null;
                } else
                {
                    // ------------------------------------
                    // --- R1. DBModel
                    // ------------------------------------
                    var taskModel = new Domain.Models.Task
                    {
                        Description = newTask.Description!,
                        Title = newTask.Title!,
                        CreateBy = "MemorableAI"
                    };

                    var hasCreated = await _repository.AddNewTask(taskModel);
                    if (hasCreated <= 0) return null;
                    return taskModel;
                }

            } catch (Exception ex)
            {
                return null;
            }
        }

        public Task<Domain.Models.Task> UpdateTaskById(int idTask, Domain.Models.Task updatedTask)
        {
            throw new NotImplementedException();
        }
    }
}
