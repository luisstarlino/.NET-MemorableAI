using Memorable.Web.Controllers.Core;
using MemorableAI.Application.Interfaces;
using MemorableAI.Application.Models;
using MemorableAI.Domain.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Memorable.Web.Controllers
{
    [ApiController]
    [Route("task")]
    public class TaskController : BaseController
    {
        // ------------------------------------
        // -- D.I 
        // ------------------------------------
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        /// <summary>
        /// Get all Tasks
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> ListAllTasks()
        {
            try
            {
                //------------------------------------------------------------------------------------------------
                // LIST TASK'S
                //------------------------------------------------------------------------------------------------
                var tasks = await _taskService.GetAllTask();
                if (tasks.Count() == 0) return CreateBaseResponse(HttpStatusCode.NoContent);
                else return CreateBaseResponse(HttpStatusCode.OK, tasks);
            }
            catch (Exception ex)
            {
                return CreateBaseResponse(HttpStatusCode.InternalServerError, "ERR01-Internal server error. Please, contact the administrator");
            }
        }

        /// <summary>
        /// Create a new Task
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddNewTask([FromBody] TaskRequestModel model)
        {
            try
            {
                //------------------------------------------------------------------------------------------------
                // R1. Check all parameters
                //------------------------------------------------------------------------------------------------
                if (ModelState.IsValid is false) return CreateBaseResponse(HttpStatusCode.BadRequest, StringHelper.MISSING_PARAMETERS);
                else if (model.Title.IsEmpty() || model.Description.IsEmpty()) return CreateBaseResponse(HttpStatusCode.BadRequest, StringHelper.MISSING_PARAMETERS);

                //------------------------------------------------------------------------------------------------
                // R2. Has a prompt?
                //------------------------------------------------------------------------------------------------
                var hasPrompt = model.Prompt.IsEmpty() == false;
                
                //------------------------------------------------------------------------------------------------
                // R2. Call service and insert 
                //------------------------------------------------------------------------------------------------
                var addedTask = await _taskService.ProcessAndSaveNewTask(model, hasPrompt);

                if (addedTask == null) return CreateBaseResponse(HttpStatusCode.BadRequest, "ERR03-We can't create the task right now. Try Again Later");

                return CreateBaseResponse(HttpStatusCode.Created, addedTask);
            }
            catch (Exception ex)
            {
                return CreateBaseResponse(HttpStatusCode.InternalServerError, "ERR02-Internal server erro. Can't add a new task right now. Try again later.");
            }
        }

    }
}
