namespace TesteFluxoCaixa.Repository
{
    public interface IRepository<T>
    {
        Task<int> Add(T item);

        Task<List<T>> GetAll();

        Task<List<T>> GetSummary(DateTime Date);
    }
}
