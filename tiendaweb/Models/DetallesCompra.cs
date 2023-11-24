using System;
using System.Collections.Generic;

namespace tiendaweb.Models
{
    public partial class DetallesCompra
    {
        public int DetalleId { get; set; }
        public int? CompraId { get; set; }
        public int? ProductoId { get; set; }
        public int? Cantidad { get; set; }
        public decimal? PrecioUnitario { get; set; }

        public virtual Compra? Compra { get; set; }
        public virtual Producto? Producto { get; set; }
    }
}
