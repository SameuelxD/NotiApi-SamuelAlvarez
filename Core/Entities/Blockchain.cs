using System.ComponentModel.DataAnnotations;

namespace Core.Entities;
    public class Blockchain : BaseEntity 
    {
        public int IdNotificacion { get; set; }
        public int IdHiloRespuesta { get; set; }
        public int IdAuditoria { get; set; }
        [MaxLength(100)]
        public string HashGenerado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
    }

