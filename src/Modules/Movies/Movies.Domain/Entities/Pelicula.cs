namespace Movies.Domain.Entities;

public class Pelicula
{
    public int IdPelicula { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Genero { get; set; } = string.Empty;
    public int DuracionMin { get; set; }
    public string Clasificacion { get; set; } = string.Empty;
    public DateOnly? FechaEstreno { get; set; }
    public string Estado { get; set; } = "activa";
    public bool Active { get; set; } = true;
}