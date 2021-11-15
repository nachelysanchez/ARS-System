using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ARS_System.Entidades
{
    public class Ciudades
    {
        [Key]
        public int CiudadId { get; set; }
        public string NombreCiudad { get; set; }
        public string Provincia { get; set; }
    }
}
