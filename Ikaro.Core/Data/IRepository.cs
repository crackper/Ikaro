using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//importamos
using System.Linq.Expressions;

namespace Ikaro.Core.Data
{
    public interface IRepository<TEntity>
        where TEntity:class
    {
        IQueryable<TEntity> Table { get; }
        IQueryable<TEntity> TableInclude(params Expression<Func<TEntity,object>>[] includes );
        TEntity GetById(Int32 id);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Remove(Int32 id);
        void Remove(TEntity entity);
    }
}
