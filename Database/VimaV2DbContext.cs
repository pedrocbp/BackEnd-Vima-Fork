using Microsoft.EntityFrameworkCore;
using VimaV2.Models;

namespace VimaV2.Database
{
    public partial class VimaV2DbContext : DbContext
    {
        public DbSet<User> Usuarios { get; set; }
        public DbSet<Contato> Contatos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Carrinho> Carrinhos { get; set; }

        public VimaV2DbContext()
        {
        }

        public VimaV2DbContext(DbContextOptions<VimaV2DbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
            => optionsBuilder.UseMySql("server=localhost;user id=root;database=vima; password=password", ServerVersion.Parse("8.0.37-mysql"));

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");

            // Configurações adicionais do modelo
            modelBuilder.Entity<Produto>()
                .Property(p => p.Tamanhos)
                .HasConversion(
                    v => string.Join(',', v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList());

            modelBuilder.Entity<Produto>()
                .Property(p => p.Imagens)
                .HasConversion(
                    v => string.Join(',', v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
