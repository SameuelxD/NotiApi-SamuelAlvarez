using System.ComponentModel.DataAnnotations;

namespace Core.Entities;
    public class TipoNotificacion : BaseEntity
    {
        [MaxLength(80)]
        public string NombreTipo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public ICollection<ModuloNotificacion> ModuloNotificaciones { get; set; }
        public ICollection<Blockchain> Blockchains { get; set; }
    }
