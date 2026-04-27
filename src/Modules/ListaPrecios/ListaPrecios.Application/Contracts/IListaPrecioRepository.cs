using Abstractions.Repositories;
using ListaPrecios.Domain.Entities;

namespace ListaPrecios.Application.Contracts;

public interface IListaPrecioRepository : IGenericRepository<ListaPrecio>
{
}
