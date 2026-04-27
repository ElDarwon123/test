namespace ListaPrecios.Application.DTOs;

public record ListaPrecioDto(int IdPrecio, int IdPelicula, string TipoEntrada, decimal Precio, DateOnly FechaInicio, DateOnly? FechaFin, bool Active);
