using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARS_System.Entidades
{
    public class Aseguradoras
    {
        [Key]

        public int AseguradoraId { get; set; }

        public string Nombres { get; set; }
        public string RNC { get; set; }
        public string Direccion { get; set; }
        public int CiudadId { get; set; }
        public string Telefono { get; set; }


        [ForeignKey("CiudadId")]

        public Ciudades Ciudades;
    }
}
