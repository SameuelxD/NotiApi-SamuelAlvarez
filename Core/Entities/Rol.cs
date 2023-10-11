
using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

    public class Rol : BaseEntity
    {
        [MaxLength(100)]
        public string NombreRol { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
