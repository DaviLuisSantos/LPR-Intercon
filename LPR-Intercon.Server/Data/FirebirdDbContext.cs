using LPR_Intercon.Shared.Models.Firebird;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace LPR_Intercon.Server.Data;

public class FirebirdDbContext(DbContextOptions<FirebirdDbContext> options) : DbContext(options)
{
    public DbSet<Veiculo> Veiculo { get; set; }
    public DbSet<Unidade> Unidade { get; set; }
    public DbSet<Condominio> Condominio { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Veiculo>()
         .HasOne(v => v.UnidadeNavigation)
         .WithMany()
         .HasForeignKey(v => v.Unidade)
         .HasPrincipalKey(u => u.Nome);

        modelBuilder.Entity<Veiculo>()
            .HasOne(v => v.Rota)
            .WithMany()
            .HasForeignKey(v => v.IdRota);

    }
}