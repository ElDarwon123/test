using LiteBus.Commands.Abstractions;

namespace ListaPrecios.Application.Commands.DeleteListaPrecio;

public record DeleteListaPrecioCommand(int Id) : ICommand;
