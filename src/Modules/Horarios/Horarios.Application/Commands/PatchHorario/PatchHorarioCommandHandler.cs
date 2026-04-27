using LiteBus.Commands.Abstractions;
using Horarios.Application.Contracts;

namespace Horarios.Application.Commands.PatchHorario;

public class PatchHorarioCommandHandler : ICommandHandler<PatchHorarioCommand>
{
    private readonly IHorarioRepository _horarioRepository;

    public PatchHorarioCommandHandler(IHorarioRepository horarioRepository)
    {
        _horarioRepository = horarioRepository;
    }

    public async Task HandleAsync(PatchHorarioCommand command, CancellationToken cancellationToken = default)
    {
        var horario = await _horarioRepository.GetByIdAsync(command.IdHorario, cancellationToken);
        if (horario == null || !horario.Active)
            return;

        if (command.IdPelicula.HasValue) horario.IdPelicula = command.IdPelicula.Value;
        if (command.IdSala.HasValue) horario.IdSala = command.IdSala.Value;
        if (command.Fecha.HasValue) horario.Fecha = command.Fecha.Value;
        if (command.Hora != null) horario.Hora = command.Hora;
        if (command.Idioma != null) horario.Idioma = command.Idioma;
        if (command.Estado != null) horario.Estado = command.Estado;

        await _horarioRepository.UpdateAsync(horario, cancellationToken);
    }
}
