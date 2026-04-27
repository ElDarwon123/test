using Abstractions.Repositories;
using Movies.Domain.Entities;

namespace Movies.Application.Contracts;

public interface IPeliculaRepository : IGenericRepository<Pelicula>
{
}