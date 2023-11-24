using System;
using System.Collections.Generic;

namespace tiendaweb.Models
{
    public partial class Empleado
    {
        public Empleado()
        {
            Venta = new HashSet<Venta>();
        }

        public int EmpleadoId { get; set; }
        public int? UsuarioId { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Email { get; set; }
        public string? Teléfono { get; set; }

        public virtual Usuario? Usuario { get; set; }
        public virtual ICollection<Venta> Venta { get; set; }
    }
}
