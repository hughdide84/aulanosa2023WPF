using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaNosaApp.DTO
{
    public class PagoDTO
    {
        public int id {  get; set; }
        public int idMatricula { get; set; }
        public String recibo { get; set; }
        public float pago { get; set; }
        public Char estado { get; set; }
        public String observaciones { get; set; }
        public int idUsuario { get; set; }
        public DateTime? fecha { get; set; }
    }
}
