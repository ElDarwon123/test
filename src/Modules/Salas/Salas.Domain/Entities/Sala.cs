namespace Salas.Domain.Entities;

public class Sala
{
    public int IdSala { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public int Capacidad { get; set; }
    public string TipoSala { get; set; } = string.Empty;
    public string? Ubicacion { get; set; }
    public string Estado { get; set; } = "activa";
    public bool Active { get; set; } = true;
}