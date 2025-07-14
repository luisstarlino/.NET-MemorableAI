using MemorableAI.Application.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Memorable.Web.Controllers.Core
{
    public class BaseController : ControllerBase
    {
        /// <summary>
        /// Objeto padronizado de resposta
        /// </summary>
        /// <param name="statusCode">Código HTTP</param>
        /// <param name="message">Mensagem</param>
        /// <returns>OBjeto IAction Result</returns>
        protected IActionResult CreateBaseResponse(HttpStatusCode statusCode, object message)
        {
            var resp = new BaseResponseModel(checkStatusCode(statusCode), message);

            return StatusCode((int)statusCode, resp);
        }

        protected IActionResult CreateBaseResponse(HttpStatusCode code)
        {
            return StatusCode((int)code);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected IActionResult CreateBaseResponse()
        {
            var resp = new BaseResponseModel();
            return StatusCode((int)HttpStatusCode.OK, resp);
        }

        private bool checkStatusCode(HttpStatusCode code)
        {
            List<HttpStatusCode> trueCodes = new List<HttpStatusCode> { HttpStatusCode.OK, HttpStatusCode.Accepted, HttpStatusCode.Created };
            return trueCodes.Contains(code);
        }
    }
}
