using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARS_System.Entidades
{
    public class Reclamaciones
    {
        [Key]
        public int ReclamacionId { get; set; }
        public DateTime Fecha { get; set; }
        public int NoAutorizacion { get; set; }
        public int NAF { get; set; }
        public int DoctorId { get; set; }
        public int AfiliadoId { get; set; }
        public int PrestadorId { get; set; }
        public float Total { get; set; }

        [ForeignKey("ReclamacionId")]
        public virtual List<ReclamacionesDetalle> RDetalle { get; set; } = new List<ReclamacionesDetalle>();
        [ForeignKey("DoctorId")]
        public Doctores Doctor { get; set; }
        [ForeignKey("AfiliadoId")]
        public Afiliados Afiliado { get; set; }
        [ForeignKey("PrestadorId")]
        public Prestadores Prestador { get; set; }
    }
}
