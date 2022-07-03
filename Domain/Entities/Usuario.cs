namespace Domain.Entities;

public class Usuario
{
    public int Id { get; set; }
    public int Oro { get; set; }
    public int Diamantes { get; set; }
    public List<Guerrero>? Guerreros { get; set; }
}

