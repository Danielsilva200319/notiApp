using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class EstadoVsNotificacionRepository : GenericRepository<EstadoVsNotificacion>, IEstadoVsNotificacionRepository
    {
        private readonly notiAppContext _context;

        public EstadoVsNotificacionRepository(notiAppContext context) : base(context)
        {
            _context = context;
        }
    }
}