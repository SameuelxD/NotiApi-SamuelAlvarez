using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUnitOfWork
    {
        
        IAuditoriaRepository Auditorias { get; }
        IBlockchainRepository Blockchains { get; }
        IEstadoNotificacionRepository EstadosNotificaciones { get; }
        IFormatoRepository Formatos { get; }
        IGenericosVsSubmoduloRepository GenericosVsSubmodulos { get; }
        IHiloRespuestaNotificacionRepository HiloRespuestasNotificaciones { get; }
        IMaestrosVsSubmoduloRepository MaestrosVsSubmodulos { get; }
        IModuloNotificacionRepository ModulosNotificaciones { get; }
        IModulosMaestroRepository ModulosMaestros { get; }
        IPermisoGenericoRepository PermisosGenericos { get; }
        IRadicadoRepository Radicados { get; }
        IRolRepository Roles { get; }
        IRolVsMaestroRepository RolVsMaestros { get; }
        ISubmoduloRepository Submodulos { get; }
        ITipoNotificacionRepository TiposNotificaciones { get; }
        ITipoRequerimientoRepository TiposRequerimientos { get; }
        Task<int> SaveAsync(); 
    }
}