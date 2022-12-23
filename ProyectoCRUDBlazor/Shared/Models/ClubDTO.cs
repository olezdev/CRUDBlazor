using System.ComponentModel.DataAnnotations;

namespace ProyectoCRUDBlazor.Shared.Models;

public class ClubDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El campo {0} es requerido.")]
    public string Name { get; set; }

    public DateTime DateFundation { get; set; }

    //public static async Task<List<ClubDTO>> GetAllAsync()
    //{
    //    List<ClubDTO> clubes = new List<ClubDTO>()
    //{
    //    new ClubDTO() { Id = 1, Name= "River Plate" },
    //    new ClubDTO() { Id = 1, Name= "Boca" },
    //    new ClubDTO() { Id = 1, Name= "Racing" },
    //    new ClubDTO() { Id = 1, Name= "Independiente" },
    //    new ClubDTO() { Id = 1, Name= "Quilmes" },
    //};
    //    return await Task.Run(() => clubes);
    //}

}

