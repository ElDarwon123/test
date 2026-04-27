namespace Horarios.Application.DTOs;

public record HorarioDto(int IdHorario, int IdPelicula, int IdSala, DateOnly Fecha, string Hora, string Idioma, string Estado, bool Active);
