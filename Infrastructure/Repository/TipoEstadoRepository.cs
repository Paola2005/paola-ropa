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
    public class TipoEstadoRepository : GenericRepository<TipoEstado>, ITipoEstado
    {
        private readonly RopaContext _context;

        public TipoEstadoRepository(RopaContext context) : base(context)
        {
            _context = context;
        }
    }
}