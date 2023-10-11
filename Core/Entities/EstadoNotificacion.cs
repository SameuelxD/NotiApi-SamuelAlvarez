using System.ComponentModel.DataAnnotations;

namespace Core.Entities;
    public class EstadoNotificacion : BaseEntity
    {
        [MaxLength(50)]
        public string NombreEstado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
    }


