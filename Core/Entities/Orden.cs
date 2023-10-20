using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Orden:BaseEntity
    {
        
        public DateOnly Fecha { get; set; }
        public int IdEmleado { get; set; }
        public Empleado Empleados { get; set; }
        public int IdCliente { get; set; }
        public Cliente Clientes { get; set; }
        public int IdEstado { get; set; }
        public Estado Estados { get; set; }
        public ICollection<DetalleOrden>DetalleOrdenes{get;set;}
    }
}