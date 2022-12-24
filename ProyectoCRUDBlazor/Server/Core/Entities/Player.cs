using System.ComponentModel.DataAnnotations;

namespace ProyectoCRUDBlazor.Server.Core.Entities;

public class Player : EntityBase
{
    //public int Id { get; set; }

    [Required(ErrorMessage = "El campo {0} es requerido.")]
    public string Name { get; set; }

    public int Position { get; set; }
}
