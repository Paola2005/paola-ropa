using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Talla:BaseEntity
    {
        public string Descripcion { get; set; }
        public ICollection<InventarioTalla>InventariosTallas { get; set; }
        public ICollection<DetalleVenta>DetallesVentas{get; set;}
        
    }
}