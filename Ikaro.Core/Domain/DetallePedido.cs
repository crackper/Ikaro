using System;
using System.Collections.Generic;

namespace Ikaro.Core.Domain
{
    public partial class DetallePedido
    {
        public int item { get; set; }
        public int pedidoId { get; set; }
        public int productoId { get; set; }
        public decimal cantidad { get; set; }
        public decimal precio { get; set; }
        public virtual Pedido Pedido { get; set; }
        public virtual Producto Producto { get; set; }
    }
}
