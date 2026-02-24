using LiteBus.Commands.Abstractions;
using LiteBus.Queries.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Movies.Application.Commands.CreateMovie;
using Movies.Application.Queries.GetAllMovies;

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

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateMovieCommand command, CancellationToken cancellationToken)
    {
        await _commandMediator.SendAsync(command, cancellationToken: cancellationToken);
        return Created();
    }
}
