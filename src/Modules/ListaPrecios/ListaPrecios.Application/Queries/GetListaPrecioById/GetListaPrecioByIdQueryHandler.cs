using LiteBus.Queries.Abstractions;
using ListaPrecios.Application.Contracts;
using ListaPrecios.Application.DTOs;

namespace ListaPrecios.Application.Queries.GetListaPrecioById;

public class GetListaPrecioByIdQueryHandler : IQueryHandler<GetListaPrecioByIdQuery, ListaPrecioDto?>
{
    private readonly IListaPrecioRepository _listaPrecioRepository;

    public GetListaPrecioByIdQueryHandler(IListaPrecioRepository listaPrecioRepository)
    {
        _listaPrecioRepository = listaPrecioRepository;
    }

    public async Task<ListaPrecioDto?> HandleAsync(GetListaPrecioByIdQuery query, CancellationToken cancellationToken = default)
    {
        var lp = await _listaPrecioRepository.GetByIdAsync(query.Id, cancellationToken);
        if (lp == null || !lp.Active)
            return null;
        return new ListaPrecioDto(lp.IdPrecio, lp.IdPelicula, lp.TipoEntrada, lp.Precio, lp.FechaInicio, lp.FechaFin, lp.Active);
    }
}
