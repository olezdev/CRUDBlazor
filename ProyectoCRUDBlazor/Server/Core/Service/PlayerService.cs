using ProyectoCRUDBlazor.Server.Core.Entities;
using ProyectoCRUDBlazor.Server.Core.Repository.Interface;
using ProyectoCRUDBlazor.Server.Core.Service.Interface;

namespace ProyectoCRUDBlazor.Server.Core.Service;

public class PlayerService : IPlayerService
{
    private readonly IUnitOfWork _unitOfWork;

    public PlayerService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<Player>> GetAllPlayerAsync()
    {
        return await _unitOfWork.PlayerRepository.GetAllAsync();
    }

    public async Task<Player> GetPlayerAsync(int id)
    {
        return await _unitOfWork.PlayerRepository.GetByIdAsync(id);
    }

    public async Task<Player> CreatePlayerAsync(Player player)
    {
        Player newPlayer = new Player();
        newPlayer.Name = player.Name;
        newPlayer.Position = player.Position;

        await _unitOfWork.PlayerRepository.CreateAsync(newPlayer);
        await _unitOfWork.SaveChangesAsync();

        return player;
    }

    public async Task UpdatePlayerAsync(int id, Player player)
    {
        if (player.Id == id)
        {
            _unitOfWork.PlayerRepository.Update(player);
            await _unitOfWork.SaveChangesAsync();
        }
    }

    public async Task DeleteByIdAsync(int id)
    {
        var playerToDelete = await _unitOfWork.PlayerRepository.GetByIdAsync(id);

        if (playerToDelete is not null)
        {
            _unitOfWork.PlayerRepository.Delete(playerToDelete);
            await _unitOfWork.SaveChangesAsync();
        }
    }

}
