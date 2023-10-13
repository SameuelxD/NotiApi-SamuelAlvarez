using System.ComponentModel.DataAnnotations;

namespace Core.Entities;
    public class TipoRequerimiento : BaseEntity
    {
        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public ICollection<ModuloNotificacion> ModulosNotificaciones { get; set; }
    }


