namespace ExpensesTracker.DAO.IService
{
    public interface IService<TEntity>
    {
        TEntity ObterPorId(int id);

        bool Adicionar(TEntity entity);

        bool Deletar(int id);
    }
}
