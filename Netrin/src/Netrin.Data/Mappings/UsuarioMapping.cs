using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Netrin.Domain.Models;

namespace Netrin.Data.Mappings
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasColumnType("VARCHAR(100)");

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnType("VARCHAR(100)");

            builder.ToTable("Usuarios");
        }
    }
}
