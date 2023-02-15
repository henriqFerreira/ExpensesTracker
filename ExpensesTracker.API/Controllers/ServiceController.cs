using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesTracker.API.Controllers
{
    public class ServiceController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public ServiceController(
            RoleManager<IdentityRole> roleManager
            )
        {
            _roleManager = roleManager;
        }

        public async Task<IActionResult> GerarAdmin()
        {
            string name = "admin";
            string lastname = "admin";
            string email = "admin@expensestracker.com.br";
            string password = "!@Et2391";
            bool success;

            try
            {
                success = await GerarRoles();
            }
            catch (Exception) { success = false; }

            return Json(new { Ok = false, Title = "Error", Message = "GerarAdmin não implementado." });
        }

        public async Task<bool> GerarRoles()
        {
            var success = false;

            try
            {
                var role = new IdentityRole { Name = "Admin" };
                bool roleExists = await _roleManager.RoleExistsAsync(role.Name);

                if (!roleExists)
                {
                    var isCreated = await _roleManager.CreateAsync(role);
                    success = isCreated.Succeeded;
                }

                role = new IdentityRole { Name = "User" };
                roleExists = await _roleManager.RoleExistsAsync(role.Name);

                if (!roleExists)
                {
                    var isCreated = await _roleManager.CreateAsync(role);
                    success = isCreated.Succeeded;
                }

            }
            catch (Exception) { success = false; }

            return success;
        }
    }
}
