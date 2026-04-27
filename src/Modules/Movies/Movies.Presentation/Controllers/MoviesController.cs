using LiteBus.Commands.Abstractions;
using LiteBus.Queries.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Movies.Application.Commands.CreateMovie;
using Movies.Application.Queries.GetAllMovies;
using Movies.Application.Queries.GetMovieById;
using Movies.Application.Commands.PatchMovie;
using Movies.Application.Commands.DeleteMovie;

namespace Movies.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MoviesController : ControllerBase
{
    private readonly ICommandMediator _commandMediator;
    private readonly IQueryMediator _queryMediator;

    public MoviesController(ICommandMediator commandMediator, IQueryMediator queryMediator)
    {
        _commandMediator = commandMediator;
        _queryMediator = queryMediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var movies = await _queryMediator.QueryAsync(new GetAllMoviesQuery(), cancellationToken: cancellationToken);
        return Ok(movies);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var movie = await _queryMediator.QueryAsync(new GetMovieByIdQuery(id), cancellationToken: cancellationToken);
        if (movie == null) return NotFound();
        return Ok(movie);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateMovieCommand command, CancellationToken cancellationToken)
    {
        await _commandMediator.SendAsync(command, cancellationToken: cancellationToken);
        return Created();
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Patch(int id, [FromBody] PatchMovieCommand command, CancellationToken cancellationToken)
    {
        if (id != command.IdPelicula) return BadRequest();
        await _commandMediator.SendAsync(command, cancellationToken: cancellationToken);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        await _commandMediator.SendAsync(new DeleteMovieCommand(id), cancellationToken: cancellationToken);
        return NoContent();
    }
}
