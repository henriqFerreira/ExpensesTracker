using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
        public static AspNetUser ObterPorEmail(
            this UserManager<AspNetUser> userManager,
            string email,
            string includeProperties = ""
        )
        {
            var query = userManager.Users.AsQueryable();

            foreach (var includeProperty in includeProperties.Split(
                new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return query.FirstOrDefault(x => x.Email == email);
        }
    }
}
