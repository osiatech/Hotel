using Hotel.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Hotel.Infraestructure.Context
{
    public class HotelContext : DbContext
    {
        public HotelContext(DbContextOptions<HotelContext> options) : base(options)
        {
        }

        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Piso> Piso { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>().HasKey(e => e.IdCategoria);
            modelBuilder.Entity<Piso>().HasKey(e => e.IdPiso);
            modelBuilder.Entity<Usuario>().HasKey(e => e.IdUsuario);
        }
    }

}
