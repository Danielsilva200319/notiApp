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
        IEstadoNotificacionRepository EstadoNotificaciones { get; }
        Task<int> SaveAsync();
    }
}