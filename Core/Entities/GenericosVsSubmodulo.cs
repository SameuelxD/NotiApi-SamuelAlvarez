using System.ComponentModel.DataAnnotations;
namespace Core.Entities;

    public class GenericosVsSubmodulo : BaseEntity
    {
        public int IdGenerico { get; set; }
        public int IdSubmodulo { get; set; }
        public int IdRol { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public Rol Roles { get; set; }
        public PermisoGenerico PermisosGenericos { get; set; }
        public MaestrosVsSubmodulo MaestrosVsSubmodulos { get; set; }
    }
