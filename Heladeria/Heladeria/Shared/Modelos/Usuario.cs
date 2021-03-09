using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Heladeria.Shared.Modelos
{
    public partial class Usuario
    {
        public Usuario()
        {
            Errores = new HashSet<Errore>();
            Pedidos = new HashSet<Pedido>();
            Venta = new HashSet<Venta>();
        }

        public int Idusuario { get; set; }
        public int IdtipoUsuario { get; set; }
        [Required]
        public string NombreUsuario { get; set; }
        [Required]
        public byte[] Contraseña { get; set; }
        public DateTime? FechaBaja { get; set; }
        public DateTime FechaAlta { get; set; }
        public int IdtipoEstado { get; set; }

        public virtual TiposEstado IdtipoEstadoNavigation { get; set; }
        public virtual TiposUsuario IdtipoUsuarioNavigation { get; set; }
        public virtual ICollection<Errore> Errores { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }
        public virtual ICollection<Venta> Venta { get; set; }
    }
}
