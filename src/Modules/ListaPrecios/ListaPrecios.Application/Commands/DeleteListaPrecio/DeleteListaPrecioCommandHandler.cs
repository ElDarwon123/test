using LiteBus.Commands.Abstractions;
using ListaPrecios.Application.Contracts;

namespace ListaPrecios.Application.Commands.DeleteListaPrecio;

public class DeleteListaPrecioCommandHandler : ICommandHandler<DeleteListaPrecioCommand>
{
    private readonly IListaPrecioRepository _listaPrecioRepository;

    public DeleteListaPrecioCommandHandler(IListaPrecioRepository listaPrecioRepository)
    {
        _listaPrecioRepository = listaPrecioRepository;
    }

    public async Task HandleAsync(DeleteListaPrecioCommand command, CancellationToken cancellationToken = default)
    {
        await _listaPrecioRepository.SoftDeleteAsync(command.Id, cancellationToken);
    }
}
