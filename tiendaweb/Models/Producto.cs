using System;
using System.Collections.Generic;

namespace tiendaweb.Models
{
    public partial class Producto
    {
        public Producto()
        {
            DetallesCompras = new HashSet<DetallesCompra>();
            DetallesVenta = new HashSet<DetallesVenta>();
            Inventarios = new HashSet<Inventario>();
        }

        public int ProductoId { get; set; }
        public int? CategoríaId { get; set; }
        public string? Nombre { get; set; }
        public string? Descripción { get; set; }
        public decimal? Precio { get; set; }

        public virtual Categoría? Categoría { get; set; }
        public virtual ICollection<DetallesCompra> DetallesCompras { get; set; }
        public virtual ICollection<DetallesVenta> DetallesVenta { get; set; }
        public virtual ICollection<Inventario> Inventarios { get; set; }
    }
}
