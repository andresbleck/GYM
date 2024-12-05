
using Microsoft.EntityFrameworkCore;
using GimnasioMVC.Models;
namespace GimnasioMVC.Data
{
    public class GimnasioContext : DbContext
    {
        public GimnasioContext(DbContextOptions<GimnasioContext> options)
            : base(options)
        { }

        public DbSet<Socio> Socios { get; set; }
        public DbSet<Clase> Clases { get; set; }
    }
}
