using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARS_System.Entidades
{
    public class ReclamacionesDetalle
    {
        [Key]
        public int Id { get; set; }
        public int ReclamacionId { get; set; }
        public int ServicioId { get; set; }
        public int AfiliadoId { get; set; }
        public float ValorTotal { get; set; }
        public float NoProcede { get; set; }
        public float ValorReclamado { get; set; }
        public float Copago { get; set; }

        [ForeignKey("ServicioId")]
        public Servicios Servicio { get; set; }
        [ForeignKey("AfiliadoId")]
        public Afiliados Afiliado { get; set; }

        public ReclamacionesDetalle()
        {
            Id = 0;
            ReclamacionId = 0;
            ServicioId = 0;
            ValorTotal = 0;
            NoProcede = 0;
            ValorReclamado = 0;
            Copago = 0;
            Servicio = null;
        }

        public ReclamacionesDetalle(int ReclId, int servicioId, int afiliadoId, float valor, 
            float noprocede, float recl, float copago, Servicios servicio, Afiliados a)
        {
            Id = 0;
            ReclamacionId = ReclId;
            ServicioId = servicioId;
            AfiliadoId = afiliadoId;
            ValorTotal = valor;
            NoProcede = noprocede;
            ValorReclamado = recl;
            Copago = copago;
            Servicio = servicio;
            Afiliado = a;
        }
    }
}
