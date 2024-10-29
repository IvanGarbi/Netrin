using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Netrin.Domain.Models;

namespace Netrin.Data.Mappings
{
    public class PessoaMapping : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Telefone)
                .IsRequired()
                .HasColumnType("VARCHAR(20)");

            builder.Property(x => x.Email)
                .IsRequired()
                .HasColumnType("VARCHAR(100)");

            builder.Property(x => x.CPF)
                .IsRequired()
                .HasColumnType("VARCHAR(11)");

            builder.Property(x => x.DataNascimento)
                .IsRequired()
                .HasColumnType("DATE");

            builder.Property(x => x.NomeCompleto)
                .IsRequired()
                .HasColumnType("VARCHAR(100)");

            builder.ToTable("Pessoas");
        }
    }
}
