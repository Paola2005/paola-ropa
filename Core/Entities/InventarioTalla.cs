using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class InventarioTalla
    {
        public int IdInventario { get; set; }
        public Inventario Inventarios { get; set; }
        public int IdTalla { get; set; }
        public Talla Tallas { get; set; }
        public int Cantidad { get; set; }
    }
}