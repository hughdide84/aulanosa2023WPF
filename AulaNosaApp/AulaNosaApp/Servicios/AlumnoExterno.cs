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
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Universidad { get; set; }
        public string Titulacion { get; set; }
        public string Especialidad { get; set; }
        public int IdCurso { get; set; }
    }
}
