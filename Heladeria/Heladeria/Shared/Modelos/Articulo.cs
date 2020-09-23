using System;
using System.Collections.Generic;

#nullable disable

namespace Heladeria.Shared.Modelos
{
    public partial class Articulo
    {
        public Articulo()
        {
            PedidosDetalles = new HashSet<PedidosDetalle>();
            VentasDetalles = new HashSet<VentasDetalle>();
        }

        public int Idarticulo { get; set; }
        public string Descripcion { get; set; }
        public double StockActual { get; set; }
        public DateTime? FechaBaja { get; set; }
        public double CantMinima { get; set; }
        public int Idrubro { get; set; }
        public int IdsubRubro { get; set; }
        public string CodArticulo { get; set; }
        public int IdunidadMedida { get; set; }

        public virtual Rubro IdrubroNavigation { get; set; }
        public virtual SubRubro IdsubRubroNavigation { get; set; }
        public virtual UnidadesMedida IdunidadMedidaNavigation { get; set; }
        public virtual ICollection<PedidosDetalle> PedidosDetalles { get; set; }
        public virtual ICollection<VentasDetalle> VentasDetalles { get; set; }
    }
}
