using Asientos.Application.Contracts;
using Asientos.Domain.Entities;

namespace Asientos.Application.Commands.CreateAsiento;

public class CreateAsientoCommandHandler : ICommandHandler<CreateAsientoCommand>
{
    private readonly IAsientoRepository _asientoRepository;

    public CreateAsientoCommandHandler(IAsientoRepository asientoRepository)
    {
        _asientoRepository = asientoRepository;
    }

    public async Task HandleAsync(CreateAsientoCommand command, CancellationToken cancellationToken = default)
    {
        var asiento = new Asiento
        {
            IdSala = command.IdSala,
            Fila = command.Fila,
            Numero = command.Numero,
            TipoAsiento = command.TipoAsiento,
            Estado = command.Estado
        };

        await _asientoRepository.AddAsync(asiento, cancellationToken);
    }
}
