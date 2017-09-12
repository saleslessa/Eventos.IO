using Eventos.IO.Domain.Eventos;
using Eventos.IO.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Eventos.IO.Infra.Data.Mappings
{
    public class EventoMapping : EntityTypeConfiguration<Evento>
    {
        public override void Map(EntityTypeBuilder<Evento> builder)
        {
            builder.Property(p => p.Nome)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(p => p.DescricaoCurta)
                .HasColumnType("varchar(150)");

            builder.Property(p => p.DescricaoLonga)
                .HasColumnType("varchar(max)");

            builder.Property(p => p.NomeEmpresa)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Ignore(i => i.ValidationResult);

            builder.Ignore(i => i.CascadeMode);

            builder.Ignore(i => i.Tags);

            builder.ToTable("Eventos");

            builder.HasOne(h => h.Organizador)
                .WithMany(o => o.Eventos)
                .HasForeignKey(h => h.OrganizadorId);

            builder.HasOne(h => h.Categoria)
                .WithMany(o => o.Eventos)
                .HasForeignKey(h => h.CategoriaId)
                .IsRequired(false);
        }
    }
}
