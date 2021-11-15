using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARS_System.Entidades
{
    public class Especialidades
    {
        [Key]
        public int EspecialidadId { get; set; }
        public string NombreEspecialidad { get; set; }
    }
}
