using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARS_System.Entidades
{
    public class Doctores
    {
        [Key]
        public int DoctorId { get; set; }
        public string Nombres { get; set; }
        public string Celular { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public int CiudadId { get; set; }
        public string Exequatur { get; set; }

        [ForeignKey("DoctorId")]
        public virtual List<DoctoresDetalle> Detalle { get; set; } = new List<DoctoresDetalle>();

        [ForeignKey("CiudadId")]

        public Ciudades Ciudades { get; set; }
    }
}
