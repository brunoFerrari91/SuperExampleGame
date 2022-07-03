using Domain.Entities;

namespace Infrastructure.Persistence;

public class ApplicationDbContextInitialiser
{
    public static void SeedInitialData(ApplicationDbContext context)
    {
        var velocidad = new Destreza { Nombre = "Velocidad" };
        var fuerza = new Destreza { Nombre = "Fuerza" };
        var resistencia = new Destreza { Nombre = "Resistencia" };
        if (!context.Destrezas.Any())
        {
            context.Destrezas.AddRange(velocidad, fuerza, resistencia);
        }

        var bronce = new Nivel { Valor = 0, Nombre = "Bronce" };
        var plata = new Nivel { Valor = 10, Nombre = "Plata" };
        var oro = new Nivel { Valor = 20, Nombre = "Oro" };
        var platino = new Nivel { Valor = 30, Nombre = "Platino" };
        var titanio = new Nivel { Valor = 40, Nombre = "Titanio" };
        if (!context.Niveles.Any())
        {
            context.AddRange(bronce, plata, oro, platino, titanio);
        }

        var usuario = new Usuario { Oro = 1000, Diamantes = 1000 };
        if (!context.Usuarios.Any())
        {
            context.Usuarios.Add(usuario);
        }

        var guerrero = new Guerrero { Usuario = usuario };
        if (!context.Guerreros.Any())
        {
            context.Guerreros.Add(guerrero);
        }

        if (!context.DestrezaGuerreros.Any())
        {
            context.DestrezaGuerreros.AddRange(
                new DestrezaGuerrero { Destreza = velocidad, Nivel = bronce, Grado = 1, Guerrero = guerrero },
                new DestrezaGuerrero { Destreza = fuerza, Nivel = bronce, Grado = 1, Guerrero = guerrero },
                new DestrezaGuerrero { Destreza = resistencia, Nivel = bronce, Grado = 1, Guerrero = guerrero });
        }

        var destrezas = new List<Destreza>
        {
            fuerza,
            resistencia
        };
        if (!context.Items.Any())
        {
            context.Items.Add(
                new Item { Nombre = "Espada", CostoDiamante = 600, CostoOro = 600, Destrezas = destrezas });
        }

        context.SaveChanges();
    }


}
