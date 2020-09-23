using System;
using System.Collections.Generic;

#nullable disable

namespace Heladeria.Shared.Modelos
{
    public partial class Proveedore
    {
        public Proveedore()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public int Idproveedor { get; set; }
        public int IdtipoDocumento { get; set; }
        public long? NroDocumento { get; set; }
        public int Idciudad { get; set; }
        public string ApellidoyNombre { get; set; }
        public string Direccion { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public DateTime? FechaBaja { get; set; }
        public DateTime FechaAlta { get; set; }
        public int IdtipoEstado { get; set; }
        public string Comentario { get; set; }

        public virtual Ciudade IdciudadNavigation { get; set; }
        public virtual TiposDocumento IdtipoDocumentoNavigation { get; set; }
        public virtual TiposEstado IdtipoEstadoNavigation { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
