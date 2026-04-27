using Horarios.Application.Commands.CreateHorario;
using Horarios.Application.Queries.GetAllHorarios;
using Horarios.Application.Queries.GetHorarioById;
using Horarios.Application.Commands.PatchHorario;
using Horarios.Application.Commands.DeleteHorario;
using LiteBus.Commands.Abstractions;
using LiteBus.Queries.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Horarios.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HorariosController : ControllerBase
{
    private readonly ICommandMediator _commandMediator;
    private readonly IQueryMediator _queryMediator;

    public HorariosController(ICommandMediator commandMediator, IQueryMediator queryMediator)
    {
        _commandMediator = commandMediator;
        _queryMediator = queryMediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var horarios = await _queryMediator.QueryAsync(new GetAllHorariosQuery(), cancellationToken: cancellationToken);
        return Ok(horarios);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var horario = await _queryMediator.QueryAsync(new GetHorarioByIdQuery(id), cancellationToken: cancellationToken);
        if (horario == null) return NotFound();
        return Ok(horario);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateHorarioCommand command, CancellationToken cancellationToken)
    {
        await _commandMediator.SendAsync(command, cancellationToken: cancellationToken);
        return Created();
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Patch(int id, [FromBody] PatchHorarioCommand command, CancellationToken cancellationToken)
    {
        if (id != command.IdHorario) return BadRequest();
        await _commandMediator.SendAsync(command, cancellationToken: cancellationToken);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        await _commandMediator.SendAsync(new DeleteHorarioCommand(id), cancellationToken: cancellationToken);
        return NoContent();
    }
}
