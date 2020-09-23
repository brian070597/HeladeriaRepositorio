using System;
using System.Collections.Generic;

#nullable disable

namespace Heladeria.Shared.Modelos
{
    public partial class PedidosDetalle
    {
        public int IdpedidoDetalle { get; set; }
        public int Idpedido { get; set; }
        public int Idarticulo { get; set; }
        public decimal Cantidad { get; set; }

        public virtual Articulo IdarticuloNavigation { get; set; }
        public virtual Pedido IdpedidoNavigation { get; set; }
    }
}
