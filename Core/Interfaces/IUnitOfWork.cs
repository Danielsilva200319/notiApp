using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUnitOfWork
    {
        IAuditoriaRepository Auditorias { get; }
        IBlockChainRepository BlockChains { get; }
        IEstadoVsNotificacionRepository EstadoVsNotificaciones { get; }
        IFormatoRepository Formatos { get; }
        IGenericoVsSubmoduloRepository GenericoVsSubmodulos { get; }
        IHiloRespuestaRepository HiloRespuestas { get; }
        IMaestroVsSubmoduloRepository MaestroVsSubmodulos { get; }
        IModuloMaestroRepository ModulosMaestros { get; }
        IModuloNotificacionRepository ModulosNotificaciones { get; }
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