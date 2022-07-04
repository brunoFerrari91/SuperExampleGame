using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Items.Commands.ComprarItem;
public class ComprarItemCommand : IRequest<GuerreroDTO>
{
    public int ItemId { get; set; }
    public int GuerreroId { get; set; }
}

public class ComprarItemCommandHandler : IRequestHandler<ComprarItemCommand, GuerreroDTO>
{
    private readonly IApplicationDbContext _context;

    public ComprarItemCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<GuerreroDTO> Handle(ComprarItemCommand request, CancellationToken cancellationToken)
    {
        //Validaciones generales
        var item = await _context.Items.Include(i => i.Destrezas).FirstOrDefaultAsync(i => i.Id == request.ItemId);
        if (item == null)
            throw new KeyNotFoundException();

        var guerrero = await _context.Guerreros.Include(g => g.Usuario)
            .FirstOrDefaultAsync(g => g.Id == request.GuerreroId);
        if (guerrero == null)
            throw new Exception("Guerrero inexistente");

        if (item.CostoOro > guerrero.Usuario.Oro || item.CostoDiamante > guerrero.Usuario.Diamantes)
            throw new Exception("Recursos insuficientes para realizar la compra");

        //Incremento de destrezas
        var destrezasGuerrero = await _context.DestrezaGuerreros.Include(d => d.Destreza)
                        .Include(n => n.Nivel)
                        .Where(g => g.GuerreroId == request.GuerreroId).ToListAsync();

        foreach (var destreza in item.Destrezas)
        {
            var destrezaAMejorar = destrezasGuerrero.FirstOrDefault(d => d.DestrezaId == destreza.Id);
            if (destrezaAMejorar == null)
                throw new Exception("El guerrero no posee la destreza a mejorar");

            if (destrezaAMejorar.Grado == 10)
            {
                if (destrezaAMejorar.NivelId == _context.Niveles.Count())
                    throw new Exception("No se puede realizar la compra ya que el guerrero posee el nivel máximo de una destreza a mejorar");

                destrezaAMejorar.Grado = 1;
                destrezaAMejorar.NivelId++;
            }
            else
            {
                destrezaAMejorar.Grado++;
            }
        }

        //Validacion de valores finales (diferencia menor a 5)
        var destrezasGuerreroCopia = new List<DestrezaGuerrero>(destrezasGuerrero);
        foreach (var destreza in destrezasGuerrero)
        {
            var valor = destreza.Grado + destreza.Nivel.Valor;
            foreach (var d in destrezasGuerreroCopia)
            {
                if (destreza.DestrezaId == d.DestrezaId)
                    continue;
                var valorAComparar = d.Grado + d.Nivel.Valor;
                if (Math.Abs(valor - valorAComparar) >= 5)
                    throw new Exception("No se puede realizar la compra ya que habría una diferencia mayor a 5 grados entre las destrezas");
            }
            destrezasGuerreroCopia.Remove(destreza);
        }

        //Reduccion de recursos del usuario
        guerrero.Usuario.Oro = guerrero.Usuario.Oro - item.CostoOro;
        guerrero.Usuario.Diamantes = guerrero.Usuario.Diamantes - item.CostoDiamante;

        //Guaradado de datos
        await _context.SaveChangesAsync(cancellationToken);

        //Armado de respuesta
        var destrezasDTO = new List<DestrezaDTO>();
        foreach (var destreza in destrezasGuerrero)
        {
            destrezasDTO.Add(new DestrezaDTO
            {
                Nombre = destreza.Destreza.Nombre,
                Nivel = destreza.Nivel.Nombre,
                Grado = destreza.Grado
            });
        }
        var guerreroActualizado = new GuerreroDTO
        {
            UsuarioId = guerrero.Usuario.Id,
            Oro = guerrero.Usuario.Oro,
            Diamantes = guerrero.Usuario.Diamantes,
            GuerreroId = guerrero.Id,
            Destrezas = destrezasDTO
        };

        return guerreroActualizado;
    }
}
