using ListaPrecios.Application.Contracts;
using ListaPrecios.Application.DTOs;

namespace ListaPrecios.Application.Queries.GetAllListaPrecios;

public class GetAllListaPreciosQueryHandler : IQueryHandler<GetAllListaPreciosQuery, List<ListaPrecioDto>>
{
    private readonly IListaPrecioRepository _listaPrecioRepository;

    public GetAllListaPreciosQueryHandler(IListaPrecioRepository listaPrecioRepository)
    {
        _listaPrecioRepository = listaPrecioRepository;
    }

    public async Task<List<ListaPrecioDto>> HandleAsync(GetAllListaPreciosQuery query, CancellationToken cancellationToken = default)
    {
        var listaPrecios = await _listaPrecioRepository.GetAllAsync(cancellationToken);

        return listaPrecios
            .Where(lp => lp.Active)
            .Select(lp => new ListaPrecioDto(lp.IdPrecio, lp.IdPelicula, lp.TipoEntrada, lp.Precio, lp.FechaInicio, lp.FechaFin, lp.Active))
            .ToList();
    }
}
