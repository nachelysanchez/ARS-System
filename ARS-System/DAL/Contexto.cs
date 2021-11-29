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
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Prestadores> Prestadores { get; set; }
        public DbSet<Diagnosticos> Diagnosticos { get; set; }
        public DbSet<Doctores> Doctores { get; set; }
        public DbSet<Sexos> Sexos { get; set; }
        public DbSet<Afiliados> Afiliados { get; set; }
        public DbSet<Servicios> Servicios { get; set; }
        public DbSet<Aseguradoras> Aseguradoras { get; set; }
        public DbSet<Reclamaciones> Reclamaciones { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = DATA/ARS-System.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Roles
            modelBuilder.Entity<Roles>().HasData(new Roles
            {
                RolId = 1,
                Nombre = "Administrador"
            });

            //Usuarios
            modelBuilder.Entity<Usuarios>().HasData(new Usuarios
            {
                UsuarioId = 1,
                Nombres = "Kelvin Peña",
                Username = "KelvinP",
                Contrasena = "d7678f190ca1811f2d340c7aa1bf1822e6acaac89ffd8ea5c2f731efd3e10e4a", //Contrasena: 20180193
                RolId = 1,
                TotalAsignado = 0

            });
            modelBuilder.Entity<Usuarios>().HasData(new Usuarios
            {
                UsuarioId = 2,
                Nombres = "Nachely Sanchez",
                Username = "NachelyS",
                Contrasena = "c25a957fe06e03fbbc5b8f9635c1addd4e1c62a2a7d6d1286faae96e603e9a15", //Contrasena: 20190734
                RolId = 1,
                TotalAsignado = 0

            });
            modelBuilder.Entity<Usuarios>().HasData(new Usuarios
            {
                UsuarioId = 3,
                Nombres = "Vismar Lora",
                Username = "VismarL",
                Contrasena = "613ba1ddd8c16ecb4f619506e8d88e25c94b98d33b4c9a23d67910bcb0161a6d", //Contrasena: 20190425
                RolId = 1,
                TotalAsignado = 0

            });

            //Especialidad
            modelBuilder.Entity<Especialidades>().HasData(new Especialidades
            {
                EspecialidadId = 1,
                Nombres = "Pediatría"
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

            //Prestadores
            modelBuilder.Entity<Prestadores>().HasData(new Prestadores
            {
                PrestadorId = 1,
                Nombres = "Centro Médico Nacional, San Francisco",
                RNC = "A1053736146",
                Direccion = "C/ Salcedo Esq. San Francisco",
                CiudadId = 1,
                Telefono = "809-588-3414"
            });

            //Ciudades
            modelBuilder.Entity<Ciudades>().HasData(new Ciudades
            {
                CiudadId = 1,
                Nombres = "San Francisco de Macoris",
                ProvinciaId = 1
            });

            //Diagnosticos
            modelBuilder.Entity<Diagnosticos>().HasData(new Diagnosticos
            {
                DiagnosticoId = 1,
                Nombres = "Anemia",
                VecesAsignado = 0
            });

            //Doctores
            modelBuilder.Entity<Doctores>().HasData(new Doctores
            {
                DoctorId = 1,
                Nombres = "Frank Felix Ventura",
                Celular = "829-213-9632",
                Telefono = "809-555-6589",
                Direccion = "Calle 27 de Febrero",
                CiudadId = 1,
                Exequatur = "123-45"
            });

            //Sexos
            modelBuilder.Entity<Sexos>().HasData(new Sexos
            {
                SexoId = 1,
                Nombres = "Femenino"
            });
            modelBuilder.Entity<Sexos>().HasData(new Sexos
            {
                SexoId = 2,
                Nombres = "Masculino"
            });

            //Afiliados
            modelBuilder.Entity<Afiliados>().HasData(new Afiliados
            {
                AfiliadoId = 1,
                Nombres = "Juan Perez",
                FechaNacimiento = new DateTime(1995, 05, 02),
                Cedula = "056-9150738-2",
                SexoId = 2,
                NSS = 256963,
                Telefono = "809-999-8596",
                Celular = "809-753-9963",
                Email = "jperez@gmail.com",
                Direccion = "C/ Rivas, #5",
                CiudadId = 1,
                ValorReclamado = 0,
                AseguradoraId = 1,
                OcupacionId = 1
            });


            //Servicios

            modelBuilder.Entity<Servicios>().HasData(new Servicios
            {
                ServicioId = 1,
                Descripcion = "Consulta",
                VecesAsignado = 0
            });
            modelBuilder.Entity<Servicios>().HasData(new Servicios
            {
                ServicioId = 2,
                Descripcion = "Emergencia",
                VecesAsignado = 0
            });

            //Aseguradoras

            modelBuilder.Entity<Aseguradoras>().HasData(new Aseguradoras
            {
                AseguradoraId = 1,
                Nombres = "Humano",
                RNC = "101506254",
                Direccion = "Calle San Francisco",
                CiudadId = 1,
                Telefono = "809-555-9632"
            });
            //Reclamaciones
            modelBuilder.Entity<Reclamaciones>().HasData(new Reclamaciones
            {
                ReclamacionId = 1,
                Fecha = DateTime.Now,
                NoAutorizacion = 52361,
                NAF = 845632,
                DoctorId = 1,
                AfiliadoId = 1,
                PrestadorId = 1,
                Total = 0
            });

            //Permisos
            modelBuilder.Entity<Permisos>().HasData(new Permisos
            {
                PermisoId = 1,
                Nombre = "Viajes",
                CantidadPermisos = 0
            }) ;
        }
    }
}
