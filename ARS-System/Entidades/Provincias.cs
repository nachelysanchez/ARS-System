using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARS_System.Entidades
{
    public class Provincias
    {
        [Key]
        public int ProvinciaId { get; set; }
        public string Nombres { get; set; }
    }
}
