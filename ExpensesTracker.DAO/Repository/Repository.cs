using ExpensesTracker.DAO.IRepository;
using Microsoft.EntityFrameworkCore;

namespace ExpensesTracker.DAO.Repository
{
    public abstract class Repository<TEntity, TContext> : IRepository<TEntity, TContext>
        where TEntity : class
        where TContext : DbContext, new()
    {
        internal TContext context;
        internal DbSet<TEntity> set;

        public Repository()
        {
            this.UpdateContext(new TContext());
        }

        public Repository(TContext context)
        {
            this.UpdateContext(context);
        }

        private void UpdateContext(TContext context)
        {
            this.context = context;
            this.set = context.Set<TEntity>();
        }

        bool IRepository<TEntity, TContext>.Delete(int id)
        {
            throw new NotImplementedException();
        }

        bool IRepository<TEntity, TContext>.Insert()
        {
            throw new NotImplementedException();
        }
    }
}
