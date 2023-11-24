using System;
using System.Collections.Generic;

namespace tiendaweb.Models
{
    public partial class Venta
    {
        public Venta()
        {
            DetallesVenta = new HashSet<DetallesVenta>();
        }

        public int VentaId { get; set; }
        public int? EmpleadoId { get; set; }
        public DateTime? Fecha { get; set; }
        public decimal? Total { get; set; }

        public virtual Empleado? Empleado { get; set; }
        public virtual ICollection<DetallesVenta> DetallesVenta { get; set; }
    }
}
