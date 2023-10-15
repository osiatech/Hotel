
using Hotel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Hotel.Infraestructure.Context
{
    public class HotelContext : DbContext
    {
        public HotelContext(DbContextOptions<HotelContext> options): base (options)
        {
        }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Recepcion> RECEPCION { get; set; }
    }
}
