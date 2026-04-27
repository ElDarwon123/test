using Asientos.Application.Commands.CreateAsiento;
using Asientos.Application.Queries.GetAllAsientos;
using Asientos.Application.Queries.GetAsientoById;
using Asientos.Application.Commands.PatchAsiento;
using Asientos.Application.Commands.DeleteAsiento;
using LiteBus.Commands.Abstractions;
using LiteBus.Queries.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Asientos.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AsientosController : ControllerBase
{
    private readonly ICommandMediator _commandMediator;
    private readonly IQueryMediator _queryMediator;

    public AsientosController(ICommandMediator commandMediator, IQueryMediator queryMediator)
    {
        _commandMediator = commandMediator;
        _queryMediator = queryMediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var asientos = await _queryMediator.QueryAsync(new GetAllAsientosQuery(), cancellationToken: cancellationToken);
        return Ok(asientos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var asiento = await _queryMediator.QueryAsync(new GetAsientoByIdQuery(id), cancellationToken: cancellationToken);
        if (asiento == null) return NotFound();
        return Ok(asiento);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateAsientoCommand command, CancellationToken cancellationToken)
    {
        await _commandMediator.SendAsync(command, cancellationToken: cancellationToken);
        return Created();
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Patch(int id, [FromBody] PatchAsientoCommand command, CancellationToken cancellationToken)
    {
        if (id != command.IdAsiento) return BadRequest();
        await _commandMediator.SendAsync(command, cancellationToken: cancellationToken);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        await _commandMediator.SendAsync(new DeleteAsientoCommand(id), cancellationToken: cancellationToken);
        return NoContent();
    }
}
