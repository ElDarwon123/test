using LiteBus.Commands;
using LiteBus.Extensions.Microsoft.DependencyInjection;
using LiteBus.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Movies.Application.Commands.CreateMovie;
using Movies.Application.Contracts;
using Movies.Application.Queries.GetAllMovies;
using Movies.Infrastructure.Persistence;
using Movies.Infrastructure.Persistence.Repositories;

namespace Movies.Infrastructure;

public static class MoviesModule
{
    public static IServiceCollection AddMoviesModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<MoviesDbContext>(options =>
            options.UseSqlite(configuration.GetConnectionString("MoviesDb")));

        services.AddScoped<IMovieRepository, MovieRepository>();

        services.AddLiteBus(liteBus =>
        {
            liteBus.AddCommandModule(module => module.RegisterFromAssembly(typeof(CreateMovieCommandHandler).Assembly));
            liteBus.AddQueryModule(module => module.RegisterFromAssembly(typeof(GetAllMoviesQueryHandler).Assembly));
        });

        return services;
    }
}
