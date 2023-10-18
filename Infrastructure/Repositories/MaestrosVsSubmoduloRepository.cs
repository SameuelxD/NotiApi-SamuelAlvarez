using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class MaestrosVsSubmoduloRepository : GenericRepository<MaestrosVsSubmodulo>, IMaestrosVsSubmoduloRepository
    {
        private readonly NotiContext _context;

        public MaestrosVsSubmoduloRepository(NotiContext context) : base(context)
        {
            _context = context;
        }
    }
}
