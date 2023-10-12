
using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

    public class ModulosMaestro : BaseEntity
    {
        [MaxLength(100)]
        public string NombreModulo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public ICollection<RolVsMaestro> RolVsMaestros { get; set; }
        public ICollection<MaestrosVsSubmodulo> MaestrosVsSubmodulos { get; set; }

    }
