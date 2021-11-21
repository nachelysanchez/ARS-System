﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARS_System.Entidades
{
    public class Usuarios
    {
        [Key]
        public int UsuarioId { get; set; }
        public string Nombres { get; set; }
        public string Username { get; set; }
        public string Contrasena { get; set; }
        public int RolId { get; set; }

        [ForeignKey("RolId")]
        public virtual Roles Roles { get; set; }

        [ForeignKey("UsuarioId")]
        public virtual List<UsuariosDetalle> DetalleUsuario { get; set; } = new List<UsuariosDetalle>();

        public Usuarios(int usuarioId, string nombres, string username, string contrasena)
        {
            UsuarioId = usuarioId;
            Nombres = nombres;
            Username = username;
            Contrasena = contrasena;
            RolId = 0;
        }

    }
}
