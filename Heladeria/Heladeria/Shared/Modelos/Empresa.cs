using System;
using System.Collections.Generic;

#nullable disable

namespace Heladeria.Shared.Modelos
{
    public partial class Empresa
    {
        public int Idempresa { get; set; }
        public string RazonSocial { get; set; }
        public string NombreFantasia { get; set; }
        public DateTime InicioActividades { get; set; }
        public string Cuit { get; set; }
        public byte[] Logo { get; set; }
        public string Direccion { get; set; }
        public int Idciudad { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Iibb { get; set; }
        public string CondicionIva { get; set; }

        public virtual Ciudade IdciudadNavigation { get; set; }
    }
}
