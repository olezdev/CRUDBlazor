using ProyectoCRUDBlazor.Server.Core.Entities;
using ProyectoCRUDBlazor.Server.Core.Repository.Interface;
using ProyectoCRUDBlazor.Server.Core.Service.Interface;

namespace ProyectoCRUDBlazor.Server.Core.Service;

public class ClubService : IClubService
{
    private readonly IUnitOfWork _unitOfWork;

    public ClubService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<Club>> GetAllClubAsync()
    {
        return await _unitOfWork.ClubRepository.GetAllAsync();
    }

    public async Task<Club> GetClubAsync(int id)
    {
        return await _unitOfWork.ClubRepository.GetByIdAsync(id);
    }

    public async Task<Club> CreateAsync(Club club)
    {
        //await _context.Clubes.AddAsync(newClub);
        //_context.SaveChanges();
        //return newClub;
        Club newClub = new Club();

        newClub.Name = club.Name;
        newClub.DateFundation = club.DateFundation;

        await _unitOfWork.ClubRepository.CreateAsync(newClub);
        await _unitOfWork.SaveChangesAsync();

        return club;
    }

    public async Task UpdateClubAsync(int id, Club club)
    {
        if (club.Id == id)
        {
            _unitOfWork.ClubRepository.Update(club);
            await _unitOfWork.SaveChangesAsync();
        }

    }

    public async Task DeleteByIdAsync(int id)
    {
        var clubToDelete = await _unitOfWork.ClubRepository.GetByIdAsync(id);

        if (clubToDelete is not null)
        {
            _unitOfWork.ClubRepository.Delete(clubToDelete);
            await _unitOfWork.SaveChangesAsync();
        }
    }


}
