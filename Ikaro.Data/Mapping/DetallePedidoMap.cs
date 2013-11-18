using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Ikaro.Core.Domain;

namespace Ikaro.Data.Mapping
{
    public class DetallePedidoMap : EntityTypeConfiguration<DetallePedido>
    {
        public DetallePedidoMap()
        {
            // Primary Key
            this.HasKey(t => new { t.item, t.pedidoId });

            // Properties
            this.Property(t => t.item)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.pedidoId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("DetallePedido");
            this.Property(t => t.item).HasColumnName("item");
            this.Property(t => t.pedidoId).HasColumnName("pedidoId");
            this.Property(t => t.productoId).HasColumnName("productoId");
            this.Property(t => t.cantidad).HasColumnName("cantidad");
            this.Property(t => t.precio).HasColumnName("precio");

            // Relationships
            this.HasRequired(t => t.Pedido)
                .WithMany(t => t.DetallePedidoes)
                .HasForeignKey(d => d.pedidoId);
            this.HasRequired(t => t.Producto)
                .WithMany(t => t.DetallePedidoes)
                .HasForeignKey(d => d.productoId);

        }
    }
}
