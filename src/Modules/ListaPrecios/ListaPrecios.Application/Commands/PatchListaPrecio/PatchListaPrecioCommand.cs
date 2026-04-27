using LiteBus.Commands.Abstractions;

namespace ListaPrecios.Application.Commands.PatchListaPrecio;

public record PatchListaPrecioCommand(int IdPrecio, int? IdPelicula, string? TipoEntrada, decimal? Precio, DateOnly? FechaInicio, DateOnly? FechaFin) : ICommand;
