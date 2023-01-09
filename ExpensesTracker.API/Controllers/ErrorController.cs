using ExpensesTracker.DAO.Models.Views;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesTracker.API.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : Controller
    {
        [HttpGet("HttpError/{id:length(3,3)}")]
        public IActionResult HttpError(int id)
        {
            var model = new ErrorVM();

            model.ErrorCode = id;
            model.Title= "Error title";
            model.Message = "Error message.";

            return View("Error", model);
        }
    }
}
