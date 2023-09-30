using Hotel.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Hotel.Infraestructure.Context
{
    public partial class HotelContext : DbContext
    {
        public HotelContext(DbContextOptions<HotelContext> options) : base(options)
        {
        }

         public DbSet<Categoria> Categorias { get; set; }
        public DbSet <Piso> Pisos { get; set; }
        public DbSet <Usuario> Usuarios { get; set; }
       
    }
}
