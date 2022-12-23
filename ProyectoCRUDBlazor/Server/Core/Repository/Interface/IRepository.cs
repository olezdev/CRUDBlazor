using ProyectoCRUDBlazor.Server.Core.Entities;

namespace ProyectoCRUDBlazor.Server.Core.Repository.Interface;

public interface IRepository<T> where T : EntityBase
{
    Task<List<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task<T> CreateAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
}
