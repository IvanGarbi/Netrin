using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Netrin.Domain.Models;

namespace Netrin.Data.Mappings
{
    public class EnderecoMapping : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Numero)
                .IsRequired()
                .HasColumnType("INTEGER");

            builder.Property(x => x.Estado)
                .IsRequired()
                .HasColumnType("VARCHAR(2)");

            builder.Property(x => x.Cidade)
                .IsRequired()
                .HasColumnType("VARCHAR(50)");

            builder.Property(x => x.CEP)
                .IsRequired()
                .HasColumnType("VARCHAR(8)");

            builder.Property(x => x.Rua)
                .IsRequired()
                .HasColumnType("VARCHAR(100)");

            builder.Property(x => x.PessoaId)
                .IsRequired()
                .HasColumnType("UUID");

            builder.HasOne(x => x.Pessoa)
                .WithOne(y => y.Endereco)
                .HasForeignKey<Endereco>(e => e.PessoaId);

            builder.ToTable("Enderecos");
        }
    }
}
