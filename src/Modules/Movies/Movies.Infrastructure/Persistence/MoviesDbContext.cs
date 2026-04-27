using Asientos.Domain.Entities;
using Horarios.Domain.Entities;
using ListaPrecios.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Movies.Domain.Entities;
using Reservas.Domain.Entities;
using Salas.Domain.Entities;
using Tickets.Domain.Entities;

namespace Movies.Infrastructure.Persistence;

public class MoviesDbContext : DbContext
{
    public MoviesDbContext(DbContextOptions<MoviesDbContext> options) : base(options) { }

    public DbSet<Pelicula> Peliculas => Set<Pelicula>();
    public DbSet<Sala> Salas => Set<Sala>();
    public DbSet<Asiento> Asientos => Set<Asiento>();
    public DbSet<ListaPrecio> ListaPrecios => Set<ListaPrecio>();
    public DbSet<Horario> Horarios => Set<Horario>();
    public DbSet<Reserva> Reservas => Set<Reserva>();
    public DbSet<Ticket> Tickets => Set<Ticket>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pelicula>(entity =>
        {
            entity.ToTable("peliculas");
            entity.HasKey(e => e.IdPelicula);
            entity.Property(e => e.IdPelicula).HasColumnName("id_pelicula");
            entity.Property(e => e.Titulo).HasColumnName("titulo").IsRequired();
            entity.Property(e => e.Genero).HasColumnName("genero").IsRequired();
            entity.Property(e => e.DuracionMin).HasColumnName("duracion_min").IsRequired();
            entity.Property(e => e.Clasificacion).HasColumnName("clasificacion").IsRequired();
            entity.Property(e => e.FechaEstreno).HasColumnName("fecha_estreno");
            entity.Property(e => e.Estado).HasColumnName("estado").IsRequired().HasDefaultValue("activa");
        });

        modelBuilder.Entity<Sala>(entity =>
        {
            entity.ToTable("salas");
            entity.HasKey(e => e.IdSala);
            entity.Property(e => e.IdSala).HasColumnName("id_sala");
            entity.Property(e => e.Nombre).HasColumnName("nombre").IsRequired();
            entity.Property(e => e.Capacidad).HasColumnName("capacidad").IsRequired();
            entity.Property(e => e.TipoSala).HasColumnName("tipo_sala").IsRequired();
            entity.Property(e => e.Ubicacion).HasColumnName("ubicacion");
            entity.Property(e => e.Estado).HasColumnName("estado").IsRequired().HasDefaultValue("activa");
        });

        modelBuilder.Entity<Asiento>(entity =>
        {
            entity.ToTable("asientos");
            entity.HasKey(e => e.IdAsiento);
            entity.Property(e => e.IdAsiento).HasColumnName("id_asiento");
            entity.Property(e => e.IdSala).HasColumnName("id_sala").IsRequired();
            entity.Property(e => e.Fila).HasColumnName("fila").IsRequired();
            entity.Property(e => e.Numero).HasColumnName("numero").IsRequired();
            entity.Property(e => e.TipoAsiento).HasColumnName("tipo_asiento").IsRequired();
            entity.Property(e => e.Estado).HasColumnName("estado").IsRequired().HasDefaultValue("disponible");
        });

        modelBuilder.Entity<ListaPrecio>(entity =>
        {
            entity.ToTable("lista_precios");
            entity.HasKey(e => e.IdPrecio);
            entity.Property(e => e.IdPrecio).HasColumnName("id_precio");
            entity.Property(e => e.IdPelicula).HasColumnName("id_pelicula").IsRequired();
            entity.Property(e => e.TipoEntrada).HasColumnName("tipo_entrada").IsRequired();
            entity.Property(e => e.Precio).HasColumnName("precio").IsRequired();
            entity.Property(e => e.FechaInicio).HasColumnName("fecha_inicio").IsRequired();
            entity.Property(e => e.FechaFin).HasColumnName("fecha_fin");
        });

        modelBuilder.Entity<Horario>(entity =>
        {
            entity.ToTable("horarios");
            entity.HasKey(e => e.IdHorario);
            entity.Property(e => e.IdHorario).HasColumnName("id_horario");
            entity.Property(e => e.IdPelicula).HasColumnName("id_pelicula").IsRequired();
            entity.Property(e => e.IdSala).HasColumnName("id_sala").IsRequired();
            entity.Property(e => e.Fecha).HasColumnName("fecha").IsRequired();
            entity.Property(e => e.Hora).HasColumnName("hora").IsRequired();
            entity.Property(e => e.Idioma).HasColumnName("idioma").IsRequired();
            entity.Property(e => e.Estado).HasColumnName("estado").IsRequired().HasDefaultValue("programado");
        });

        modelBuilder.Entity<Reserva>(entity =>
        {
            entity.ToTable("reservas");
            entity.HasKey(e => e.IdReserva);
            entity.Property(e => e.IdReserva).HasColumnName("id_reserva");
            entity.Property(e => e.IdHorario).HasColumnName("id_horario").IsRequired();
            entity.Property(e => e.NombreCliente).HasColumnName("nombre_cliente").IsRequired();
            entity.Property(e => e.EmailCliente).HasColumnName("email_cliente");
            entity.Property(e => e.FechaReserva).HasColumnName("fecha_reserva").IsRequired().HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.Total).HasColumnName("total").IsRequired();
            entity.Property(e => e.Estado).HasColumnName("estado").IsRequired().HasDefaultValue("confirmada");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.ToTable("tickets");
            entity.HasKey(e => e.IdTicket);
            entity.Property(e => e.IdTicket).HasColumnName("id_ticket");
            entity.Property(e => e.IdReserva).HasColumnName("id_reserva").IsRequired();
            entity.Property(e => e.IdAsiento).HasColumnName("id_asiento").IsRequired();
            entity.Property(e => e.CodigoTicket).HasColumnName("codigo_ticket").IsRequired();
            entity.Property(e => e.Precio).HasColumnName("precio").IsRequired();
            entity.Property(e => e.FechaEmision).HasColumnName("fecha_emision").IsRequired().HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.Estado).HasColumnName("estado").IsRequired().HasDefaultValue("activo");
        });

        modelBuilder.Entity<Asiento>()
            .HasOne<Sala>()
            .WithMany()
            .HasForeignKey(e => e.IdSala);

        modelBuilder.Entity<ListaPrecio>()
            .HasOne<Pelicula>()
            .WithMany()
            .HasForeignKey(e => e.IdPelicula);

        modelBuilder.Entity<Horario>()
            .HasOne<Pelicula>()
            .WithMany()
            .HasForeignKey(e => e.IdPelicula);

        modelBuilder.Entity<Horario>()
            .HasOne<Sala>()
            .WithMany()
            .HasForeignKey(e => e.IdSala);

        modelBuilder.Entity<Reserva>()
            .HasOne<Horario>()
            .WithMany()
            .HasForeignKey(e => e.IdHorario);

        modelBuilder.Entity<Ticket>()
            .HasOne<Reserva>()
            .WithMany()
            .HasForeignKey(e => e.IdReserva);

        modelBuilder.Entity<Ticket>()
            .HasOne<Asiento>()
            .WithMany()
            .HasForeignKey(e => e.IdAsiento);
    }
}
