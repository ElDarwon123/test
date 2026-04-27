using LiteBus.Commands.Abstractions;
using LiteBus.Queries.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Salas.Application.Commands.CreateSala;
using Salas.Application.Queries.GetAllSalas;
using Salas.Application.Queries.GetSalaById;
using Salas.Application.Commands.PatchSala;
using Salas.Application.Commands.DeleteSala;

namespace Salas.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SalasController : ControllerBase
{
    private readonly ICommandMediator _commandMediator;
    private readonly IQueryMediator _queryMediator;

    public SalasController(ICommandMediator commandMediator, IQueryMediator queryMediator)
    {
        _commandMediator = commandMediator;
        _queryMediator = queryMediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var salas = await _queryMediator.QueryAsync(new GetAllSalasQuery(), cancellationToken: cancellationToken);
        return Ok(salas);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var sala = await _queryMediator.QueryAsync(new GetSalaByIdQuery(id), cancellationToken: cancellationToken);
        if (sala == null) return NotFound();
        return Ok(sala);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateSalaCommand command, CancellationToken cancellationToken)
    {
        await _commandMediator.SendAsync(command, cancellationToken: cancellationToken);
        return Created();
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Patch(int id, [FromBody] PatchSalaCommand command, CancellationToken cancellationToken)
    {
        if (id != command.IdSala) return BadRequest();
        await _commandMediator.SendAsync(command, cancellationToken: cancellationToken);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        await _commandMediator.SendAsync(new DeleteSalaCommand(id), cancellationToken: cancellationToken);
        return NoContent();
    }
}
