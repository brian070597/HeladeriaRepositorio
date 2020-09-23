using Heladeria.Shared.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#nullable disable

namespace Heladeria.Server
{
    public partial class HeladeriaContext : DbContext
    {
        public HeladeriaContext()
        {
        }

        public HeladeriaContext(DbContextOptions<HeladeriaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Articulo> Articulos { get; set; }
        public virtual DbSet<Ciudade> Ciudades { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Empresa> Empresas { get; set; }
        public virtual DbSet<Errore> Errores { get; set; }
        public virtual DbSet<PaisIdioma> PaisIdiomas { get; set; }
        public virtual DbSet<Paise> Paises { get; set; }
        public virtual DbSet<Pedido> Pedidos { get; set; }
        public virtual DbSet<PedidosDetalle> PedidosDetalles { get; set; }
        public virtual DbSet<Proveedore> Proveedores { get; set; }
        public virtual DbSet<Rubro> Rubros { get; set; }
        public virtual DbSet<SubRubro> SubRubros { get; set; }
        public virtual DbSet<TiposDocumento> TiposDocumentos { get; set; }
        public virtual DbSet<TiposEstado> TiposEstados { get; set; }
        public virtual DbSet<TiposUsuario> TiposUsuarios { get; set; }
        public virtual DbSet<UnidadesMedida> UnidadesMedidas { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Venta> Ventas { get; set; }
        public virtual DbSet<VentasDetalle> VentasDetalles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-I6E03AH\\SQLEXPRESS;Database=Heladeria;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Articulo>(entity =>
            {
                entity.HasKey(e => e.Idarticulo);

                entity.Property(e => e.Idarticulo)
                    .ValueGeneratedNever()
                    .HasColumnName("IDArticulo");

                entity.Property(e => e.CodArticulo).HasMaxLength(50);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Idrubro).HasColumnName("IDRubro");

                entity.Property(e => e.IdsubRubro).HasColumnName("IDSubRubro");

                entity.Property(e => e.IdunidadMedida).HasColumnName("IDUnidadMedida");

                entity.HasOne(d => d.IdrubroNavigation)
                    .WithMany(p => p.Articulos)
                    .HasForeignKey(d => d.Idrubro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Articulos__IDRub__03F0984C");

                entity.HasOne(d => d.IdsubRubroNavigation)
                    .WithMany(p => p.Articulos)
                    .HasForeignKey(d => d.IdsubRubro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Articulos__IDSub__04E4BC85");

                entity.HasOne(d => d.IdunidadMedidaNavigation)
                    .WithMany(p => p.Articulos)
                    .HasForeignKey(d => d.IdunidadMedida)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Articulos__IDUni__05D8E0BE");
            });

            modelBuilder.Entity<Ciudade>(entity =>
            {
                entity.HasKey(e => e.IdCiudad)
                    .HasName("PK__Ciudad__D4D3CCB05FBCA5D6");

                entity.Property(e => e.IdCiudad).ValueGeneratedNever();

                entity.Property(e => e.CiudadDistrito)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.CiudadNombre)
                    .IsRequired()
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.CiudadPoblacion).HasDefaultValueSql("('0')");

                entity.Property(e => e.PaisCodigo)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.HasOne(d => d.PaisCodigoNavigation)
                    .WithMany(p => p.Ciudades)
                    .HasForeignKey(d => d.PaisCodigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ciudad_Pais");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.Idcliente);

                entity.Property(e => e.Idcliente)
                    .ValueGeneratedNever()
                    .HasColumnName("IDCliente");

                entity.Property(e => e.ApellidoyNombre)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Comentario).HasMaxLength(300);

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(80);

                entity.Property(e => e.Email1).HasMaxLength(50);

                entity.Property(e => e.Email2).HasMaxLength(50);

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("smalldatetime")
                    .HasAnnotation("Relational:ColumnType", "smalldatetime");

                entity.Property(e => e.Idciudad).HasColumnName("IDCiudad");

                entity.Property(e => e.IdtipoDocumento).HasColumnName("IDTipoDocumento");

                entity.Property(e => e.IdtipoEstado).HasColumnName("IDTipoEstado");

                entity.Property(e => e.Telefono).HasMaxLength(70);

                entity.HasOne(d => d.IdciudadNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.Idciudad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Clientes__IDCiud__02084FDA");

                entity.HasOne(d => d.IdtipoDocumentoNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.IdtipoDocumento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Clientes__IDTipo__619B8048");

                entity.HasOne(d => d.IdtipoEstadoNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.IdtipoEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Clientes__IDTipo__02FC7413");
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.HasKey(e => e.Idempresa);

                entity.ToTable("Empresa");

                entity.Property(e => e.Idempresa)
                    .ValueGeneratedNever()
                    .HasColumnName("IDEmpresa");

                entity.Property(e => e.CondicionIva).HasMaxLength(50);

                entity.Property(e => e.Cuit)
                    .HasMaxLength(15)
                    .HasColumnName("CUIT");

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(80);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Idciudad).HasColumnName("IDCiudad");

                entity.Property(e => e.Iibb)
                    .HasMaxLength(50)
                    .HasColumnName("IIBB");

                entity.Property(e => e.InicioActividades)
                    .HasColumnType("smalldatetime")
                    .HasAnnotation("Relational:ColumnType", "smalldatetime");

                entity.Property(e => e.NombreFantasia).HasMaxLength(200);

                entity.Property(e => e.RazonSocial).HasMaxLength(200);

                entity.Property(e => e.Telefono).HasMaxLength(70);

                entity.HasOne(d => d.IdciudadNavigation)
                    .WithMany(p => p.Empresas)
                    .HasForeignKey(d => d.Idciudad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Empresa__IDCiuda__06CD04F7");
            });

            modelBuilder.Entity<Errore>(entity =>
            {
                entity.HasKey(e => e.Iderror);

                entity.Property(e => e.Iderror)
                    .ValueGeneratedNever()
                    .HasColumnName("IDError");

                entity.Property(e => e.Idusuario).HasColumnName("IDUsuario");

                entity.Property(e => e.ObjetoError)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.SeccionError)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.TextoError)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.TraceError)
                    .IsRequired()
                    .HasMaxLength(4000);

                entity.HasOne(d => d.IdusuarioNavigation)
                    .WithMany(p => p.Errores)
                    .HasForeignKey(d => d.Idusuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Errores__IDUsuar__07C12930");
            });

            modelBuilder.Entity<PaisIdioma>(entity =>
            {
                entity.HasKey(e => new { e.PaisCodigo, e.PaisIdioma1 })
                    .HasName("PK__PaisIdio__5EDA279555E9393C");

                entity.ToTable("PaisIdioma");

                entity.Property(e => e.PaisCodigo)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.PaisIdioma1)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("PaisIdioma")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.PaisIdiomaOficial)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('F')")
                    .IsFixedLength(true);

                entity.Property(e => e.PaisIdiomaPorcentaje).HasDefaultValueSql("('0.0')");

                entity.HasOne(d => d.PaisCodigoNavigation)
                    .WithMany(p => p.PaisIdiomas)
                    .HasForeignKey(d => d.PaisCodigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PaisIdioma_Pais");
            });

            modelBuilder.Entity<Paise>(entity =>
            {
                entity.HasKey(e => e.PaisCodigo)
                    .HasName("PK__Pais__F3A7B39A4E71D18A");

                entity.Property(e => e.PaisCodigo)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.PaisArea).HasDefaultValueSql("('0.00')");

                entity.Property(e => e.PaisCodigo2)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.PaisContinente)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Asia')");

                entity.Property(e => e.PaisGobierno)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PaisJefeDeEstado)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.PaisNombre)
                    .IsRequired()
                    .HasMaxLength(52)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.PaisNombreLocal)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PaisPoblacion).HasDefaultValueSql("('0')");

                entity.Property(e => e.PaisRegion)
                    .IsRequired()
                    .HasMaxLength(26)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.HasKey(e => e.Idpedido);

                entity.Property(e => e.Idpedido)
                    .ValueGeneratedNever()
                    .HasColumnName("IDPedido");

                entity.Property(e => e.Idproveedor).HasColumnName("IDProveedor");

                entity.Property(e => e.Idusuario).HasColumnName("IDUsuario");

                entity.Property(e => e.Observaciones).HasMaxLength(500);

                entity.Property(e => e.Total)
                    .HasColumnType("decimal(14, 2)")
                    .HasAnnotation("Relational:ColumnType", "decimal(14, 2)");

                entity.HasOne(d => d.IdproveedorNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.Idproveedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Pedidos__IDProve__09A971A2");

                entity.HasOne(d => d.IdusuarioNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.Idusuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Pedidos__IDUsuar__0A9D95DB");
            });

            modelBuilder.Entity<PedidosDetalle>(entity =>
            {
                entity.HasKey(e => e.IdpedidoDetalle);

                entity.ToTable("PedidosDetalle");

                entity.Property(e => e.IdpedidoDetalle)
                    .ValueGeneratedNever()
                    .HasColumnName("IDPedidoDetalle");

                entity.Property(e => e.Cantidad)
                    .HasColumnType("decimal(9, 2)")
                    .HasAnnotation("Relational:ColumnType", "decimal(9, 2)");

                entity.Property(e => e.Idarticulo).HasColumnName("IDArticulo");

                entity.Property(e => e.Idpedido).HasColumnName("IDPedido");

                entity.HasOne(d => d.IdarticuloNavigation)
                    .WithMany(p => p.PedidosDetalles)
                    .HasForeignKey(d => d.Idarticulo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PedidosDe__IDArt__0D7A0286");

                entity.HasOne(d => d.IdpedidoNavigation)
                    .WithMany(p => p.PedidosDetalles)
                    .HasForeignKey(d => d.Idpedido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PedidosDe__IDPed__0C85DE4D");
            });

            modelBuilder.Entity<Proveedore>(entity =>
            {
                entity.HasKey(e => e.Idproveedor);

                entity.Property(e => e.Idproveedor)
                    .ValueGeneratedNever()
                    .HasColumnName("IDProveedor");

                entity.Property(e => e.ApellidoyNombre)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Comentario).HasMaxLength(300);

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(80);

                entity.Property(e => e.Email1).HasMaxLength(50);

                entity.Property(e => e.Email2).HasMaxLength(50);

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("smalldatetime")
                    .HasAnnotation("Relational:ColumnType", "smalldatetime");

                entity.Property(e => e.Idciudad).HasColumnName("IDCiudad");

                entity.Property(e => e.IdtipoDocumento).HasColumnName("IDTipoDocumento");

                entity.Property(e => e.IdtipoEstado).HasColumnName("IDTipoEstado");

                entity.Property(e => e.Telefono).HasMaxLength(70);

                entity.HasOne(d => d.IdciudadNavigation)
                    .WithMany(p => p.Proveedores)
                    .HasForeignKey(d => d.Idciudad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Proveedor__IDCiu__0F624AF8");

                entity.HasOne(d => d.IdtipoDocumentoNavigation)
                    .WithMany(p => p.Proveedores)
                    .HasForeignKey(d => d.IdtipoDocumento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Proveedor__IDTip__0E6E26BF");

                entity.HasOne(d => d.IdtipoEstadoNavigation)
                    .WithMany(p => p.Proveedores)
                    .HasForeignKey(d => d.IdtipoEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Proveedor__IDTip__10566F31");
            });

            modelBuilder.Entity<Rubro>(entity =>
            {
                entity.HasKey(e => e.Idrubro);

                entity.Property(e => e.Idrubro)
                    .ValueGeneratedNever()
                    .HasColumnName("IDRubro");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<SubRubro>(entity =>
            {
                entity.HasKey(e => e.IdsubRubro);

                entity.Property(e => e.IdsubRubro)
                    .ValueGeneratedNever()
                    .HasColumnName("IDSubRubro");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Idrubro).HasColumnName("IDRubro");

                entity.HasOne(d => d.IdrubroNavigation)
                    .WithMany(p => p.SubRubros)
                    .HasForeignKey(d => d.Idrubro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SubRubros__IDRub__60A75C0F");
            });

            modelBuilder.Entity<TiposDocumento>(entity =>
            {
                entity.HasKey(e => e.IdtipoDocumento);

                entity.Property(e => e.IdtipoDocumento)
                    .ValueGeneratedNever()
                    .HasColumnName("IDTipoDocumento");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TiposEstado>(entity =>
            {
                entity.HasKey(e => e.IdtipoEstado);

                entity.Property(e => e.IdtipoEstado)
                    .ValueGeneratedNever()
                    .HasColumnName("IDTipoEstado");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TiposUsuario>(entity =>
            {
                entity.HasKey(e => e.IdtipoUsuario);

                entity.Property(e => e.IdtipoUsuario)
                    .ValueGeneratedNever()
                    .HasColumnName("IDTipoUsuario");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<UnidadesMedida>(entity =>
            {
                entity.HasKey(e => e.IdunidadMedida);

                entity.Property(e => e.IdunidadMedida)
                    .ValueGeneratedNever()
                    .HasColumnName("IDUnidadMedida");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Idusuario);

                entity.Property(e => e.Idusuario)
                    .ValueGeneratedNever()
                    .HasColumnName("IDUsuario");

                entity.Property(e => e.Contraseña)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsFixedLength(true);

                entity.Property(e => e.IdtipoEstado).HasColumnName("IDTipoEstado");

                entity.Property(e => e.IdtipoUsuario).HasColumnName("IDTipoUsuario");

                entity.Property(e => e.NombreUsuario)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.HasOne(d => d.IdtipoEstadoNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdtipoEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Usuarios__IDTipo__123EB7A3");

                entity.HasOne(d => d.IdtipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdtipoUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Usuarios__IDTipo__114A936A");
            });

            modelBuilder.Entity<Venta>(entity =>
            {
                entity.HasKey(e => e.Idventa);

                entity.Property(e => e.Idventa)
                    .ValueGeneratedNever()
                    .HasColumnName("IDVenta");

                entity.Property(e => e.Idcliente).HasColumnName("IDCliente");

                entity.Property(e => e.Idusuario).HasColumnName("IDUsuario");

                entity.Property(e => e.Observaciones).HasMaxLength(500);

                entity.Property(e => e.Total)
                    .HasColumnType("decimal(14, 2)")
                    .HasAnnotation("Relational:ColumnType", "decimal(14, 2)");

                entity.HasOne(d => d.IdclienteNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.Idcliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Ventas__IDClient__1332DBDC");

                entity.HasOne(d => d.IdusuarioNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.Idusuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Ventas__IDUsuari__14270015");
            });

            modelBuilder.Entity<VentasDetalle>(entity =>
            {
                entity.HasKey(e => e.IdventaDetalle);

                entity.ToTable("VentasDetalle");

                entity.Property(e => e.IdventaDetalle)
                    .ValueGeneratedNever()
                    .HasColumnName("IDVentaDetalle");

                entity.Property(e => e.Cantidad)
                    .HasColumnType("decimal(9, 2)")
                    .HasAnnotation("Relational:ColumnType", "decimal(9, 2)");

                entity.Property(e => e.Idarticulo).HasColumnName("IDArticulo");

                entity.Property(e => e.Idventa).HasColumnName("IDVenta");

                entity.HasOne(d => d.IdarticuloNavigation)
                    .WithMany(p => p.VentasDetalles)
                    .HasForeignKey(d => d.Idarticulo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__VentasDet__IDArt__160F4887");

                entity.HasOne(d => d.IdventaNavigation)
                    .WithMany(p => p.VentasDetalles)
                    .HasForeignKey(d => d.Idventa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__VentasDet__IDVen__151B244E");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
