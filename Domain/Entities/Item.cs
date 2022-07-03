namespace Domain.Entities;

public class Item
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public int CostoOro { get; set; }
    public int CostoDiamante { get; set; }
    public List<Destreza>? Destrezas { get; set; }
}

