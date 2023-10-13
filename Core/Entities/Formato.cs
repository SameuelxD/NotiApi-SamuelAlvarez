
using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public class Formato : BaseEntity
{
    public string NombreFormato { get; set; }
    public DateTime FechaCreacion { get; set; }
    public DateTime FechaModificacion { get; set; }
    public ICollection<ModuloNotificacion> ModulosNotificaciones { get; set; }
}
