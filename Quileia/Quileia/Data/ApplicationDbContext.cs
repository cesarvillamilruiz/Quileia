using Microsoft.EntityFrameworkCore;
using Quileia.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quileia.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options)
            :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TuristaCiudad>().HasKey(x => new { x.TuristaId, x.CiudadId });
        }

        public DbSet <Turista> Turistas { get; set; }
        public DbSet <Ciudad> Ciudades { get; set; }
        public DbSet <TuristaCiudad> TuristaCiudades { get; set; }
    }
}
