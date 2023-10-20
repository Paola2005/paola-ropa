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
    public class CargoRepository : GenericRepository<Cargo>, ICargo
    {
        private readonly RopaContext _context;

        public CargoRepository(RopaContext context) : base(context)
        {
            _context = context;
        }
    }
}
