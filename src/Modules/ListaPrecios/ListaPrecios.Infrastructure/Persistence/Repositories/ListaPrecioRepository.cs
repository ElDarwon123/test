using Abstractions.Repositories;
using ListaPrecios.Application.Contracts;
using ListaPrecios.Domain.Entities;
using Movies.Infrastructure.Persistence;

namespace ListaPrecios.Infrastructure.Persistence.Repositories;

public class ListaPrecioRepository : GenericRepository<ListaPrecio, MoviesDbContext>, IListaPrecioRepository
{
    public ListaPrecioRepository(MoviesDbContext dbContext) : base(dbContext)
    {
    }
}
