namespace Tickets.Domain.Entities;

public class Ticket
{
    public int IdTicket { get; set; }
    public int IdReserva { get; set; }
    public int IdAsiento { get; set; }
    public string CodigoTicket { get; set; } = string.Empty;
    public decimal Precio { get; set; }
    public DateTime FechaEmision { get; set; }
    public string Estado { get; set; } = "activo";
    public bool Active { get; set; } = true;
}