using System.ComponentModel.DataAnnotations;
namespace Core.Entities;

    public class Radicado : BaseEntity
    {
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; } 
        public ICollection<ModuloNotificacion> ModulosNotificaciones { get; set; }
    }
