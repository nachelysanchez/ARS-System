﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARS_System.Entidades
{
    public class Ocupaciones
    {
        [Key]
        public int OcupacionId { get; set; }
        public string Nombre { get; set; }
    }
}
