# NotiApi-SamuelAlvarez

# Creación de Solución

```
dotnet new sln
```

# Creación de proyectos

## Creacion proyecto ClassLib

```
dotnet new classlib -o Core
dotnet new classlib -o Infrastructure
```



## Creacion Proyecto WebApi

```
dotnet new webapi -o FolderDestino
```

El folder destino corresponde a la carpeta donde se creara el proyecto. Se recomienda que el nombre tenga la palabra Api Por ej. ApiAnimals.

# Agregar proyectos a la solucion

```
dotnet sln add ApiAnimals
dotnet sln add Core
dotnet sln add Infrastructure
```

# Agregar referencia entre Proyectos

Nota. Recuerde que las referencias se establecen desde el proyecto que contiene la referencia

```
dotnet add reference ..\Infrastructure
dotnet add reference ..\Core
```

# Instalacion de paquetes

## Proyecto WebApi

```
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer --version 7.0.10
dotnet add package Microsoft.EntityFrameworkCore --version 7.0.10
dotnet add package Microsoft.EntityFrameworkCore.Design --version 7.0.10
dotnet add package Microsoft.Extensions.DependencyInjection --version 7.0.0
dotnet add package System.IdentityModel.Tokens.Jwt --version 6.32.3
dotnet add package Serilog.AspNetCore --version 7.0.0
dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection --version 12.0.1
dotnet add package AspNetCoreRateLimit --version 5.0.0
```

## Proyecto Infrastructure

```
dotnet add package Pomelo.EntityFrameworkCore.MySql --version 7.0.0
dotnet add package Microsoft.EntityFrameworkCore --version 7.0.10
dotnet add package CsvHelper --version 30.0.1


```
![image](https://drive.google.com/uc?export=view&id=1pst95gYdKZcRnal7iGLq47HFKBkr4lsm)

# Conexion Base de Datos , Modo Desarrollo API/appsettings.Development.json y Modo Produccion API/appsettings.json
- Modo Desarrollo { API/appsettings.Development.json }
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "ConnectionStrings": {
    "MySqlConex": "server=localhost;user=root;password=123456;database=notiapi;"
  }
}

- Modo Produccion { API/appsettings.json }
  {
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "MySqlConex": "server=localhost;user=root;password=123456;database=notiapi;"
  }
}

# Generar archivo Context Infrastructure/Data/ArchivoContext.cs

using System.Reflection;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;
    public class NotiContext : DbContext {
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }

# Inyectar Conexion Base de Datos al Contenedor de Dependencia (Program.cs) API/Program.cs

builder.Services.AddSwaggerGen();
        -----        -----        -----        -----        -----        -----
builder.Services.AddDbContext<NotiContext>(options =>
{
    string connectionString = builder.Configuration.GetConnectionString("MySqlConex");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});
        -----        -----        -----        -----        -----        -----
var app = builder.Build();
 
# Generar BaseEntity Core/Entities/BaseEntity.cs y entidades Core/Entities/Entity.cs
- BaseEntity Core/Entities/BaseEntity.cs

namespace Core.Entities;                

public class BaseEntity        // BaseEntity se usa para que cada Entidad Herede propiedades que se tengan en comun en este caso {                                  para que herden un Id autoincrementable

        public int Id { get; set; }
}

-Entity Core/Entities/Entity.cs 

namespace Core.Entities;

public class Entity
{
        public int Entero { get; set; }    //Defina atributos respecto a la necesidad de la Entidad 
        public string String { get; set; }
        public DateTime Fecha { get; set; }
        public double Double { get; set; }
}

# Establecer Relaciones entre Entidades y Tablas 

- Relacion Uno a Uno

// Principal (padre)
public class Blog
{
    public int Id { get; set; }
    public BlogHeader? Header { get; set; } // Referencia de Navegacion para la Dependencia
}

// Dependent (hijo)
public class BlogHeader
{
    public int Id { get; set; }
    public Blog? Blog { get; set; } // Referencia Navegacion para la principal
}

- Relacion Uno a Muchos

// Principal (padre)
public class Blog
{
    public int Id { get; set; }
    public ICollection<Post> Posts { get; set; } // Navegacion de coleccion conteniendo dependencias
}

// Dependent (hijo)
public class Post
{
    public int Id { get; set; }
    public int? BlogId { get; set; } // Clave Foranea , ForeignKey
    public Blog? Blog { get; set; } // Referencia navegacion principal
}

- Relacion Muchos a Muchos

public class Post
{
    public int Id { get; set; }
    public List<Tag> Tags { get; set; }
}

public class Tag
{
    public int Id { get; set; }
    public List<Post> Posts { get; set; }
}

# Definir DbSet para ArchivoContext de cada Entidad Infrastrucutre/Data/NotiContext

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
    
# Crear las Configurations para cada Entidad Infrastructure/Data/Configuration/EntityConfiguration.cs

using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class AuditoriaConfiguration : IEntityTypeConfiguration<Auditoria>
    {
        public void Configure(EntityTypeBuilder<Auditoria> builder)
        {
            builder.ToTable("Auditoria"); // Nombre de la Tabla

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);
            
            builder.Property(p => p.NombreUsuario)    // Se definen las relaciones y se le da las caracteristicas a cada atributo de la Entidad
            .IsRequired()
            .HasMaxLength(100);                                           

            builder.Property(p => p.DescAccion)
            .HasColumnType("int");

            builder.Property(p => p.FechaCreacion)
            .HasColumnType("datetime");

            builder.Property(p => p.FechaModificacion)
            .HasColumnType("datetime");    
        }
    }
}

# Definir Dtos para mostrar valores de la Data API/Dtos/EntityDto

public class Entity
{
  public int Id { get; set; }
  public string Nombre { get; set; }
  public int IdX { get; set; }
}

# Definir MappingProfiles para mapeary relacionar los Dtos con cada Entidad API/Profiles/MappingProfiles.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()      //Se define paracada entidad
        {
            CreateMap<Auditoria,AuditoriaDto>().ReverseMap();
            CreateMap<Blockchain,BlockchainDto>().ReverseMap();
            CreateMap<EstadoNotificacion,EstadoNotificacionDto>().ReverseMap();
            CreateMap<Formato,FormatoDto>().ReverseMap();
            CreateMap<GenericosVsSubmoduloDto,GenericosVsSubmoduloDto>().ReverseMap();
            CreateMap<HiloRespuestaNotificacion,HiloRespuestaNotificacionDto>().ReverseMap();
            CreateMap<MaestrosVsSubmodulo,MaestrosVsSubmoduloDto>().ReverseMap();
            CreateMap<ModuloNotificacion,ModuloNotificacionDto>().ReverseMap();
            CreateMap<ModulosMaestro,ModulosMaestroDto>().ReverseMap();
            CreateMap<PermisoGenerico,PermisoGenericoDto>().ReverseMap();
            CreateMap<Radicado,RadicadoDto>().ReverseMap();
            CreateMap<Rol,RolDto>().ReverseMap();
            CreateMap<RolVsMaestro,RolVsMaestroDto>().ReverseMap();
            CreateMap<Submodulo,SubmoduloDto>().ReverseMap();
            CreateMap<TipoNotificacion,TipoNotificacionDto>().ReverseMap();
            CreateMap<TipoRequerimiento,TipoRequerimientoDto>().ReverseMap();
            
        }
    }
}

# Definir Metodos de Extension einyectar en el contenedor de dependencias API/Extensions/ApplicationServiceExtension

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreRateLimit;
using Core.Interfaces;
using Infrastructure.UnitOfWork;

namespace API.Extensions
{
    public static class ApplicationServiceExtension
    {
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy(
                    "CorsPolicy",
                    builder =>
                        builder
                            .AllowAnyOrigin() //WithOrigins("https://domini.com")
                            .AllowAnyMethod() //WithMethods(*GET", "POST")
                            .AllowAnyHeader()
                ); //WithHeaders(*accept*, "content-type")
            });

        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static void ConfigureRatelimiting(this IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
            services.AddInMemoryRateLimiting();
            services.Configure<IpRateLimitOptions>(options =>
            {
                options.EnableEndpointRateLimiting = true;
                options.StackBlockedRequests = false;
                options.HttpStatusCode = 429;
                options.RealIpHeader = "X-Real-IP";
                options.GeneralRules = new List<RateLimitRule>
                {
                    new RateLimitRule
                    {
                        Endpoint = "*",
                        Period = "10s",
                        Limit = 2
                    }
                };
            });
        }
    }
}

- Inyeccion al Contenedor de Dependencias API/Program.cs
builder.Services.AddControllers();

builder.Services.ConfigureRateLimiting();
builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());
builder.Services.ConfigureCors();

builder.Services.AddEndpointsApiExplorer();


if(app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}


app.UseCors("CorsPolicy");
app.UseHttpsRedirection();
app.UseIpRateLimiting();

app.UseIpAuthorization();

# Definir Interfaces para cada Entidad , Definimos IGenericRepository

- IGenericRepository Core/Interfaces/IGenericRepository.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
        public interface IGenericRepository<T> where T : BaseEntity
        {
                Task<T> GetByIdAsync(int id);
                Task<IEnumerable<T>> GetAllAsync();
                IEnumerable<T> Find(Expression<Func<T, bool>> expression);
                Task<(int totalRegistros, IEnumerable<T> registros)> GetAllAsync(int pageIndex, int pageSize, string search);
                void Add(T entity);
                void AddRange(IEnumerable<T> entities);
                void Remove(T entity);
                void RemoveRange(IEnumerable<T> entities);
                void Update(T entity);
        }
}

- IEntityRepository Core/Interfaces/IEntityRepository.cs

using Core.Entities;

namespace Core.Interfaces
{
    public interface IEntityRepository : IGenericRepository<Entity>
    {
        
    }
}

# Definir Repositorios para cada Interface u Entidades , Definimos GenericRepository

- GenericRepository Infrastructure/Repositories/GenericRepository.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T>
        where T : BaseEntity
    {
        private readonly NotiContext _context;

        public GenericRepository(NotiContext context)
        {
            _context = context;
        }

        public virtual void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public virtual void AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
        }

        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
            //return (IEnumerable<T>)await _context.Paises.FromSqlRaw("SELECT * FROM pais").ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public virtual async Task<T> GetByIdAsync(string id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        public virtual void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
        public virtual void RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }
        public virtual void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
        public virtual async Task<(int totalRegistros, IEnumerable<T> registros)> GetAllAsync(
            int pageIndex,
            int pageSize,
            string _search)
        {
            var totalRegistros = await _context.Set<T>().CountAsync();
            var registros = await _context
                .Set<T>()
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return (totalRegistros, registros);
        }
    }
}

- EntityRepository Infrastructure/Repositories/EntityRepository.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class EntityRepository : GenericRepository<Entity>, IEntityRepository
    {
        private readonly NotiContext _context;

        public EntityRepository(NotiContext context) : base(context)
        {
            _context = context;
        }
    }
}

# Definir la interface IUnitOfWork, la interface y clase

-Interface Core/Interfaces/IUnitOfWork.cs

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

-Clase Infrastructure/UnitOfWork/UnitOfWork.cs

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
    private EstadoNotificacionRepository _estadosnotificaciones;  // Crear una para cada Entidad-Repository
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

# Agregar Metodo de Extension API/Extensions/ApplicationServicesExtension.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreRateLimit;
using Core.Interfaces;
using Infrastructure.UnitOfWork;

namespace API.Extensions
{
    public static class ApplicationServiceExtension
    {
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy(
                    "CorsPolicy",
                    builder =>
                        builder
                            .AllowAnyOrigin() //WithOrigins("https://domini.com")
                            .AllowAnyMethod() //WithMethods(*GET", "POST")
                            .AllowAnyHeader()
                ); //WithHeaders(*accept*, "content-type")
            });

        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static void ConfigureRatelimiting(this IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
            services.AddInMemoryRateLimiting();
            services.Configure<IpRateLimitOptions>(options =>
            {
                options.EnableEndpointRateLimiting = true;
                options.StackBlockedRequests = false;
                options.HttpStatusCode = 429;
                options.RealIpHeader = "X-Real-IP";
                options.GeneralRules = new List<RateLimitRule>
                {
                    new RateLimitRule
                    {
                        Endpoint = "*",
                        Period = "10s",
                        Limit = 2
                    }
                };
            });
        }
    }
}

- Inyeccion Contenedor de Dependencias API/Programs.cs
builder.Services.ConfigureCors();

builder.Services.AddApplicationServices();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

# Generar Controladores para cada Entidad , Implementar BaseController

- BaseController API/Controllers/BaseController.cs

using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class BaseController : ControllerBase
{}

-EntityController API/Controllers/EntityController.cs

using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class RolController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public RolController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<RolDto>>> Get()
    {
        var roles = await _unitOfWork.Roles.GetAllAsync();

        //var paises = await _unitOfWork.Paises.GetAllAsync();
        return _mapper.Map<List<RolDto>>(roles);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Rol>> Post(RolDto rolDto)
    {
        var rol = _mapper.Map<Rol>(rolDto);
        this._unitOfWork.Roles.Add(rol);
        await _unitOfWork.SaveAsync();
        if (rol == null)
        {
            return BadRequest();
        }
        rolDto.Id = rol.Id;
        return CreatedAtAction(nameof(Post), new { id = rolDto.Id }, rolDto);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<RolDto>> Get(int id)
    {
        var rol = await _unitOfWork.Roles.GetByIdAsync(id);
        if (rol == null){
            return NotFound();
        }
        return _mapper.Map<RolDto>(rol);
    }
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<RolDto>> Put(int id, [FromBody] RolDto rolDto)
    {
        if (rolDto == null)
        {
            return NotFound();
        }
        var roles = _mapper.Map<Rol>(rolDto);
        _unitOfWork.Roles.Update(roles);
        await _unitOfWork.SaveAsync();
        return rolDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var rol = await _unitOfWork.Roles.GetByIdAsync(id);
        if (rol == null)
        {
            return NotFound();
        }
        _unitOfWork.Roles.Remove(rol);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}

# Generar Helpers,Pager y Params , Metodos de Paginacion
- API/Helpers/Pager.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAnimals.Helpers;

public class Pager<T>
    where T : class
{
    public string Search { get; set; }
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public int Total { get; set; }
    public List<T> Registers { get; private set; }

    public Pager() { }

    public Pager(List<T> registers, int total, int pageIndex, int pageSize, string search)
    {
        Registers = registers;
        Total = total;
        PageIndex = pageIndex;
        PageSize = pageSize;
        Search = search;
    }

    public int TotalPages
    {
        get { return (int)Math.Ceiling(Total / (double)PageSize); }
        set { this.TotalPages = value; }
    }

    public bool HasPreviousPage
    {
        get { return (PageIndex > 1); }
        set { this.HasPreviousPage = value; }
    }

    public bool HasNextPage
    {
        get { return (PageIndex < TotalPages); }
        set { this.HasNextPage = value; }
    }
}

-API/Helpers/Params.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAnimals.Helpers;

public class Params
{
    private int _pageSize = 5;
    private const int MaxPageSize = 50;
    private int _pageIndex = 1;
    private string _search;
    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
    }
    public int PageIndex
    {
        get => _pageIndex;
        set => _pageIndex = (value <= 0) ? 1 : value;
    }
    public string Search
    {
        get => _search;
        set => _search = (!String.IsNullOrEmpty(value)) ? value.ToLower() : "";
    }
}
