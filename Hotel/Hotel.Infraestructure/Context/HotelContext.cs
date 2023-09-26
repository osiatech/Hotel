using Hotel.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Hotel.Infraestructure.Context
{
    public partial class HotelContext : DbContext
    {
        public HotelContext(DbContextOptions<HotelContext> options) : base(options)
        {
        }

         public DbSet<Categoría> Categorias { get; set; }
        public DbSet <Piso> pisos { get; set; }
        public DbSet <Usuario> usuarios { get; set; }
    }
}
