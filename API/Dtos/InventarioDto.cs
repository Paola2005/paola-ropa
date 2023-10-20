using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace API.Dtos
{
    public class InventarioDto
    {
        public int Id { get; set; }
        public int CodInvetario { get; set; }
        public int IdPrenda { get; set; }

        public double ValorVtaCop { get; set; }
        public double ValorVtaUsd { get; set; }
        public ICollection<InventarioTalla>InventariosTallas { get; set; }
        public ICollection<DetalleVenta>DetallesVentas{get; set;}
    }
}