using Microsoft.EntityFrameworkCore;
using prmToolkit.NotificationPattern;
using VemDeZap.Domain.Entities;
using VemDeZap.Infra.Repositories.Map;

namespace VemDeZap.Infra.Repositories.Base
{
    public partial class VemDeZapContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Campanha> Campanhas { get; set; }
        public DbSet<Envio> Envios { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<Contato> Contatos { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Server=localhost;Database=VemDeZap;Uid=root;Pwd=root;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Ignore<Notification>();

            modelBuilder.ApplyConfiguration(new MapUsuario());
            modelBuilder.ApplyConfiguration(new MapContato());
            modelBuilder.ApplyConfiguration(new MapGrupo());
        }
    }
}
