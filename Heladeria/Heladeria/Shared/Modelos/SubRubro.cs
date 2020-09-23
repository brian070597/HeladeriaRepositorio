using System;
using System.Collections.Generic;

#nullable disable

namespace Heladeria.Shared.Modelos
{
    public partial class SubRubro
    {
        public SubRubro()
        {
            Articulos = new HashSet<Articulo>();
        }

        public int IdsubRubro { get; set; }
        public string Descripcion { get; set; }
        public int Idrubro { get; set; }

        public virtual Rubro IdrubroNavigation { get; set; }
        public virtual ICollection<Articulo> Articulos { get; set; }
    }
}
