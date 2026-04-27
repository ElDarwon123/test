namespace ListaPrecios.Application.Commands.CreateListaPrecio;

public record CreateListaPrecioCommand(
    int IdPelicula,
    string TipoEntrada,
    decimal Precio,
    DateOnly FechaInicio,
    DateOnly? FechaFin) : ICommand;
