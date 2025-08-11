using LPR_Intercon.Shared.Models.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace LPR_Intercon.Server.Data;

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

        /*
        modelBuilder.Entity<Veiculo>()
            .HasOne(v => v.Rota)
            .WithMany()
            .HasForeignKey(v => v.IdRota);
        */

    }
}