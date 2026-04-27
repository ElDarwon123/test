namespace Asientos.Domain.Entities;

public class Asiento
{
    public int IdAsiento { get; set; }
    public int IdSala { get; set; }
    public string Fila { get; set; } = string.Empty;
    public int Numero { get; set; }
    public string TipoAsiento { get; set; } = string.Empty;
    public string Estado { get; set; } = "disponible";
    public bool Active { get; set; } = true;
}