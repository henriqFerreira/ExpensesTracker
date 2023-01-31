using ExpensesTracker.DAO.Data;
using ExpensesTracker.DAO.IRepository;
using ExpensesTracker.DAO.Models;

namespace ExpensesTracker.DAO.Repository
{
    public class RepositoryTransactions : Repository<Transaction, ApplicationDbContext>, IRepositoryTransactions
    {
        public RepositoryTransactions() : base() { }
        public RepositoryTransactions(ApplicationDbContext context) : base(context) { }
    }
}
