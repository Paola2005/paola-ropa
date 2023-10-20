using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Proveedor:BaseEntity
    {
        public int NitProveedor { get; set; }
        public string Nombre { get; set; }
        public int IdTipoPersona { get; set; }
        public TipoPersona TipoPersonas { get; set; }
        public int IdMunicipio { get; set; }
        public Municipio Municipios { get; set; }
        public ICollection<InsumoProveedor>InsumoProveedores {get; set;}
        
    }
}