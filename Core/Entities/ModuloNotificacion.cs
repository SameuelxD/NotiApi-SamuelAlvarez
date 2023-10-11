using System.ComponentModel.DataAnnotations;
namespace Core.Entities;
    public class ModuloNotificacion : BaseEntity
    {
        [MaxLength(80)]
        public string AsuntoNotificacion { get; set; }
        public int IdNotificacion { get; set; }
        public int IdRadicado { get; set; }
        public int IdEstadoNotificacion { get; set; }
        public int IdHiloRespuesta { get; set; }
        public int IdFormato { get; set; }
        public int IdRequerimiento { get; set; }
        [MaxLength(2000)]
        public string TextoNotificacion { get; set;} 
        public DateTime FechaCreacionNotificacion { get; set;}
        public DateTime FechaModificacionNotificacion { get; set;}

        
    }
