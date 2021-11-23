using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARS_System.Entidades
{
    public class Sexos
    {
        [Key]
        public int SexoId { get; set; }
        public string Nombres { get; set; }
    }
}
