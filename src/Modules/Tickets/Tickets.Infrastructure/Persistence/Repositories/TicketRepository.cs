using Abstractions.Repositories;
using Movies.Infrastructure.Persistence;
using Tickets.Application.Contracts;
using Tickets.Domain.Entities;

namespace Tickets.Infrastructure.Persistence.Repositories;

public class TicketRepository : GenericRepository<Ticket, MoviesDbContext>, ITicketRepository
{
    public TicketRepository(MoviesDbContext dbContext) : base(dbContext)
    {
    }
}
