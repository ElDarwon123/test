namespace Asientos.Application.DTOs;

public record AsientoDto(int IdAsiento, int IdSala, string Fila, int Numero, string TipoAsiento, string Estado, bool Active);
