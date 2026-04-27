using Abstractions.Repositories;
using Tickets.Domain.Entities;

namespace Tickets.Application.Contracts;

public interface ITicketRepository : IGenericRepository<Ticket>
{
}
