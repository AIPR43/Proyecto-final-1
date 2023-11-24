using System;
using System.Collections.Generic;

namespace tiendaweb.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Empleados = new HashSet<Empleado>();
        }

        public int UsuarioId { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Email { get; set; }
        public string? Contraseña { get; set; }

        public virtual ICollection<Empleado> Empleados { get; set; }
    }
}
