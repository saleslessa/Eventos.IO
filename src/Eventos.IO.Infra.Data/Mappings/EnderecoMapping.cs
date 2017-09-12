using Eventos.IO.Domain.Eventos;
using Eventos.IO.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eventos.IO.Infra.Data.Mappings
{
    public class EnderecoMapping : EntityTypeConfiguration<Endereco>
    {
        public override void Map(EntityTypeBuilder<Endereco> builder)
        {
            builder.Property(p => p.Cidade)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.Estado)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.Numero)
                .HasColumnType("varchar(20)")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(p => p.CEP)
                .IsRequired()
                .HasColumnType("varchar(8)")
                .HasMaxLength(8);

            builder.Property(p => p.Complemento)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

            builder.HasOne(h => h.Evento)
                .WithOne(h => h.Endereco)
                .HasForeignKey<Endereco>(h => h.EventoId)
                .IsRequired(false);

            builder.Ignore(i => i.ValidationResult);

            builder.Ignore(i => i.CascadeMode);

            builder.ToTable("Enderecos");
        }
    }
}
