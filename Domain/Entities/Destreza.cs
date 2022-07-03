namespace Domain.Entities;

public class Destreza
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    //public List<Guerrero>? Guerreros { get; set; }
    public List<Item>? Items { get; set; }
}