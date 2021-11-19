using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARS_System.Entidades;
using Microsoft.EntityFrameworkCore;

namespace ARS_System.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Ciudades> Ciudades { get; set; }
        public DbSet<Especialidades> Especialidades { get; set; }
        public DbSet<Provincias> Provincias { get; set; }
        public DbSet<Roles> Roles { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = DATA/ARS-System.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Provincias>().HasData(new Provincias
            {
                ProvinciaId = 1,
                Nombres = "Duarte"
            });
            modelBuilder.Entity<Provincias>().HasData(new Provincias
            {
                ProvinciaId = 2,
                Nombres = "María Trinidad Sánchez"
            });
            modelBuilder.Entity<Provincias>().HasData(new Provincias
            {
                ProvinciaId = 3,
                Nombres = "Sánchez Ramirez"
            });
            modelBuilder.Entity<Provincias>().HasData(new Provincias
            {
                ProvinciaId = 4,
                Nombres = "Hermanas Mirabal"
            });
            modelBuilder.Entity<Provincias>().HasData(new Provincias
            {
                ProvinciaId = 5,
                Nombres = "La Vega"
            });
            modelBuilder.Entity<Provincias>().HasData(new Provincias
            {
                ProvinciaId = 6,
                Nombres = "Samaná"
            });
        }
    }
}
