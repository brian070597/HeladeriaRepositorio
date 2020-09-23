using System;
using System.Collections.Generic;

#nullable disable

namespace Heladeria.Shared.Modelos
{
    public partial class PaisIdioma
    {
        public string PaisCodigo { get; set; }
        public string PaisIdioma1 { get; set; }
        public string PaisIdiomaOficial { get; set; }
        public double PaisIdiomaPorcentaje { get; set; }

        public virtual Paise PaisCodigoNavigation { get; set; }
    }
}
