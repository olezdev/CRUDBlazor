using ProyectoCRUDBlazor.Server.Core.Entities;
using ProyectoCRUDBlazor.Server.Core.Repository.Interface;
using ProyectoCRUDBlazor.Server.Data;

namespace ProyectoCRUDBlazor.Server.Core.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _dbContext;
    private readonly IRepository<Club> _clubRepository;
    private readonly IRepository<Player> _playerRepository;

    public UnitOfWork(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IRepository<Club> ClubRepository =>
        _clubRepository ?? 
        new Repository<Club>(_dbContext);

    public IRepository<Player> PlayerRepository =>
        _playerRepository ??
        new Repository<Player>(_dbContext);

    public void SaveChanges() =>
        _dbContext.SaveChanges();

    public async Task SaveChangesAsync() =>
        await _dbContext.SaveChangesAsync();
}
