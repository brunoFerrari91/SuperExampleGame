namespace Domain.Entities;

public class Destreza
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public List<Item> Items { get; set; } = null!;
}