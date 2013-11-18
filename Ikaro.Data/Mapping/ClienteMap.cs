using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Ikaro.Core.Domain;

namespace Ikaro.Data.Mapping
{
    public class ClienteMap : EntityTypeConfiguration<Cliente>
    {
        public ClienteMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.rucDni)
                .IsRequired()
                .HasMaxLength(15);

            this.Property(t => t.razonSocial)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.direccion)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("Cliente");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.rucDni).HasColumnName("rucDni");
            this.Property(t => t.razonSocial).HasColumnName("razonSocial");
            this.Property(t => t.direccion).HasColumnName("direccion");
        }
    }
}
