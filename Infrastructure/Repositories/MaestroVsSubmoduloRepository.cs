using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class MaestroVsSubmoduloRepository : GenericRepository<MaestroVsSubmodulo>, IMaestroVsSubmoduloRepository
    {
        private readonly notiAppContext _context;

        public MaestroVsSubmoduloRepository(notiAppContext context) : base(context)
        {
            _context = context;
        }
    }
}