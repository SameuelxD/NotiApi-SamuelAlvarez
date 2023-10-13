using System.ComponentModel.DataAnnotations;
namespace Core.Entities;
    public class ModuloNotificacion : BaseEntity
    {
        public string AsuntoNotificacion { get; set; }
        public int IdNotificacion { get; set; }
        public int IdRadicado { get; set; }
        public int IdEstadoNotificacion { get; set; }
        public int IdHiloRespuesta { get; set; }
        public int IdFormato { get; set; }
        public int IdRequerimiento { get; set; }
        public string TextoNotificacion { get; set;} 
        public DateTime FechaCreacion { get; set;}
        public DateTime FechaModificacion { get; set;}
        public Radicado Radicados { get; set; }
        public Formato Formatos { get; set; }
        public EstadoNotificacion EstadosNotificaciones { get; set; }
        public TipoRequerimiento TiposRequerimientos { get; set; }
        public HiloRespuestaNotificacion HiloRespuestasNotificaciones { get; set; }
        public TipoNotificacion TiposNotificaciones { get; set; }

    }
