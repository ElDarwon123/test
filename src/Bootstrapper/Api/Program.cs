using Asientos.Infrastructure;
using Horarios.Infrastructure;
using ListaPrecios.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Movies.Infrastructure;
using Movies.Infrastructure.Persistence;
using Reservas.Infrastructure;
using Salas.Infrastructure;
using Tickets.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddApplicationPart(typeof(Movies.Presentation.Controllers.MoviesController).Assembly)
    .AddApplicationPart(typeof(Asientos.Presentation.Controllers.AsientosController).Assembly)
    .AddApplicationPart(typeof(Horarios.Presentation.Controllers.HorariosController).Assembly)
    .AddApplicationPart(typeof(ListaPrecios.Presentation.Controllers.ListaPreciosController).Assembly)
    .AddApplicationPart(typeof(Reservas.Presentation.Controllers.ReservasController).Assembly)
    .AddApplicationPart(typeof(Salas.Presentation.Controllers.SalasController).Assembly)
    .AddApplicationPart(typeof(Tickets.Presentation.Controllers.TicketsController).Assembly);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMoviesModule(builder.Configuration);
builder.Services.AddAsientosModule();
builder.Services.AddHorariosModule();
builder.Services.AddListaPreciosModule();
builder.Services.AddReservasModule();
builder.Services.AddSalasModule();
builder.Services.AddTicketsModule();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<MoviesDbContext>();
    db.Database.EnsureCreated();
    db.Database.ExecuteSqlRaw("PRAGMA foreign_keys = ON;");
}

app.MapControllers();

app.Run();
