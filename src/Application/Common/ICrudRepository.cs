namespace Application.Common
{
    public interface ICrudRepository<T> where T : class
    {
        Task<T?> GetAsync(int id);  
        Task<IList<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
    }
}
