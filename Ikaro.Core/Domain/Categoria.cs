using System;
using System.Collections.Generic;

namespace Ikaro.Core.Domain
{
    public partial class Categoria
    {
        public Categoria()
        {
            this.Productoes = new List<Producto>();
        }

        public int id { get; set; }
        public string descripcion { get; set; }
        public string comentario { get; set; }
        public virtual ICollection<Producto> Productoes { get; set; }
    }
}
