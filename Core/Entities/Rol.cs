
using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

    public class Rol : BaseEntity
    {
        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public ICollection<GenericosVsSubmodulo> GenericosVsSubmodulos { get; set; }
        public ICollection<RolVsMaestro> RolVsMaestros { get; set; }
    }
