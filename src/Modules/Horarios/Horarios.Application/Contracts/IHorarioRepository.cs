using Abstractions.Repositories;
using Horarios.Domain.Entities;

namespace Horarios.Application.Contracts;

public interface IHorarioRepository : IGenericRepository<Horario>
{
}
