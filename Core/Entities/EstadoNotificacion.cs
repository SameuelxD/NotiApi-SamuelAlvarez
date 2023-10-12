using System.ComponentModel.DataAnnotations;

namespace Core.Entities;
    public class EstadoNotificacion : BaseEntity
    {
        public string NombreEstado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public ICollection<ModuloNotificacion> ModuloNotificaciones { get; set; }
    }


