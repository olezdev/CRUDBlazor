using ProyectoCRUDBlazor.Server.Core.Entities;

namespace ProyectoCRUDBlazor.Server.Core.Service.Interface;

public interface IClubService
{
    Task<List<Club>> GetAllClubAsync();
    Task<Club> GetClubAsync(int id);
    Task<Club> CreateAsync(Club newClub);
    Task UpdateClubAsync(int id, Club editClub);
    Task DeleteByIdAsync(int id);
}

//public interface IPersonaService
//{
//    Task<PersonaDto> Agregar(PersonaDto persona);
//}
