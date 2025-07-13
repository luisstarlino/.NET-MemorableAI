using Memorable.Web.Controllers.Core;
using MemorableAI.Application.Interfaces;
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

    }
}
