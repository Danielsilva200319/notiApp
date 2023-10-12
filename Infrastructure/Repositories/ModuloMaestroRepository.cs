using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class ModuloMaestroRepository : GenericRepository<ModuloMaestro>, IModuloMaestroRepository
    {
        private readonly notiAppContext _context;

        public ModuloMaestroRepository(notiAppContext context) : base(context)
        {
            _context = context;
        }
    }
}