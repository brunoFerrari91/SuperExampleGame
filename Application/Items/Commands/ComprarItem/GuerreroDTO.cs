namespace Application.Items.Commands.ComprarItem;

public class GuerreroDTO
{
    public int UsuarioId { get; set; }
    public int Oro { get; set; }
    public int Diamantes { get; set; }
    public int GuerreroId { get; set; }
    public List<DestrezaDTO> Destrezas { get; set; } = null!;
}