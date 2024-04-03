using WebApplication1.Models;

namespace HouseholdManagerApi.Interfaces.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(Guid id);
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        void Delete(Guid id);
    }
}
