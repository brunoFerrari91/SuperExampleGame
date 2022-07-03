namespace Domain.Entities;

public class Guerrero
{
    public int Id { get; set; }
    //public List<Destreza>? Destrezas { get; set; }
    public Usuario? Usuario { get; set; }
    public int UsuarioId { get; set; }
}

