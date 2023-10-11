
using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public class Formato : BaseEntity
{
    [MaxLength(50)]
    public string NombreFormato { get; set; }
    public DateTime FechaCreacion { get; set; }
    public DateTime FechaModificacion { get; set; }
}
