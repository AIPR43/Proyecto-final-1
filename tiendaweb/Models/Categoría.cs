using System;
using System.Collections.Generic;

namespace tiendaweb.Models
{
    public partial class Categoría
    {
        public Categoría()
        {
            Productos = new HashSet<Producto>();
        }

        public int CategoríaId { get; set; }
        public string? Nombre { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
