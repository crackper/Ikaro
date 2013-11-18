using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//importamos
using Ikaro.Core.Domain;

namespace Ikaro.Service
{
    public interface IProductoService
    {
        List<Producto> GetProductoByCriterio(string criterio);
        Producto GetProductoById(Int32 id);
        void AddProducto(Producto producto);
        void UpdateProducto(Producto producto);
        void RemoveProducto(Int32 id);
    }
}
