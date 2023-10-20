using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace API.Dtos
{
    public class EmpleadoDto
    {
        public int Id { get; set; }
        public int IdEmleado { get; set; }
        public string Nombre { get; set; }
        public int IdCargo { get; set; }
        public DateOnly FechaIngreso { get; set; }
        public int IdMunicipio { get; set; }
        public ICollection<Orden>Ordenes{get; set;}
        public ICollection<Venta>Ventas{get; set;}
    }
}