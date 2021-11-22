using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARS_System.Entidades
{
    public class DoctoresDetalle
    {
        [Key]
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int EspecialidadId { get; set; }
        public string Observacion { get; set; }

        [ForeignKey("EspecialidadId")]
        public Especialidades Especialidades { get; set; }

        public DoctoresDetalle()
        {
            Id = 0;
            DoctorId = 0;
            EspecialidadId = 0;
            Observacion = "";
            Especialidades = null;
        }

        public DoctoresDetalle(int doctorid, int especialidadid, string observacion, Especialidades especialidades)
        {
            Id = 0;
            DoctorId = doctorid;
            EspecialidadId = especialidadid;
            Observacion = observacion;
            Especialidades = especialidades;
        }
    }
}
