using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class SubmoduloRepository : GenericRepository<Submodulo>, ISubmoduloRepository
    {
        private readonly NotiContext _context;

        public SubmoduloRepository(NotiContext context) : base(context)
        {
            _context = context;
        }
    }
}
