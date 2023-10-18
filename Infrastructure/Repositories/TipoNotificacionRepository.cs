using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class TipoNotificacionRepository : GenericRepository<TipoNotificacion>, ITipoNotificacionRepository
    {
        private readonly NotiContext _context;

        public TipoNotificacionRepository(NotiContext context) : base(context)
        {
            _context = context;
        }
    }
}
