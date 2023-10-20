using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace API.Dtos
{
    public class OrdenDto
    {
        public int Id { get; set; }
        public DateOnly Fecha { get; set; }
        public int IdEmleado { get; set; }

        public int IdCliente { get; set; }

        public int IdEstado { get; set; }

        public ICollection<DetalleOrden>DetalleOrdenes{get;set;}
    }
}