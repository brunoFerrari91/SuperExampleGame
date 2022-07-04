namespace Domain.Entities;

public class Guerrero
{
    public int Id { get; set; }
    public Usuario Usuario { get; set; } = null!;
    public int UsuarioId { get; set; }
}

