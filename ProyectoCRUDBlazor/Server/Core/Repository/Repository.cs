using Microsoft.EntityFrameworkCore;
using ProyectoCRUDBlazor.Server.Core.Entities;
using ProyectoCRUDBlazor.Server.Core.Repository.Interface;
using ProyectoCRUDBlazor.Server.Data;

namespace ProyectoCRUDBlazor.Server.Core.Repository;

public class Repository<T> : IRepository<T> where T : EntityBase
{
    private readonly AppDbContext _dbContext;
    protected readonly DbSet<T> _entities;

    public Repository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
        _entities = dbContext.Set<T>();
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _entities.ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _entities.FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<T> CreateAsync(T entity)
    {
        var result = await _entities.AddAsync(entity);
        return result.Entity;
    }

    public void  Update(T entity)
    {
       _entities.Entry(entity).State = EntityState.Modified;
    }

    public void Delete(T entity)
    {
        _entities.Remove(entity);
    }

}
