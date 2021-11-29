﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARS_System.Entidades
{
    public class Servicios
    {
        [Key]
        public int ServicioId { get; set; }
        public string Descripcion { get; set; }
        public int VecesAsignado { get; set; }
    }
}
