using System;
using System.Collections.Generic;

namespace tiendaweb.Models
{
    public partial class Compra
    {
        public Compra()
        {
            DetallesCompras = new HashSet<DetallesCompra>();
        }

        public int CompraId { get; set; }
        public int? ProveedorId { get; set; }
        public DateTime? Fecha { get; set; }
        public decimal? Total { get; set; }

        public virtual Proveedore? Proveedor { get; set; }
        public virtual ICollection<DetallesCompra> DetallesCompras { get; set; }
    }
}
