using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace API.Dtos
{
    public class ClienteDto
    {
        public int Id { get; set; }
         public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public int IdTipoPersona { get; set; }
        public DateOnly FechaRegistro { get; set; }
        public int IdMunicipio { get; set; }
        public ICollection<Orden>Ordenes{get; set;}
        public ICollection<Venta>Ventas{get; set;}
    }
}