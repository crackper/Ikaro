using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//importamos
using Ikaro.Core.Data;
using System.Data.Entity;

namespace Ikaro.Data
{
    public class Repository<TEntinty>:IRepository<TEntinty>
        where TEntinty:class
    {
        IDbContext _context;
        IDbSet<TEntinty> _entities;

        public Repository(IDbContext context)
        { 
            _context = context;

            if (_entities == null)
            {
                _entities = _context.Set<TEntinty>();
            }
        }

        protected internal DBContextBase InternalContext 
        {
            get{ return _context as DBContextBase;}
        }

        public IQueryable<TEntinty> Table
        {
            get { return _entities as DbSet<TEntinty>; }
        }

        public IQueryable<TEntinty> TableInclude(params System.Linq.Expressions.Expression<Func<TEntinty, object>>[] includes)
        {
            var query = _entities;

            foreach (var include in includes)
            {
                query.Include(include);
            }

            return query;
        }

        public TEntinty GetById(int id)
        {
            return _entities.Find(id);
        }

        public void Insert(TEntinty entity)
        {
            if(entity == null)
                throw new ArgumentNullException("entity es null");

            _entities.Add(entity);
        }

        public void Update(TEntinty entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity es null");

            _entities.Attach(entity);
            InternalContext.Entry(entity).State = System.Data.EntityState.Modified;
        }

        public void Remove(int id)
        {
            var entity = _entities.Find(id);

            if (entity == null)
                throw new ArgumentNullException("entity es null");

            Remove(entity);
        }

        public void Remove(TEntinty entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity es null");

            _entities.Remove(entity);
        }
    }
}
