using LPR_Intercon.Shared.Models.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace LPR_Intercon.Shared.Data;

public class SqliteDbContext(DbContextOptions<SqliteDbContext> options) : DbContext(options)
{
    public DbSet<Veiculo> Veiculo { get; set; }
    public DbSet<Unidade> Unidade { get; set; }
    public DbSet<Condominio> Condominio { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Veiculo>()
         .HasOne(v => v.Unidade)
         .WithMany()
         .HasForeignKey(v => v.UnidadeId);

        modelBuilder.Entity<Condominio>()
            .HasIndex(c => c.Cnpj)
            .IsUnique();

        /*
        modelBuilder.Entity<Veiculo>()
            .HasOne(v => v.Rota)
            .WithMany()
            .HasForeignKey(v => v.IdRota);
        */

    }
}