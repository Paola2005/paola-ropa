using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace API.Dtos
{
    public class MunicipioDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdDepartamento { get; set; }

        public ICollection<Empresa>Empresas {get; set;}
        public ICollection<Empleado>Empleado{get; set;}
        public ICollection<Proveedor>Proveedores{get; set;}
        public ICollection<Cliente>Clientes{get; set;}
    }
}