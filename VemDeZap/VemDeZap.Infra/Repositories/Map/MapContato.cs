using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VemDeZap.Domain.Entities;

namespace VemDeZap.Infra.Repositories.Map
{
    public class MapContato : IEntityTypeConfiguration<Contato>
    {
        public void Configure(EntityTypeBuilder<Contato> builder)
        {
            builder.ToTable("Contato");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).HasMaxLength(150).IsRequired();
            builder.Property(x => x.Telefone).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Nicho).HasMaxLength(150).IsRequired();
            builder.HasOne(x => x.Usuario).WithMany().HasForeignKey("IdUsuario");
        }
    }
}
