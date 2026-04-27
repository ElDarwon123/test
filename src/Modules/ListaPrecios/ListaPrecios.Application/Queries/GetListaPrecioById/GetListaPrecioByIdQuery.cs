using LiteBus.Queries.Abstractions;
using ListaPrecios.Application.DTOs;

namespace ListaPrecios.Application.Queries.GetListaPrecioById;

public record GetListaPrecioByIdQuery(int Id) : IQuery<ListaPrecioDto?>;
