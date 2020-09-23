using System;
using System.Collections.Generic;

#nullable disable

namespace Heladeria.Shared.Modelos
{
    public partial class Pedido
    {
        public Pedido()
        {
            PedidosDetalles = new HashSet<PedidosDetalle>();
        }

        public int Idpedido { get; set; }
        public DateTime FechaEmision { get; set; }
        public int Idproveedor { get; set; }
        public string Observaciones { get; set; }
        public decimal Total { get; set; }
        public DateTime? FechaAnulacion { get; set; }
        public int Idusuario { get; set; }

        public virtual Proveedore IdproveedorNavigation { get; set; }
        public virtual Usuario IdusuarioNavigation { get; set; }
        public virtual ICollection<PedidosDetalle> PedidosDetalles { get; set; }
    }
}
