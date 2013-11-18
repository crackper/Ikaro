using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Ikaro.Core.Domain;
using Ikaro.Data.Mapping;

namespace Ikaro.Data
{
    public partial class DBSystemContext : DBContextBase
    {
        public DBSystemContext(string nameOrConnectionString)
            :base(nameOrConnectionString)
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CategoriaMap());
            modelBuilder.Configurations.Add(new ClienteMap());
            modelBuilder.Configurations.Add(new DetallePedidoMap());
            modelBuilder.Configurations.Add(new FormaPagoMap());
            modelBuilder.Configurations.Add(new PedidoMap());
            modelBuilder.Configurations.Add(new PreferenciaMap());
            modelBuilder.Configurations.Add(new ProductoMap());
            modelBuilder.Configurations.Add(new ProveedorMap());
            modelBuilder.Configurations.Add(new RepUtiMap());
            modelBuilder.Configurations.Add(new sysdiagramMap());
            modelBuilder.Configurations.Add(new UsuarioMap());
        }
    }
}
