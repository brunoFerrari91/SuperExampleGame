using Application.Items.Commands.ComprarItem;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;


[ApiController]
[Route("[controller]")]
public class ItemController : ApiControllerBase
{
    [HttpPut("{id}")]
    public async Task<ActionResult<GuerreroDTO>> Comprar(int id, ComprarItemCommand command)
    {
        if (id != command.ItemId)
        {
            return BadRequest();
        }
        try
        {
            return Ok(await Mediator.Send(command));
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

}
