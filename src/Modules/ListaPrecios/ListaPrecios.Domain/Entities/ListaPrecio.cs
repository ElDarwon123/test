namespace ListaPrecios.Domain.Entities;

public class ListaPrecio
{
    public int IdPrecio { get; set; }
    public int IdPelicula { get; set; }
    public string TipoEntrada { get; set; } = string.Empty;
    public decimal Precio { get; set; }
    public DateOnly FechaInicio { get; set; }
    public DateOnly? FechaFin { get; set; }
    public bool Active { get; set; } = true;
}