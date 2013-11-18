using System;
using System.Collections.Generic;

namespace Ikaro.Core.Domain
{
    public partial class FormaPago
    {
        public FormaPago()
        {
            this.Pedidoes = new List<Pedido>();
        }

        public int id { get; set; }
        public string descripcion { get; set; }
        public int nroDias { get; set; }
        public virtual ICollection<Pedido> Pedidoes { get; set; }
    }
}
