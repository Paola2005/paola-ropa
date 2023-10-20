using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace API.Dtos
{
    public class EstadoDto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int IdTipoEstado { get; set; }
        public ICollection<Prenda>Prendas {get; set;}
        public ICollection<Orden>Ordenes{get; set;}
        public ICollection<DetalleOrden>DetalleOrdenes{get;set;}
    }
}