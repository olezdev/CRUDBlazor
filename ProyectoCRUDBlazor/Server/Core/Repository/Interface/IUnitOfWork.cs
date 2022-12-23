using ProyectoCRUDBlazor.Server.Core.Entities;

namespace ProyectoCRUDBlazor.Server.Core.Repository.Interface;

public interface IUnitOfWork
{
    IRepository<Club> ClubRepository { get; }
    IRepository<Player> PlayerRepository { get; }

    void SaveChanges();
    Task SaveChangesAsync();
}
