using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Ikaro.Core.Domain;

namespace Ikaro.Data.Mapping
{
    public class PedidoMap : EntityTypeConfiguration<Pedido>
    {
        public PedidoMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            // Table & Column Mappings
            this.ToTable("Pedido");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.clienteId).HasColumnName("clienteId");
            this.Property(t => t.fecha).HasColumnName("fecha");
            this.Property(t => t.total).HasColumnName("total");
            this.Property(t => t.formaPagoId).HasColumnName("formaPagoId");

            // Relationships
            this.HasRequired(t => t.Cliente)
                .WithMany(t => t.Pedidoes)
                .HasForeignKey(d => d.clienteId);
            this.HasRequired(t => t.FormaPago)
                .WithMany(t => t.Pedidoes)
                .HasForeignKey(d => d.formaPagoId);

        }
    }
}
