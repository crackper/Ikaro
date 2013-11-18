using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Ikaro.Core.Domain;

namespace Ikaro.Data.Mapping
{
    public class RepUtiMap : EntityTypeConfiguration<RepUti>
    {
        public RepUtiMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Tipo)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("RepUti");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.Tipo).HasColumnName("Tipo");
            this.Property(t => t.Porcentaje).HasColumnName("Porcentaje");
        }
    }
}
