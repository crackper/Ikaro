using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//importamos
using Ikaro.Core.Data;
using Ikaro.Core.Domain;
using Ikaro.Data;

namespace Ikaro.Service
{
    public class ProductoService:IProductoService
    {
        IUnitOfWork _uow;
        IRepository<Producto> _repository;

        public ProductoService(IUnitOfWork uow)
        {
            _uow = uow;
            _repository = _uow.GetRepository<Producto>();
        }

        public List<Producto> GetProductoByCriterio(string criterio)
        {
            var query = _repository.TableInclude(p => p.Categoria);

            if (criterio != "" && criterio !=null)
            {
                query = from p in query
                        where p.Descripcion.ToUpper().Contains(criterio.ToUpper()) ||
                              p.Codigo.ToUpper().Contains(criterio.ToUpper())
                        select p;
            }

            return query.ToList();
        }

        public Producto GetProductoById(int id)
        {
            throw new NotImplementedException();
        }

        public void AddProducto(Producto producto)
        {
            throw new NotImplementedException();
        }

        public void UpdateProducto(Producto producto)
        {
            throw new NotImplementedException();
        }

        public void RemoveProducto(int id)
        {
            throw new NotImplementedException();
        }
    }
}
