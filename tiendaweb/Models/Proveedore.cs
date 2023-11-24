using System;
using System.Collections.Generic;

namespace tiendaweb.Models
{
    public partial class Proveedore
    {
        public Proveedore()
        {
            Compras = new HashSet<Compra>();
        }

        public int ProveedorId { get; set; }
        public string? Nombre { get; set; }
        public string? Dirección { get; set; }
        public string? Email { get; set; }
        public string? Teléfono { get; set; }

        public virtual ICollection<Compra> Compras { get; set; }
    }
}
