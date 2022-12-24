using ProyectoCRUDBlazor.Server.Core.Entities;

namespace ProyectoCRUDBlazor.Server.Core.Service.Interface;

public interface IPlayerService
{
    Task<List<Player>> GetAllPlayerAsync();
    Task<Player> GetPlayerAsync(int id);
    Task<Player> CreatePlayerAsync(Player newPlayer);
    Task UpdatePlayerAsync(int id, Player updatePlayer);
    Task DeleteByIdAsync(int id);
}
