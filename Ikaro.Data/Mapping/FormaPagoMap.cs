using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Ikaro.Core.Domain;

namespace Ikaro.Data.Mapping
{
    public class FormaPagoMap : EntityTypeConfiguration<FormaPago>
    {
        public FormaPagoMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.descripcion)
                .IsRequired()
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("FormaPago");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.descripcion).HasColumnName("descripcion");
            this.Property(t => t.nroDias).HasColumnName("nroDias");
        }
    }
}
