using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Ikaro.Core.Domain;

namespace Ikaro.Data.Mapping
{
    public class PreferenciaMap : EntityTypeConfiguration<Preferencia>
    {
        public PreferenciaMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Descripcion)
                .IsRequired()
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("Preferencia");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Descripcion).HasColumnName("Descripcion");

            // Relationships
            this.HasMany(t => t.Usuarios)
                .WithMany(t => t.Preferencias)
                .Map(m =>
                    {
                        m.ToTable("PreferenciasUsuario");
                        m.MapLeftKey("PreferenciaId");
                        m.MapRightKey("UsuarioId");
                    });


        }
    }
}
