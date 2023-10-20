using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class DetalleVenta:BaseEntity
    {
        public int IdVenta { get; set; }
        public Venta Ventas { get; set; }
        public int IdProducto { get; set; }
        public Inventario Inventarios { get; set; }
        public int IdTalla { get; set; }
        public Talla Tallas { get; set; }
        public int Cantidad { get; set; }
        public double ValorUnit { get; set; }
    }
}