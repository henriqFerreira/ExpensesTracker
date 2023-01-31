using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpensesTracker.DAO.Models
{
    public class AspNetUser : IdentityUser
    {
        [InverseProperty("IdAspNetUserNavigation")]
        public User User { get; set; }
    }

    public static class UserExtensions
    {
        public static AspNetUser ObterPorEmail
            (
                this UserManager<AspNetUser> userManager,
                string email
            )
        {
            var query = userManager.Users.AsQueryable();
            return query.FirstOrDefault(x => x.Email == email);
        }
    }
}
