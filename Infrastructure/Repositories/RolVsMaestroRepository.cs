using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class RolVsMaestroRepository : GenericRepository<RolVsMaestro>, IRolVsMaestroRepository
    {
        private readonly NotiContext _context;

        public RolVsMaestroRepository(NotiContext context) : base(context)
        {
            _context = context;
        }
    }
}
