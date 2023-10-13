using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;

namespace Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly NotiContext _context;
    private AuditoriaRepository _auditorias;
    private BlockchainRepository _blockchains;
    private EstadoNotificacionRepository _estadosnotificaciones;
    private FormatoRepository _formatos;
    private GenericosVsSubmoduloRepository _genericosvssubmodulos;
    private HiloRespuestaNotificacionRepository _hilorespuestasnotificaciones;
    private MaestrosVsSubmoduloRepository _maestrosvssubmodulos;
    private ModuloNotificacionRepository _modulosnotificaciones;
    private ModulosMaestroRepository _modulosmaestros;
    private PermisoGenericoRepository _permisosgenericos;
    private RadicadoRepository _radicados;
    private RolRepository _roles;
    private RolVsMaestroRepository _rolvsmaestros;
    private SubmoduloRepository _submodulos;
    private TipoNotificacionRepository _tiposnotificaciones;
    private TipoRequerimientoRepository _tiposrequerimientos;

    public IAuditoriaRepository Auditorias
    {
        get
        {
            if (_auditorias == null)
            {
                _auditorias = new AuditoriaRepository(_context);
            }
            return _auditorias;
        }
    }

    public IBlockchainRepository Blockchains
    {
        get
        {
            if (_blockchains == null)
            {
                _blockchains = new BlockchainRepository(_context);
            }
            return _blockchains;
        }
    }

    public IEstadoNotificacionRepository EstadosNotificaciones
    {
        get
        {
            if (_estadosnotificaciones == null)
            {
                _estadosnotificaciones = new EstadoNotificacionRepository(_context);
            }
            return _estadosnotificaciones;
        }
    }

    public IFormatoRepository Formatos
    {
        get
        {
            if (_formatos == null)
            {
                _formatos = new FormatoRepository(_context);
            }
            return _formatos;
        }
    }

    public IGenericosVsSubmoduloRepository GenericosVsSubmodulos
    {
        get
        {
            if (_genericosvssubmodulos == null)
            {
                _genericosvssubmodulos = new GenericosVsSubmoduloRepository(_context);
            }
            return _genericosvssubmodulos;
        }
    }

    public IHiloRespuestaNotificacionRepository HiloRespuestasNotificaciones
    {
        get
        {
            if (_hilorespuestasnotificaciones == null)
            {
                _hilorespuestasnotificaciones = new HiloRespuestaNotificacionRepository(_context);
            }
            return _hilorespuestasnotificaciones;
        }
    }

    public IMaestrosVsSubmoduloRepository MaestrosVsSubmodulos
    {
        get
        {
            if (_maestrosvssubmodulos == null)
            {
                _maestrosvssubmodulos = new MaestrosVsSubmoduloRepository(_context);
            }
            return _maestrosvssubmodulos;
        }
    }

    public IModuloNotificacionRepository ModulosNotificaciones
    {
        get
        {
            if (_modulosnotificaciones == null)
            {
                _modulosnotificaciones = new ModuloNotificacionRepository(_context);
            }
            return _modulosnotificaciones;
        }
    }

    public IModulosMaestroRepository ModulosMaestros
    {
        get
        {
            if (_modulosmaestros == null)
            {
                _modulosmaestros = new ModulosMaestroRepository(_context);
            }
            return _modulosmaestros;
        }
    }
    public IPermisoGenericoRepository PermisosGenericos
    {
        get
        {
            if (_permisosgenericos == null)
            {
                _permisosgenericos = new PermisoGenericoRepository(_context);
            }
            return _permisosgenericos;
        }
    }

    public IRadicadoRepository Radicados
    {
        get
        {
            if (_radicados == null)
            {
                _radicados = new RadicadoRepository(_context);
            }
            return _radicados;
        }
    }

    public IRolRepository Roles
    {
        get
        {
            if (_roles == null)
            {
                _roles = new RolRepository(_context);
            }
            return _roles;
        }
    }

    public IRolVsMaestroRepository RolVsMaestros
    {
        get
        {
            if (_rolvsmaestros == null)
            {
                _rolvsmaestros = new RolVsMaestroRepository(_context);
            }
            return _rolvsmaestros;
        }
    }

    public ISubmoduloRepository Submodulos
    {
        get
        {
            if (_submodulos == null)
            {
                _submodulos = new SubmoduloRepository(_context);
            }
            return _submodulos;
        }
    }

    public ITipoNotificacionRepository TiposNotificaciones
    {
        get
        {
            if (_tiposnotificaciones == null)
            {
                _tiposnotificaciones = new TipoNotificacionRepository(_context);
            }
            return _tiposnotificaciones;
        }
    }

    public ITipoRequerimientoRepository TiposRequerimientos
    {
        get
        {
            if (_tiposrequerimientos == null)
            {
                _tiposrequerimientos = new TipoRequerimientoRepository(_context);
            }
            return _tiposrequerimientos;
        }
    }

    public UnitOfWork(NotiContext context)
    {
        _context = context;
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }

}