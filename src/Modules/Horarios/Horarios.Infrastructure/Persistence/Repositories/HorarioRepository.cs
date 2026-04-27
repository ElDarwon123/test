using Abstractions.Repositories;
using Horarios.Application.Contracts;
using Horarios.Domain.Entities;
using Movies.Infrastructure.Persistence;

namespace Horarios.Infrastructure.Persistence.Repositories;

public class HorarioRepository : GenericRepository<Horario, MoviesDbContext>, IHorarioRepository
{
    public HorarioRepository(MoviesDbContext dbContext) : base(dbContext)
    {
    }
}
