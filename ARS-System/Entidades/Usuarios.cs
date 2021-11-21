using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARS_System.Entidades
{
    public class Usuarios
    {
        public int UsuarioId { get; set; }
        public string Nombres { get; set; }
        public string Username { get; set; }
        public string Contrasena { get; set; }
        public int RolId { get; set; }

        [ForeignKey("RolId")]
        public virtual Roles Roles { get; set; }

    }
}
