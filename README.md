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
        public int Entero { get; set; }
        public string String { get; set; }
        public DateTime Fecha { get; set; }
        public double Double { get; set; }
}
    
# Repositorio generico, Unidad de trabajo

Genere una clase de tipo Interface y nombrela IGenericRepository

```
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
        Task<(int totalRegistros, IEnumerable<T> registros)> GetAllAsync(int pageIndex, int pageSize,string search);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        void Update(T entity);        
}
}
```

Implemente los metodos definidos en la clase IGenericRepository

```
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
        private readonly AnimalsContext _context;

        public GenericRepository(AnimalsContext context)
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
```
