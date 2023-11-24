using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace tiendaweb.Models
{
    public partial class tiendaContext : DbContext
    {
        public tiendaContext()
        {
        }

        public tiendaContext(DbContextOptions<tiendaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categoría> Categorías { get; set; } = null!;
        public virtual DbSet<Compra> Compras { get; set; } = null!;
        public virtual DbSet<DetallesCompra> DetallesCompras { get; set; } = null!;
        public virtual DbSet<DetallesVenta> DetallesVentas { get; set; } = null!;
        public virtual DbSet<Empleado> Empleados { get; set; } = null!;
        public virtual DbSet<Inventario> Inventarios { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<Proveedore> Proveedores { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;
        public virtual DbSet<Venta> Ventas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=tienda;Data Source=MSI\\SQLEXPRESS");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoría>(entity =>
            {
                entity.Property(e => e.CategoríaId)
                    .ValueGeneratedNever()
                    .HasColumnName("CategoríaID");

                entity.Property(e => e.Nombre).HasMaxLength(100);
            });

            modelBuilder.Entity<Compra>(entity =>
            {
                entity.Property(e => e.CompraId)
                    .ValueGeneratedNever()
                    .HasColumnName("CompraID");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.ProveedorId).HasColumnName("ProveedorID");

                entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Proveedor)
                    .WithMany(p => p.Compras)
                    .HasForeignKey(d => d.ProveedorId)
                    .HasConstraintName("FK__Compras__Proveed__5AEE82B9");
            });

            modelBuilder.Entity<DetallesCompra>(entity =>
            {
                entity.HasKey(e => e.DetalleId)
                    .HasName("PK__Detalles__6E19D6FA1E70F5FF");

                entity.Property(e => e.DetalleId)
                    .ValueGeneratedNever()
                    .HasColumnName("DetalleID");

                entity.Property(e => e.CompraId).HasColumnName("CompraID");

                entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.ProductoId).HasColumnName("ProductoID");

                entity.HasOne(d => d.Compra)
                    .WithMany(p => p.DetallesCompras)
                    .HasForeignKey(d => d.CompraId)
                    .HasConstraintName("FK__DetallesC__Compr__5BE2A6F2");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.DetallesCompras)
                    .HasForeignKey(d => d.ProductoId)
                    .HasConstraintName("FK__DetallesC__Produ__5CD6CB2B");
            });

            modelBuilder.Entity<DetallesVenta>(entity =>
            {
                entity.HasKey(e => e.DetalleId)
                    .HasName("PK__Detalles__6E19D6FACE015727");

                entity.Property(e => e.DetalleId)
                    .ValueGeneratedNever()
                    .HasColumnName("DetalleID");

                entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.ProductoId).HasColumnName("ProductoID");

                entity.Property(e => e.VentaId).HasColumnName("VentaID");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.DetallesVenta)
                    .HasForeignKey(d => d.ProductoId)
                    .HasConstraintName("FK__DetallesV__Produ__5DCAEF64");

                entity.HasOne(d => d.Venta)
                    .WithMany(p => p.DetallesVenta)
                    .HasForeignKey(d => d.VentaId)
                    .HasConstraintName("FK__DetallesV__Venta__5EBF139D");
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.Property(e => e.EmpleadoId)
                    .ValueGeneratedNever()
                    .HasColumnName("EmpleadoID");

                entity.Property(e => e.Apellido).HasMaxLength(100);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Nombre).HasMaxLength(100);

                entity.Property(e => e.Teléfono).HasMaxLength(15);

                entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.UsuarioId)
                    .HasConstraintName("FK__Empleados__Usuar__5FB337D6");
            });

            modelBuilder.Entity<Inventario>(entity =>
            {
                entity.ToTable("Inventario");

                entity.Property(e => e.InventarioId)
                    .ValueGeneratedNever()
                    .HasColumnName("InventarioID");

                entity.Property(e => e.ProductoId).HasColumnName("ProductoID");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.Inventarios)
                    .HasForeignKey(d => d.ProductoId)
                    .HasConstraintName("FK__Inventari__Produ__60A75C0F");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.Property(e => e.ProductoId)
                    .ValueGeneratedNever()
                    .HasColumnName("ProductoID");

                entity.Property(e => e.CategoríaId).HasColumnName("CategoríaID");

                entity.Property(e => e.Descripción).HasMaxLength(255);

                entity.Property(e => e.Nombre).HasMaxLength(100);

                entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Categoría)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.CategoríaId)
                    .HasConstraintName("FK__Productos__Categ__619B8048");
            });

            modelBuilder.Entity<Proveedore>(entity =>
            {
                entity.HasKey(e => e.ProveedorId)
                    .HasName("PK__Proveedo__61266BB97410FF03");

                entity.Property(e => e.ProveedorId)
                    .ValueGeneratedNever()
                    .HasColumnName("ProveedorID");

                entity.Property(e => e.Dirección).HasMaxLength(255);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Nombre).HasMaxLength(100);

                entity.Property(e => e.Teléfono).HasMaxLength(15);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.UsuarioId)
                    .ValueGeneratedNever()
                    .HasColumnName("UsuarioID");

                entity.Property(e => e.Apellido).HasMaxLength(100);

                entity.Property(e => e.Contraseña).HasMaxLength(100);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Nombre).HasMaxLength(100);
            });

            modelBuilder.Entity<Venta>(entity =>
            {
                entity.Property(e => e.VentaId)
                    .ValueGeneratedNever()
                    .HasColumnName("VentaID");

                entity.Property(e => e.EmpleadoId).HasColumnName("EmpleadoID");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Empleado)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.EmpleadoId)
                    .HasConstraintName("FK__Ventas__Empleado__628FA481");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
