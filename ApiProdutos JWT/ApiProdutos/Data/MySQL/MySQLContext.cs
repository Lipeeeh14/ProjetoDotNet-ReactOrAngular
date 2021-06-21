using ApiProdutos.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ApiProdutos.Data.MySQL
{
    public class MySQLContext : IdentityDbContext
    {
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Produto>()
                .Property(p => p.Nome)
                    .HasMaxLength(80);

            modelBuilder.Entity<Produto>()
                .Property(p => p.Preco)
                    .HasPrecision(10, 2);

            // inclui dados iniciais quando o db e a tabela forem gerados
            modelBuilder.Entity<Produto>()
                .HasData(
                    new Produto { Id = 1, Nome = "Caderno", Preco = 7.95M, Estoque = 10 },
                    new Produto { Id = 2, Nome = "Borracha", Preco = 2.45M, Estoque = 30 },
                    new Produto { Id = 3, Nome = "Estojo", Preco = 6.25M, Estoque = 15 }
                );

            /*modelBuilder.Entity<AppUser>(entity => entity.Property(m => m.Id).HasMaxLength(85));
            modelBuilder.Entity<AppRole>(entity => entity.Property(m => m.Id).HasMaxLength(85));

            modelBuilder.Entity<IdentityUserClaim<string>>(entity => entity.Property(m => m.Id).HasMaxLength(85));
            modelBuilder.Entity<IdentityRoleClaim<string>>(entity => entity.Property(m => m.Id).HasMaxLength(85));

            modelBuilder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.LoginProvider).HasMaxLength(85));
            modelBuilder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.ProviderKey).HasMaxLength(85));

            modelBuilder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.LoginProvider).HasMaxLength(85));
            modelBuilder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.Name).HasMaxLength(85));*/
        }
    }
}
