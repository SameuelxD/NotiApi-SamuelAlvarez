
using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

    public class RolVsMaestro: BaseEntity
    {
        public int IdRol { get; set; }
        public int IdMaestro { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }

    }
