using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCRUDBlazor.Shared.Models;

public class PlayerDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El campo {0} es requerido.")]
    public string Name { get; set; }

    public int Position { get; set; }
}
