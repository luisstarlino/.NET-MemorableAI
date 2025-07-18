using MemorableAI.Domain.Helpers;
using MemorableAI.Domain.Interfaces;
using MemorableAI.Domain.Models;
using MemorableAI.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemorableAI.Infra.Repository
{
    public class MemorableRepository : IMemorableRepository
    {
        private readonly MemorableContext _context;

        public MemorableRepository(MemorableContext context)
        {
            _context = context;
        }

        async public Task<int> AddNewTask(Domain.Models.Task newTaskModel)
        {
            try
            {
                await _context.Tasks.AddAsync(newTaskModel);
                await _context.SaveChangesAsync();
                return newTaskModel.Id;
            } catch
            {
                return -1;
            }
        }

        async public Task<Domain.Models.Task?> DeleteTask(int idTask)
        {
            try
            {
                // -- FIND TASK
                var taskToDelete = await _context.Tasks.FindAsync(idTask);
                if (taskToDelete == null) throw new Exception("Not found");
                else
                {
                    _context.Tasks.Remove(taskToDelete);
                    _context.SaveChanges();
                    return taskToDelete;
                }

            } catch
            {
                return null;
            }
        }

        async public Task<List<Domain.Models.Task>> GetAllTask()
        {
            return await _context.Tasks.ToListAsync();
        }

        async public Task<IEnumerable<Domain.Models.Task?>> GetUniqueTaskByDescription(string description)
        {
            try
            {
                // -- FIND TASK
                var tasks = await _context.Tasks.Where(t => t.Description.Contains(description)).ToListAsync();
                if (tasks == null) throw new Exception("Not found");
                else return tasks;
            }
            catch
            {
                return null;
            }
        }

        async public Task<Domain.Models.Task?> GetUniqueTaskById(int idTask)
        {
            try
            {
                // -- FIND TASK
                var taskToDelete = await _context.Tasks.FindAsync(idTask);
                if (taskToDelete == null) throw new Exception("Not found");
                else return taskToDelete;
                
            } catch
            {
                return null;
            }
        }

        async public Task<IEnumerable<Domain.Models.Task?>> GetUniqueTaskByTitle(string title)
        {
            try
            {
                // -- FIND TASK
                var tasks = await _context.Tasks.Where(t => t.Title.Contains(title)).ToListAsync();
                if (tasks == null) throw new Exception("Not found");
                else return tasks;
            }
            catch
            {
                return null;
            }
        }

        async public Task<Domain.Models.Task?> UpdateTask(Domain.Models.Task updatedTask, int idTask)
        {
            try
            {
                // -- Find
                var taskToUpdate = await _context.Tasks.FindAsync(idTask);
                if (taskToUpdate == null) throw new Exception("Not found");
                else
                {
                    taskToUpdate.Description = updatedTask.Description.IsEmpty() ? taskToUpdate.Description : updatedTask.Description;
                    taskToUpdate.Title = updatedTask.Title.IsEmpty() ? taskToUpdate.Title : updatedTask.Title;

                    await _context.SaveChangesAsync();
                    return taskToUpdate;
                }

            } catch
            {
                return null;
            }
        }
    }
}
