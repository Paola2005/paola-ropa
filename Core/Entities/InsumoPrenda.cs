using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class InsumoPrenda:BaseEntity
    {
        public int IdInsumo { get; set; }
        public Insumo Insumos{get; set;}
        public int IdPrenda { get; set; }
        public Prenda Prendas { get; set; }
        public int Cantidad { get; set; }
    }
}