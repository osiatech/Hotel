using Hotel.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Hotel.Infraestructure.Context
{
    public partial class HotelContext : DbContext
    {
        public HotelContext(DbContextOptions<HotelContext> options) : base(options)
        {
        }

         public DbSet<Categoria> Categoria { get; set; }
        public DbSet <Piso> Piso { get; set; }
        public DbSet <Usuario> Usuario { get; set; }
       
    }
}
