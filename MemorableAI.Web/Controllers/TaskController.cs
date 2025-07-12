using Microsoft.AspNetCore.Mvc;

namespace Memorable.Web.Controllers
{
    public class TaskController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
