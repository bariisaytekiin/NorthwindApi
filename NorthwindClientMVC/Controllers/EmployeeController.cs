using Microsoft.AspNetCore.Mvc;

namespace NorthwindClientMVC.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
