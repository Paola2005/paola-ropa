using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Inventario:BaseEntity
    {
        public int CodInvetario { get; set; }
        public int IdPrenda { get; set; }
        public Prenda Prendas { get; set; }
        public double ValorVtaCop { get; set; }
        public double ValorVtaUsd { get; set; }
        public ICollection<InventarioTalla>InventariosTallas { get; set; }
        public ICollection<DetalleVenta>DetallesVentas{get; set;}
    }
}