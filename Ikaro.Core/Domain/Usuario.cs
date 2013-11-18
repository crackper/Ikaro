using System;
using System.Collections.Generic;

namespace Ikaro.Core.Domain
{
    public partial class Usuario
    {
        public Usuario()
        {
            this.Preferencias = new List<Preferencia>();
        }

        public int Id { get; set; }
        public string Nombres { get; set; }
        public virtual ICollection<Preferencia> Preferencias { get; set; }
    }
}
