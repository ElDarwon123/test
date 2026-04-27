namespace Horarios.Domain.Entities;

public class Horario
{
    public int IdHorario { get; set; }
    public int IdPelicula { get; set; }
    public int IdSala { get; set; }
    public DateOnly Fecha { get; set; }
    public string Hora { get; set; } = string.Empty;
    public string Idioma { get; set; } = string.Empty;
    public string Estado { get; set; } = "programado";
    public bool Active { get; set; } = true;
}