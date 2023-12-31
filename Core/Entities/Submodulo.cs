
using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public class Submodulo : BaseEntity
{
    public string NombreSubmodulo { get; set; }
    public DateTime FechaCreacion { get; set; }
    public DateTime FechaModificacion { get; set; }
    public ICollection<MaestrosVsSubmodulo> MaestrosVsSubmodulos { get; set; }
}
