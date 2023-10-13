using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

    public class HiloRespuestaNotificacion : BaseEntity
    {
        public string NombreTipo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public ICollection<ModuloNotificacion> ModulosNotificaciones { get; set; }
        public ICollection<Blockchain> Blockchains { get; set; }
    }
