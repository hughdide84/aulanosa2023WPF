using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaNosaApp.DTO
{
    internal class AlumnoExternoDTO
    {
        public int id { get; set; }
        public int idCurso { get; set; }
        public string tipo { get; set; }
        public string nombre { get; set; }
        public string email { get; set; }
        public string telefono { get; set; }
        public string universidad { get; set; }
        public string titulacion { get; set; }
        public string especialidad { get; set; }
        public string inicio { get; set; }
        public string fin { get; set; }
        public string cv { get; set; }
        public string convenio { get; set; }
        public string evaluacion { get; set; }
        public string horario { get; set; }
    }
}
