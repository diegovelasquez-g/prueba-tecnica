using Microsoft.EntityFrameworkCore;

namespace PruebaTecnica.Models
{
    public class EquiposDbContext : DbContext
    {
        public EquiposDbContext(DbContextOptions<EquiposDbContext> options) : base(options)
        {
        }

        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Equipo> Equipos { get; set; }
    }
}
