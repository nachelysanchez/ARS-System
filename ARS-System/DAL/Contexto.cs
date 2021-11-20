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
        public DbSet<Ocupaciones> Ocupaciones { get; set; }
        public DbSet<Permisos> Permisos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = DATA/ARS-System.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Especialidades>().HasData(new Especialidades
            {
                EspecialidadId = 1,
                NombreEspecialidad = "Pediatría"
            });

            //Provincias
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

            //Ocupaciones
            modelBuilder.Entity<Ocupaciones>().HasData(new Ocupaciones{
                OcupacionesId = 1,
                Nombre = "Plomero"
            });
            modelBuilder.Entity<Ocupaciones>().HasData(new Ocupaciones
            {
                OcupacionesId = 2,
                Nombre = "Electricista"
            });
            modelBuilder.Entity<Ocupaciones>().HasData(new Ocupaciones
            {
                OcupacionesId = 3,
                Nombre = "Abogado"
            });
            modelBuilder.Entity<Ocupaciones>().HasData(new Ocupaciones
            {
                OcupacionesId = 4,
                Nombre = "Ingeniero"
            });
            modelBuilder.Entity<Ocupaciones>().HasData(new Ocupaciones
            {
                OcupacionesId = 5,
                Nombre = "Chofer"
            });
        }
    }
}
