using ExpensesTracker.DAO.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpensesTracker.DAO.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> User { get; set; }
    }
}
