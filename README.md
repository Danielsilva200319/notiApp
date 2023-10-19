# Estructura del Proyecto NOTIAPP

## 1. Creación de la Solución

- Se inicia creando una solución que servirá como el contenedor principal para tus proyectos.
```
dotnet new sln
```

## 2. Proyectos

El proyecto se divide en tres capas principales:

![Alt text](<Captura de pantalla 2023-10-17 124029.png>)

#### Capa de Presentación (Web API: apiNoti)
```
dotnet new webapi -o apiNoti
```

- Controladores: Manejan las solicitudes HTTP y las respuestas.
- DTOs (Data Transfer Objects): Definen la estructura de los datos que se envían entre la Web API y el cliente.
- Extensions: Configura servicios relacionados con CORS (Cross-Origin Resource Sharing) y rate limiting (limitación de velocidad) en una aplicación web ASP.NET Core.
- Profiles: Define perfiles de mapeo utilizando AutoMapper para transformar datos entre las entidades del sistema y los objetos de transferencia de datos (DTOs), simplificando así la conversión de datos en una aplicación ASP.NET Core.
- Program.cs: Configura y construye una aplicación ASP.NET Core, agregando servicios al contenedor, configurando características como rate limiting, CORS, AutoMapper y Swagger para documentación de API, y estableciendo las rutas y middleware necesarios para manejar solicitudes HTTP en la aplicación web.

![Alt text](<Captura de pantalla 2023-10-19 06-55-19.png>)

#### Capa de Lógica de Negocio (Core)
```
dotnet new classlibi -o Core
```

- Entidades: Representan los objetos fundamentales de la aplicación.
- Interfaces y Repositorios: Definen operaciones comunes como agregar, actualizar, eliminar y buscar. 
- Unidades de Trabajo (IUnitOfWork): Coordinan y agrupan operaciones relacionales en la base de datos.

![Alt text](<Captura de pantalla 2023-10-19 06-57-44.png>)

#### Capa de Acceso a Datos (Infrastructure)
```
dotnet new classlib -o Infrastructure
```

- Context: Actúa como intermediario entre la Web API y la base de datos.
- Configuraciones: Definen cómo se mapean las entidades a las tablas de la base de datos.
- Repositorios Concretos: Implementan la lógica para interactuar con la base de datos.
- Unidad de trabajo (UnitOfWork): Representa una clase llamada "UnitOfWork" que actúa como un punto central para acceder a múltiples repositorios que interactúan con una base de datos en una aplicación ASP.NET Core, lo que permite coordinar y gestionar transacciones y operaciones de base de datos de manera eficiente.

![Alt text](<Captura de pantalla 2023-10-19 07-04-49.png>)

## Agregar las soluciones a cada una:
```
dotnet sln add apiNoti
dotnet sln add Core
dotnet sln add Infrastructure
```
## Hacer las referencias en el proyecto:
```
dotnet add reference ..\Infrastructure
dotnet add reference ..\Core
```

### INSTALACION DE PAQUETES.
#### Proyecto WebApi
```
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer --version 7.0.10
dotnet add package Microsoft.EntityFrameworkCore --version 7.0.10
dotnet add package Microsoft.EntityFrameworkCore.Design --version 7.0.10
dotnet add package Microsoft.Extensions.DependencyInjection --version 7.0.0
dotnet add package System.IdentityModel.Tokens.Jwt --version 6.32.3
dotnet add package Serilog.AspNetCore --version 7.0.0
dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection --version 12.0.1
```
#### Proyecto Infraestructure
```
dotnet add package Pomelo.EntityFrameworkCore.MySql --version 7.0.0
dotnet add package Microsoft.EntityFrameworkCore --version 7.0.10
dotnet add package CsvHelper --version 30.0.1
```

## 3. Configuración de la Base de Datos

- Se configuran las cadenas de conexión en el archivo `appsettings.Development.json` y `appsettings.json` para permitir que la aplicación acceda y almacene datos en la base de datos.

![Alt text](<Captura de pantalla 2023-10-19 07-08-48.png>)

## 4. Inyección de Dependencias

- Se implementa la inyección de dependencias para administrar la creación y el ciclo de vida de los objetos utilizados en la aplicación, incluyendo la conexión a la base de datos.

![Alt text](<Captura de pantalla 2023-10-19 07-16-41.png>)

## 5. Entidades

- En la capa Core, se definen las entidades que representan los objetos fundamentales en la aplicación. Estas clases se utilizan para modelar la lógica de negocio y mapear datos desde la base de datos.

![Alt text](<Captura de pantalla 2023-10-19 07-18-43.png>)

## 6. Configuraciones

- En la capa de Infraestructura, se crean clases de configuración para cada entidad. Estas clases se utilizan con Entity Framework Core para definir cómo se mapean las entidades a las tablas de la base de datos, estableciendo nombres de tablas, restricciones, propiedades y claves primarias.

![Alt text](<Captura de pantalla 2023-10-19 07-20-02.png>)

## 7. Controladores de la Web API

- En el proyecto Web API, se crean controladores para definir rutas de acceso y lógica para manejar solicitudes HTTP. Estos controladores permiten realizar operaciones CRUD en las entidades.

![Alt text](<Captura de pantalla 2023-10-19 07-20-02.png>)
```
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiNoti.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiNoti.Controllers
{
    public class AuditoriaController : BaseControllerAPi
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AuditoriaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<AuditoriaDto>>> Get()
        {
            var auditorias = await _unitOfWork.Auditorias.GetAllAsync();
            return _mapper.Map<List<AuditoriaDto>>(auditorias);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AuditoriaDto>>Get(int id)
        {
            var mascota = await _unitOfWork.Auditorias.GetByIdAsync(id);
            if(mascota == null)
            {
                return NotFound();
            }
            return _mapper.Map<AuditoriaDto>(mascota);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AuditoriaDto>>Post(AuditoriaDto auditoriaDto)
        {
            var auditoria = _mapper.Map<Auditoria>(auditoriaDto);

            if(auditoriaDto.FechaCreacion == DateTime.MinValue)
            {
                auditoriaDto.FechaCreacion = DateTime.Now; 
            }
            if(auditoriaDto.FechaModificacion == DateTime.MinValue)
            {
                auditoriaDto.FechaModificacion = DateTime.Now; 
            }
            this._unitOfWork.Auditorias.Add(auditoria);
            await _unitOfWork.SaveAsync();
            
            if(auditoria == null)
            {
                return BadRequest();
            }
            auditoriaDto.Id = auditoria.Id;
            return CreatedAtAction(nameof(Post), new {id = auditoriaDto.Id}, auditoriaDto);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AuditoriaDto>> Put(int id, [FromBody] AuditoriaDto auditoriaDto)
        {
            if(auditoriaDto == null)
            {
                return NotFound();
            }
            var auditorias = _mapper.Map<Auditoria>(auditoriaDto);
            _unitOfWork.Auditorias.Update(auditorias);
            await _unitOfWork.SaveAsync();
            return auditoriaDto;
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult>Delete(int id)
        {
            var auditoria = await _unitOfWork.Auditorias.GetByIdAsync(id);
            if(auditoria == null)
            {
                return NotFound();
            }
            _unitOfWork.Auditorias.Remove(auditoria);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}
```

## 8. Perfiles de Mapeo (Mapping Profiles)

- Se utiliza AutoMapper para mapear datos entre las entidades y objetos de transferencia de datos (DTOs). Esto facilita la conversión de datos entre las capas de presentación y lógica de negocio.

![Alt text](<Captura de pantalla 2023-10-19 07-23-05.png>)

```
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiNoti.Dtos;
using AutoMapper;
using Core.Entities;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ApiNoti.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Auditoria, AuditoriaDto>().ReverseMap();
            CreateMap<BlockChain, BlockChainDto>().ReverseMap();
            CreateMap<EstadoVsNotificacion, EstadoVsNotificacionDto>().ReverseMap();
            CreateMap<Formato, FormatoDto>().ReverseMap();
            CreateMap<GenericoVsSubmodulo, GenericoVsSubmoduloDto>().ReverseMap();
            CreateMap<HiloRespuesta, HiloRespuestaDto>().ReverseMap();
            CreateMap<MaestroVsSubmodulo, MaestroVsSubmoduloDto>().ReverseMap();
            CreateMap<ModuloMaestro, ModuloMaestroDto>().ReverseMap();
            CreateMap<ModuloNotificacion, ModuloNotificacionDto>().ReverseMap();
            CreateMap<PermisoGenerico, PermisoGenericoDto>().ReverseMap();
            CreateMap<Radicado, RadicadoDto>().ReverseMap();
            CreateMap<Rol, RolDto>().ReverseMap();
            CreateMap<RolVsMaestro, RolVsMaestroDto>().ReverseMap();
            CreateMap<Submodulo, SubmoduloDto>().ReverseMap();
            CreateMap<TipoNotificacion, TipoNotificacionDto>().ReverseMap();
            CreateMap<TipoRequerimiento, TipoRequerimientoDto>().ReverseMap();
        }
    }
}
```

## 9. Migraciones y Actualización de la Base de Datos

- Se utilizan las herramientas de Entity Framework Core para generar migraciones que crean o actualizan la base de datos según las definiciones de entidades y configuraciones. Los comandos `dotnet ef migrations` y `dotnet ef database update` se utilizan para aplicar estas migraciones.
```
dotnet ef migrations add InitalCreated --project .\Infrastructure --startup-project .\apiNoti --output-dir ./Data/Migrations
dotnet ef database update --project .\Infrastructure --startup-project .\apiNoti
```

![Alt text](<Captura de pantalla 2023-10-19 07-24-39.png>)