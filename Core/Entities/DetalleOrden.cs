using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class DetalleOrden:BaseEntity
    {
        public int IdOrden { get; set; }
        public Orden Ordenes { get; set; }
        public int IdPrenda { get; set; }
        public Prenda Prendas { get; set; }
        public int CantidadProducir { get; set; }
        public int IdColor { get; set; }
        public Color Colores { get; set; }
        public int CantidadProducida { get; set; }
        public int IdEstado { get; set; }
        public Estado Estados { get; set; }
    }
}