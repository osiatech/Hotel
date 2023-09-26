
using Hotel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Hotel.Infraestructure.Context
{
    public partial class HotelContext : DbContext
    {
        public HotelContext(DbContextOptions<HotelContext> options): base (options)
        {
        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Recepcion> Recepciones { get; set; }
    }
}
