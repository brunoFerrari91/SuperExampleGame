using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces;
public interface IApplicationDbContext
{
    public DbSet<Destreza> Destrezas { get; }
    public DbSet<DestrezaGuerrero> DestrezaGuerreros { get; }
    public DbSet<Guerrero> Guerreros { get; }
    public DbSet<Item> Items { get; }
    public DbSet<Nivel> Niveles { get; }
    public DbSet<Usuario> Usuarios { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
