using System.ComponentModel.DataAnnotations;

namespace ProyectoCRUDBlazor.Server.Core.Entities;

public class EntityBase
{
    [Key]
    public int Id { get; set; }
}
