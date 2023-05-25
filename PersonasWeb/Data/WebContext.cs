using Microsoft.EntityFrameworkCore;
using CEBodyPlanet.Models;
using System.Reflection.Metadata;

public class WebContext : DbContext
{
    public WebContext(DbContextOptions<WebContext> options) : base(options)
    {
    }

    public DbSet<CEBodyPlanet.Models.Persona> Persona { get; set; } = default!;
    public DbSet<CEBodyPlanet.Models.Ciudad> Ciudad { get; set; } = default!;
    public DbSet<CEBodyPlanet.Models.Proveedor>? Proveedor { get; set; }
    public DbSet<CEBodyPlanet.Models.Marca>? Marca { get; set; }



}