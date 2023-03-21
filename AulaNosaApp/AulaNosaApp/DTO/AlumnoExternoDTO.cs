using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaNosaApp.DTO
{
    public class AlumnoExternoDTO
    {
        public int id { get; set; }
        public int idCurso { get; set; }
        public Char tipo { get; set; }
        public string nombre { get; set; }
        public string email { get; set; }
        public string telefono { get; set; }
        public string universidad { get; set; }
        public string titulacion { get; set; }
        public string especialidad { get; set; }
        public DateTime inicio { get; set; }
        public DateTime fin { get; set; }
        public Char cv { get; set; }
        public Char convenio { get; set; }
        public Char evaluacion { get; set; }
        public Char horario { get; set; }

    }
}
