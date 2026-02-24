namespace Movies.Application.DTOs;

public record MovieDto(Guid Id, string Title, string Description, int Year, string Genre);
