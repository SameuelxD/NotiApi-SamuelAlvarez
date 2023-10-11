using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

    public class HiloRespuestaNotificacion : BaseEntity
    {
        [MaxLength(80)]
        public string NombreTipo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
