using LiteBus.Commands.Abstractions;
using LiteBus.Queries.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Tickets.Application.Commands.CreateTicket;
using Tickets.Application.Commands.DeleteTicket;
using Tickets.Application.Commands.PatchTicket;
using Tickets.Application.Queries.GetAllTickets;
using Tickets.Application.Queries.GetTicketById;

namespace Tickets.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TicketsController : ControllerBase
{
    private readonly ICommandMediator _commandMediator;
    private readonly IQueryMediator _queryMediator;

    public TicketsController(ICommandMediator commandMediator, IQueryMediator queryMediator)
    {
        _commandMediator = commandMediator;
        _queryMediator = queryMediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var tickets = await _queryMediator.QueryAsync(new GetAllTicketsQuery(), cancellationToken: cancellationToken);
        return Ok(tickets);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var ticket = await _queryMediator.QueryAsync(new GetTicketByIdQuery(id), cancellationToken: cancellationToken);
        if (ticket == null) return NotFound();
        return Ok(ticket);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTicketCommand command, CancellationToken cancellationToken)
    {
        await _commandMediator.SendAsync(command, cancellationToken: cancellationToken);
        return Created();
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Patch(int id, [FromBody] PatchTicketCommand command, CancellationToken cancellationToken)
    {
        if (id != command.IdTicket) return BadRequest();
        await _commandMediator.SendAsync(command, cancellationToken: cancellationToken);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        await _commandMediator.SendAsync(new DeleteTicketCommand(id), cancellationToken: cancellationToken);
        return NoContent();
    }
}
