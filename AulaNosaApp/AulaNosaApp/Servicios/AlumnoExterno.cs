using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaNosaApp.Servicios
{
    internal class AlumnoExterno
    {
        public int id { get; set; }
        public string tipo { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Universidad { get; set; }
        public string Titulacion { get; set; }
        public string Especialidad { get; set; }
        public DateTime inicio { get; set; }
        public DateTime fin {get; set; }
        public string cv { get; set; }
        public string convenio { get; set; }
        public string evaluacion { get; set; }
        public string horario { get; set; }
        public int IdCurso { get; set; }
    }
}
