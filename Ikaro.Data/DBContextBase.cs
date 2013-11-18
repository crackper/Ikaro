using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//importmaos
using Ikaro.Core.Data;
using System.Data.Entity;

namespace Ikaro.Data
{
    public class DBContextBase:DbContext,IDbContext
    {
        protected DBContextBase(string nameOrConnectionString)
            :base(nameOrConnectionString)
        { }


        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
    }
}
