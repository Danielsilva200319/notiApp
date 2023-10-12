using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class HiloRespuestaRepository : GenericRepository<HiloRespuesta>, IHiloRepuestaRepository
    {
        private readonly notiAppContext _context;

        public HiloRespuestaRepository(notiAppContext context) : base(context)
        {
            _context = context;
        }
    }
}