using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaNosaApp.DTO
{
    public class AlumnoEmpresaDTO
    {
        public int id { get; set; }
        public int idAlumno { get; set; }
        public String nombreAlumno { get; set; }
        public int idEmpresa { get; set; }
        public String nombreEmpresa { get; set; }
        public Char estado { get; set; }
    }
}
