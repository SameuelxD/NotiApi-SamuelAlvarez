using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class PermisoGenericoRepository : GenericRepository<PermisoGenerico>, IPermisoGenericoRepository
    {
        private readonly NotiContext _context;

        public PermisoGenericoRepository(NotiContext context) : base(context)
        {
            _context = context;
        }
    }
}
