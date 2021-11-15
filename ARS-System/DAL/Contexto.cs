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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = DATA/ARS-System.db");
        }
    }
}
