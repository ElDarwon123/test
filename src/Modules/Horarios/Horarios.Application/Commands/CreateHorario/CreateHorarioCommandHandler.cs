using Horarios.Application.Contracts;
using Horarios.Domain.Entities;

namespace Horarios.Application.Commands.CreateHorario;

public class CreateHorarioCommandHandler : ICommandHandler<CreateHorarioCommand>
{
    private readonly IHorarioRepository _horarioRepository;

    public CreateHorarioCommandHandler(IHorarioRepository horarioRepository)
    {
        _horarioRepository = horarioRepository;
    }

    public async Task HandleAsync(CreateHorarioCommand command, CancellationToken cancellationToken = default)
    {
        var horario = new Horario
        {
            IdPelicula = command.IdPelicula,
            IdSala = command.IdSala,
            Fecha = command.Fecha,
            Hora = command.Hora,
            Idioma = command.Idioma,
            Estado = command.Estado
        };

        await _horarioRepository.AddAsync(horario, cancellationToken);
    }
}
