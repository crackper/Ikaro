using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Ikaro.Core.Domain;

namespace Ikaro.Data.Mapping
{
    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Nombres)
                .IsRequired()
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("Usuario");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Nombres).HasColumnName("Nombres");
        }
    }
}
