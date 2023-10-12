
using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

    public class PermisoGenerico : BaseEntity
    {
        [MaxLength(50)]
        public string NombrePermiso { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public ICollection<GenericosVsSubmodulo> GenericosVsSubmodulos { get; set; }

    }
