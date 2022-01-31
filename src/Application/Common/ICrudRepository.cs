namespace Application.Common
{
    public interface ICrudRepository<T> where T : class
    {
        Task<T> GetAsync(int id);  
        Task<T[]> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
    }
}
