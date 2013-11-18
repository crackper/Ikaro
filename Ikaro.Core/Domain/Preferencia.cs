using System;
using System.Collections.Generic;

namespace Ikaro.Core.Domain
{
    public partial class Preferencia
    {
        public Preferencia()
        {
            this.Usuarios = new List<Usuario>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
