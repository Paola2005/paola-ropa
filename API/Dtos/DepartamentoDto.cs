using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace API.Dtos
{
    public class DepartamentoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdPais { get; set; }
        public ICollection<Municipio>Municipios{get; set;}
    }
}