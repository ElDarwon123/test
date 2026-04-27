namespace Reservas.Domain.Entities;

public class Reserva
{
    public int IdReserva { get; set; }
    public int IdHorario { get; set; }
    public string NombreCliente { get; set; } = string.Empty;
    public string? EmailCliente { get; set; }
    public DateTime FechaReserva { get; set; }
    public decimal Total { get; set; }
    public string Estado { get; set; } = "confirmada";
    public bool Active { get; set; } = true;
}