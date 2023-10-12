using System.ComponentModel.DataAnnotations;
namespace Core.Entities;

    public class MaestrosVsSubmodulo : BaseEntity
    {
        public int IdMaestro { get; set; }
        public int IdSubmodulo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public ICollection<GenericosVsSubmodulo> GenericosVsSubmodulos { get; set; }
        public ModulosMaestro ModulosMaestros { get; set; }
        public Submodulo Submodulos { get; set; }
    }
