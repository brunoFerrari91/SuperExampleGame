namespace Domain.Entities;
public class DestrezaGuerrero
{
    public int DestrezaId { get; set; }
    public Destreza? Destreza { get; set; }
    public int NivelId { get; set; }
    public Nivel? Nivel { get; set; }
    public int Grado { get; set; }
    public int GuerreroId { get; set; }
    public Guerrero? Guerrero { get; set; }
}
