using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace API.Dtos
{
    public class ColorDto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public ICollection<DetalleOrden>DetalleOrdenes{get;set;}
    }
}