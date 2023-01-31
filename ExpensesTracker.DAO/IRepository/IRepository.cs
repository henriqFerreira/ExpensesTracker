using Microsoft.EntityFrameworkCore;

namespace ExpensesTracker.DAO.IRepository
{
    public interface IRepository<TEntity, TContext>
        where TEntity : class
        where TContext : DbContext, new()
    {
        bool Insert();
        bool Delete(int id);
    }
}
