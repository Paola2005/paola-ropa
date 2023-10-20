using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace API.Dtos
{
    public class FormaPagoDto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public ICollection<Venta>Ventas{get; set;}
    }
}