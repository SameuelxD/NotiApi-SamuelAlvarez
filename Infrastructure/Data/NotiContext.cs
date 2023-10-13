using System.Reflection;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;
    public class NotiContext : DbContext { 
        public NotiContext (DbContextOptions options) : base(options){ }
        public DbSet<Radicado> Radicados { get; set; }
        public DbSet<Formato> Formatos { get; set; }
        public DbSet<EstadoNotificacion> EstadosNotificaciones { get; set; }
        public DbSet<TipoRequerimiento> TiposRequerimientos { get; set; }
        public DbSet<HiloRespuestaNotificacion> HiloRespuestasNotificaciones { get; set; }
        public DbSet<TipoNotificacion> TiposNotificaciones { get; set; }
        public DbSet<Blockchain> Blockchains { get; set; }
        public DbSet<Auditoria> Auditorias { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<PermisoGenerico> PermisosGenericos { get; set; }
        public DbSet<MaestrosVsSubmodulo> MaestrosVsSubmodulos { get; set; }
        public DbSet<ModulosMaestro> ModulosMaestros { get; set; }
        public DbSet<Submodulo> Submodulos { get; set; }
        public DbSet<RolVsMaestro> RolVsMaestros { get; set; }
        public DbSet<ModuloNotificacion> ModulosNotificaciones { get; set; }
        public DbSet<GenericosVsSubmodulo> GenericosVsSubmodulos { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
    
