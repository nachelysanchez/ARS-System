using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARS_System.Entidades
{
    public class Roles
    {
        [Key]

        public int RolId { get; set; }
        public string Nombre { get; set; }
    }
}
