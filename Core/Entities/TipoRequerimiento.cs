using System.ComponentModel.DataAnnotations;

namespace Core.Entities;
    public class TipoRequerimiento : BaseEntity
    {
        [MaxLength(80)]
        public string NombreRequerimiento { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
    }


