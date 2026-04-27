using ListaPrecios.Application.Contracts;
using ListaPrecios.Domain.Entities;

namespace ListaPrecios.Application.Commands.CreateListaPrecio;

public class CreateListaPrecioCommandHandler : ICommandHandler<CreateListaPrecioCommand>
{
    private readonly IListaPrecioRepository _listaPrecioRepository;

    public CreateListaPrecioCommandHandler(IListaPrecioRepository listaPrecioRepository)
    {
        _listaPrecioRepository = listaPrecioRepository;
    }

    public async Task HandleAsync(CreateListaPrecioCommand command, CancellationToken cancellationToken = default)
    {
        var listaPrecio = new ListaPrecio
        {
            IdPelicula = command.IdPelicula,
            TipoEntrada = command.TipoEntrada,
            Precio = command.Precio,
            FechaInicio = command.FechaInicio,
            FechaFin = command.FechaFin
        };

        await _listaPrecioRepository.AddAsync(listaPrecio, cancellationToken);
    }
}
