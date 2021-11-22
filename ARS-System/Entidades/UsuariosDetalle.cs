using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARS_System.Entidades
{
    public class UsuariosDetalle
    {
        [Key]
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int PermisoId { get; set; }
        public string Observacion { get; set; }

        [ForeignKey("PermisoId")]
        public Permisos Permisos { get; set; }

        public UsuariosDetalle()
        {
            Id = 0;
            UsuarioId = 0;
            PermisoId = 0;
            Observacion = "";
            Permisos = null;
        }
        public UsuariosDetalle(int usuarioid, int permisoid, string observacion, Permisos permisos)
        {
            Id = 0;
            UsuarioId = usuarioid;
            PermisoId = permisoid;
            Observacion = observacion;
            Permisos = permisos;
        }
    }
}
