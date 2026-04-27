using ListaPrecios.Application.DTOs;

namespace ListaPrecios.Application.Queries.GetAllListaPrecios;

public record GetAllListaPreciosQuery : IQuery<List<ListaPrecioDto>>;
