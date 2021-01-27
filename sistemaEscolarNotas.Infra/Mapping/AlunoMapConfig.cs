using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sistemaEscolarNotas.Domain;

namespace sistemaEscolarNotas.Infra.Mapping
{
    public class AlunoMapConfig : IEntityTypeConfiguration<AlunoEntity>
    {
        public void Configure(EntityTypeBuilder<AlunoEntity> builder)
        {
            builder.ToTable("ALUNOS");

            builder.Property(a => a.NomeAluno)
                .HasColumnName("Nome")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(a => a.Email)
                .HasColumnName("Email")
                .HasMaxLength(70)
                .IsRequired();

            builder.Property(a => a.CPF)
                .HasColumnName("CPF")
                .IsFixedLength()
                .HasMaxLength(14)
                .IsRequired();

            builder.Property(a => a.Telefone)
                .HasColumnName("Telefone")
                .IsFixedLength()
                .HasMaxLength(11)
                .IsRequired();
        }
    }
}
