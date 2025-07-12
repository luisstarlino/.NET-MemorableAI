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

        async public Task<Domain.Models.Task?> UpdateTask(Domain.Models.Task updatedTask, int idTask)
        {
            try
            {
                // -- Find
                // -- FIND TASK
                var taskToUpdate = await _context.Tasks.FindAsync(idTask);
                if (taskToUpdate == null) throw new Exception("Not found");
                else
                {
                    taskToUpdate.Description = updatedTask.Description;
                    taskToUpdate.Title = updatedTask.Title;

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
