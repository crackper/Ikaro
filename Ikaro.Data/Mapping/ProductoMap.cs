using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Ikaro.Core.Domain;

namespace Ikaro.Data.Mapping
{
    public class ProductoMap : EntityTypeConfiguration<Producto>
    {
        public ProductoMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Codigo)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Descripcion)
                .IsRequired()
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("Producto");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.CategoriaId).HasColumnName("CategoriaId");
            this.Property(t => t.Codigo).HasColumnName("Codigo");
            this.Property(t => t.Descripcion).HasColumnName("Descripcion");
            this.Property(t => t.Precio).HasColumnName("Precio");
            this.Property(t => t.Stock).HasColumnName("Stock");
            this.Property(t => t.Foto).HasColumnName("Foto");
            this.Property(t => t.Descontinuado).HasColumnName("Descontinuado");

            // Relationships
            this.HasRequired(t => t.Categoria)
                .WithMany(t => t.Productoes)
                .HasForeignKey(d => d.CategoriaId);

        }
    }
}
