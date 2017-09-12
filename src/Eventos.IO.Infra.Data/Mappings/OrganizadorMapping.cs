using Eventos.IO.Domain.Organizadores;
using Eventos.IO.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Eventos.IO.Infra.Data.Mappings
{
    public class OrganizadorMapping : EntityTypeConfiguration<Organizador>
    {
        public override void Map(EntityTypeBuilder<Organizador> builder)
        {
            builder.Ignore(i => i.ValidationResult);

            builder.Ignore(i => i.CascadeMode);

            builder.Property(p => p.Nome)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(p => p.Email)
                .HasColumnType("varchar(100)")
                .IsRequired();  

            builder.Property(p => p.CPF)
                .HasColumnType("varchar(11)")
                .IsRequired();

            builder.ToTable("Organizadores");
        }
    }
}
