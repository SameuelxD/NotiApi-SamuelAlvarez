using System.ComponentModel.DataAnnotations;

namespace Core.Entities;
    public class Auditoria : BaseEntity
    {
        [MaxLength(100)]
        public string NombreUsuario { get; set; }
        public int  DescAccion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
    }


