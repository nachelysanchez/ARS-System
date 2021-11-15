﻿using System;
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

            public int RolesId { get; set; }
            public string Nombre { get; set; }
            public DateTime Fecha { get; set; } = DateTime.Now;
        
    }
}