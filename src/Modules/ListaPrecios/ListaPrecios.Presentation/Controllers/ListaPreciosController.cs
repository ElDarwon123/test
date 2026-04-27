using ListaPrecios.Application.Commands.CreateListaPrecio;
using ListaPrecios.Application.Queries.GetAllListaPrecios;
using ListaPrecios.Application.Queries.GetListaPrecioById;
using ListaPrecios.Application.Commands.PatchListaPrecio;
using ListaPrecios.Application.Commands.DeleteListaPrecio;
using LiteBus.Commands.Abstractions;
using LiteBus.Queries.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace ListaPrecios.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ListaPreciosController : ControllerBase
{
    private readonly ICommandMediator _commandMediator;
    private readonly IQueryMediator _queryMediator;

    public ListaPreciosController(ICommandMediator commandMediator, IQueryMediator queryMediator)
    {
        _commandMediator = commandMediator;
        _queryMediator = queryMediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var precios = await _queryMediator.QueryAsync(new GetAllListaPreciosQuery(), cancellationToken: cancellationToken);
        return Ok(precios);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var precio = await _queryMediator.QueryAsync(new GetListaPrecioByIdQuery(id), cancellationToken: cancellationToken);
        if (precio == null) return NotFound();
        return Ok(precio);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateListaPrecioCommand command, CancellationToken cancellationToken)
    {
        await _commandMediator.SendAsync(command, cancellationToken: cancellationToken);
        return Created();
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Patch(int id, [FromBody] PatchListaPrecioCommand command, CancellationToken cancellationToken)
    {
        if (id != command.IdPrecio) return BadRequest();
        await _commandMediator.SendAsync(command, cancellationToken: cancellationToken);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        await _commandMediator.SendAsync(new DeleteListaPrecioCommand(id), cancellationToken: cancellationToken);
        return NoContent();
    }
}
