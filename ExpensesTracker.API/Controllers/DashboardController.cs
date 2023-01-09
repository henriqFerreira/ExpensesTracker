using Microsoft.AspNetCore.Mvc;

namespace ExpensesTracker.API.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
