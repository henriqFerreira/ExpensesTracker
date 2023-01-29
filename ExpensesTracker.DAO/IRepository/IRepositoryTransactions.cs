using ExpensesTracker.DAO.Data;
using ExpensesTracker.DAO.Models;

namespace ExpensesTracker.DAO.IRepository
{
    public interface IRepositoryTransactions : IRepository<Transactions, ApplicationDbContext>
    {

    }
}
