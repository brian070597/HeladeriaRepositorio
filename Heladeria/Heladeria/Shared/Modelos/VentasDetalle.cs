using System;
using System.Collections.Generic;

#nullable disable

namespace Heladeria.Shared.Modelos
{
    public partial class VentasDetalle
    {
        public int IdventaDetalle { get; set; }
        public int Idventa { get; set; }
        public int Idarticulo { get; set; }
        public decimal Cantidad { get; set; }

        public virtual Articulo IdarticuloNavigation { get; set; }
        public virtual Venta IdventaNavigation { get; set; }
    }
}
