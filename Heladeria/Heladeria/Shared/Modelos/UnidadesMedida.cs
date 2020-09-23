using System;
using System.Collections.Generic;

#nullable disable

namespace Heladeria.Shared.Modelos
{
    public partial class UnidadesMedida
    {
        public UnidadesMedida()
        {
            Articulos = new HashSet<Articulo>();
        }

        public int IdunidadMedida { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Articulo> Articulos { get; set; }
    }
}
