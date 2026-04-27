using LiteBus.Commands.Abstractions;
using ListaPrecios.Application.Contracts;

namespace ListaPrecios.Application.Commands.PatchListaPrecio;

public class PatchListaPrecioCommandHandler : ICommandHandler<PatchListaPrecioCommand>
{
    private readonly IListaPrecioRepository _listaPrecioRepository;

    public PatchListaPrecioCommandHandler(IListaPrecioRepository listaPrecioRepository)
    {
        _listaPrecioRepository = listaPrecioRepository;
    }

    public async Task HandleAsync(PatchListaPrecioCommand command, CancellationToken cancellationToken = default)
    {
        var lp = await _listaPrecioRepository.GetByIdAsync(command.IdPrecio, cancellationToken);
        if (lp == null || !lp.Active)
            return;

        if (command.IdPelicula.HasValue) lp.IdPelicula = command.IdPelicula.Value;
        if (command.TipoEntrada != null) lp.TipoEntrada = command.TipoEntrada;
        if (command.Precio.HasValue) lp.Precio = command.Precio.Value;
        if (command.FechaInicio.HasValue) lp.FechaInicio = command.FechaInicio.Value;
        if (command.FechaFin.HasValue) lp.FechaFin = command.FechaFin.Value;

        await _listaPrecioRepository.UpdateAsync(lp, cancellationToken);
    }
}
