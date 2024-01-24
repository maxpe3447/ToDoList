using Microsoft.AspNetCore.Mvc;

namespace ToDoListApi.Controllers
{
    public class FallBackController : Controller
    {
        public ActionResult Index()
        {
            return PhysicalFile(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "browser", "index.html"), "text/html");
        }
    }
}
