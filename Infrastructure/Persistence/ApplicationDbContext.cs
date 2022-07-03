using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(
    DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Destreza> Destrezas => Set<Destreza>();
    public DbSet<DestrezaGuerrero> DestrezaGuerreros => Set<DestrezaGuerrero>();
    public DbSet<Guerrero> Guerreros => Set<Guerrero>();
    public DbSet<Item> Items => Set<Item>();
    public DbSet<Nivel> Niveles => Set<Nivel>();
    public DbSet<Usuario> Usuarios => Set<Usuario>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<DestrezaGuerrero>()
            .HasKey(dg => new { dg.DestrezaId, dg.GuerreroId });

        base.OnModelCreating(builder);
    }
}
