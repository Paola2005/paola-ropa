using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Cargo:BaseEntity
    {
        public string Descripcion { get; set; }
        public double SueldoBase { get; set; }
        public ICollection<Empleado>Empleado{get; set;}
    }
}