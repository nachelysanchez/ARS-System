using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARS_System.Entidades
{
    public class Afiliados
    {
        [Key]
        public int AfiliadoId { get; set; }
        public string Nombres { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Cedula { get; set; }
        //public char Sexo { get; set; }
        public int NSS { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public int CiudadId { get; set; }
        public float ValorReclamado { get; set; }
        public int AseguradoraId { get; set; }
        public int OcupacionId { get; set; }

        [ForeignKey("CiudadId")]
        public Ciudades Ciudad { get; set; }

        [ForeignKey("OcupacionId")]
        public Ocupaciones Ocupacion { get; set; }
    }
}
