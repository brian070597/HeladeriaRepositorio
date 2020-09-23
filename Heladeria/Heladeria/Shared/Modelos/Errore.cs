using System;
using System.Collections.Generic;

#nullable disable

namespace Heladeria.Shared.Modelos
{
    public partial class Errore
    {
        public int Iderror { get; set; }
        public string TextoError { get; set; }
        public int Idusuario { get; set; }
        public string SeccionError { get; set; }
        public string ObjetoError { get; set; }
        public string TraceError { get; set; }
        public DateTime FechaError { get; set; }

        public virtual Usuario IdusuarioNavigation { get; set; }
    }
}
