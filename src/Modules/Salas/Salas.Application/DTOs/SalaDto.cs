namespace Salas.Application.DTOs;

public record SalaDto(int IdSala, string Nombre, int Capacidad, string TipoSala, string? Ubicacion, string Estado, bool Active);
