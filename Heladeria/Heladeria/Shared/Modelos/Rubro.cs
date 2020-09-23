using System;
using System.Collections.Generic;

#nullable disable

namespace Heladeria.Shared.Modelos
{
    public partial class Rubro
    {
        public Rubro()
        {
            Articulos = new HashSet<Articulo>();
            SubRubros = new HashSet<SubRubro>();
        }

        public int Idrubro { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Articulo> Articulos { get; set; }
        public virtual ICollection<SubRubro> SubRubros { get; set; }
    }
}
