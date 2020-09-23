using System;
using System.Collections.Generic;

#nullable disable

namespace Heladeria.Shared.Modelos
{ 
    public partial class Paise
    {
        public Paise()
        {
            Ciudades = new HashSet<Ciudade>();
            PaisIdiomas = new HashSet<PaisIdioma>();
        }

        public string PaisCodigo { get; set; }
        public string PaisNombre { get; set; }
        public string PaisContinente { get; set; }
        public string PaisRegion { get; set; }
        public double PaisArea { get; set; }
        public short? PaisIndependencia { get; set; }
        public int PaisPoblacion { get; set; }
        public double? PaisExpectativaDeVida { get; set; }
        public double? PaisProductoInternoBruto { get; set; }
        public double? PaisProductoInternoBrutoAntiguo { get; set; }
        public string PaisNombreLocal { get; set; }
        public string PaisGobierno { get; set; }
        public string PaisJefeDeEstado { get; set; }
        public int? PaisCapital { get; set; }
        public string PaisCodigo2 { get; set; }

        public virtual ICollection<Ciudade> Ciudades { get; set; }
        public virtual ICollection<PaisIdioma> PaisIdiomas { get; set; }
    }
}
