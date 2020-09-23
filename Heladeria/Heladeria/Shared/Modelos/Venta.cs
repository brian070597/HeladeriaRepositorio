using System;
using System.Collections.Generic;

#nullable disable

namespace Heladeria.Shared.Modelos
{
    public partial class Venta
    {
        public Venta()
        {
            VentasDetalles = new HashSet<VentasDetalle>();
        }

        public int Idventa { get; set; }
        public DateTime FechaEmision { get; set; }
        public int Idcliente { get; set; }
        public string Observaciones { get; set; }
        public decimal Total { get; set; }
        public DateTime? FechaAnulacion { get; set; }
        public int Idusuario { get; set; }

        public virtual Cliente IdclienteNavigation { get; set; }
        public virtual Usuario IdusuarioNavigation { get; set; }
        public virtual ICollection<VentasDetalle> VentasDetalles { get; set; }
    }
}
