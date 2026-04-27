namespace Movies.Application.DTOs;

public record PeliculaDto(int IdPelicula, string Titulo, string Genero, int DuracionMin, string Clasificacion, DateOnly? FechaEstreno, string Estado, bool Active);