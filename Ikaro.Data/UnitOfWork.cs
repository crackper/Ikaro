using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//importamos
using Ikaro.Core.Data;

namespace Ikaro.Data
{
    public class UnitOfWork:IUnitOfWork
    {
        IDbContext _context;
        Dictionary<Type, object> _repositorios;

        public UnitOfWork(IDbContext context)
        {
            _context = context;
            _repositorios = new Dictionary<Type, object>();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (_repositorios.Keys.Contains(typeof(TEntity)))
                return _repositorios[typeof(TEntity)] as IRepository<TEntity>;

            var repository = new Repository<TEntity>(_context);
            _repositorios.Add(typeof(TEntity), repository);

            return repository;          
        }
    }
}
