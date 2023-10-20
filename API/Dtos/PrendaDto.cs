using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace API.Dtos
{
    public class PrendaDto
    {
        public int Id { get; set; }
        public int IdPrenda { get; set; }
        public string Nombre { get; set; }
        public double ValorUnitCop { get; set; }
        public double ValorUnitUsd { get; set; }
        public int IdEstado { get; set; }

        public int IdTipoProteccion { get; set; }

        public int IdGenero { get; set; }

        public ICollection<InsumoPrenda>InsumoPrendas{get; set;}
        public ICollection<Inventario>Inventarios{get; set;}
        public ICollection<DetalleOrden>DetalleOrdenes{get;set;}
    }
}