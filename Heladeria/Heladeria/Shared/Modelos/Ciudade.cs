using System;
using System.Collections.Generic;

#nullable disable

namespace Heladeria.Shared.Modelos
{
    public partial class Ciudade
    {
        public Ciudade()
        {
            Clientes = new HashSet<Cliente>();
            Empresas = new HashSet<Empresa>();
            Proveedores = new HashSet<Proveedore>();
        }

        public int IdCiudad { get; set; }
        public string CiudadNombre { get; set; }
        public string PaisCodigo { get; set; }
        public string CiudadDistrito { get; set; }
        public int CiudadPoblacion { get; set; }

        public virtual Paise PaisCodigoNavigation { get; set; }
        public virtual ICollection<Cliente> Clientes { get; set; }
        public virtual ICollection<Empresa> Empresas { get; set; }
        public virtual ICollection<Proveedore> Proveedores { get; set; }
    }
}
