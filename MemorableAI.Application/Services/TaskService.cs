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

        public async Task<Domain.Models.Task?> DeleteTask(int idTask)
        {
            // ------------------------------------
            // --- R1. Delete task
            // ------------------------------------
            var deletedTask = await _repository.DeleteTask(idTask);
            return deletedTask;
        }

        async public Task<IEnumerable<Domain.Models.Task>> GetAllTask()
        {
            // ------------------------------------
            // --- R1. Get info
            // ------------------------------------
            var tasks = await _repository.GetAllTask();

            return tasks;
        }

        async public Task<IEnumerable<Domain.Models.Task?>> GetTaskByDescription(string descriptionSearch)
        {
            var tasks = await _repository.GetUniqueTaskByDescription(descriptionSearch);
            return tasks;
        }

        async public Task<Domain.Models.Task?> GetTaskById(int idTask)
        {
            try
            {
                // ------------------------------------
                // --- R1. Get info
                // ------------------------------------
                var searchTask = await _repository.GetUniqueTaskById(idTask);
                return searchTask;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"***** GetTaskById:ERROR:{ex.Message}");
                return null;
            }
        }

        async public Task<IEnumerable<Domain.Models.Task?>> GetTaskByTitle(string titleSearch)
        {
            var tasks = await _repository.GetUniqueTaskByTitle(titleSearch);
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
                        Date = DateTime.UtcNow,
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

        public async Task<Domain.Models.Task?> UpdateTaskById(int idTask, TaskSearchRequestModel updatedTask)
        {
            try
            {

                // ------------------------------------
                // --- R1. Create DB Model
                // ------------------------------------
                var dbModel = new Domain.Models.Task
                {
                    Description = updatedTask.Description ?? "",
                    Title = updatedTask.Title ?? ""
                };

                // ------------------------------------
                // --- R1. Call repository
                // ------------------------------------
                var taskUpd = await _repository.UpdateTask(dbModel, idTask);
                return taskUpd;
            }
            catch (Exception ex){
                return null;
            }
        }
    }
}
