using LiteBus.Commands.Abstractions;
using LiteBus.Queries.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Reservas.Application.Commands.CreateReserva;
using Reservas.Application.Queries.GetAllReservas;
using Reservas.Application.Queries.GetReservaById;
using Reservas.Application.Commands.PatchReserva;
using Reservas.Application.Commands.DeleteReserva;

namespace Reservas.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReservasController : ControllerBase
{
    private readonly ICommandMediator _commandMediator;
    private readonly IQueryMediator _queryMediator;

    public ReservasController(ICommandMediator commandMediator, IQueryMediator queryMediator)
    {
        _commandMediator = commandMediator;
        _queryMediator = queryMediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var reservas = await _queryMediator.QueryAsync(new GetAllReservasQuery(), cancellationToken: cancellationToken);
        return Ok(reservas);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var reserva = await _queryMediator.QueryAsync(new GetReservaByIdQuery(id), cancellationToken: cancellationToken);
        if (reserva == null) return NotFound();
        return Ok(reserva);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateReservaCommand command, CancellationToken cancellationToken)
    {
        await _commandMediator.SendAsync(command, cancellationToken: cancellationToken);
        return Created();
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Patch(int id, [FromBody] PatchReservaCommand command, CancellationToken cancellationToken)
    {
        if (id != command.IdReserva) return BadRequest();
        await _commandMediator.SendAsync(command, cancellationToken: cancellationToken);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        await _commandMediator.SendAsync(new DeleteReservaCommand(id), cancellationToken: cancellationToken);
        return NoContent();
    }
}
