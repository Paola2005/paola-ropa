using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructura.Data;
using Infrastructure.Repositories;

namespace Infrastructure.Repository
{
    public class InventarioTallaRepository : GenericRepository<InventarioTalla>, IInventarioTalla
    {
        private readonly RopaContext _context;

        public InventarioTallaRepository(RopaContext context) : base(context)
        {
            _context = context;
        }
    }
}