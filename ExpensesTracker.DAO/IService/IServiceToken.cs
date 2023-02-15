using ExpensesTracker.DAO.Models;

namespace ExpensesTracker.DAO.IService
{
    public interface IServiceToken
    {
        string GenerateToken(AspNetUser user, List<string> roles);
        CookieOptions GenerateCookies();
    }
}
