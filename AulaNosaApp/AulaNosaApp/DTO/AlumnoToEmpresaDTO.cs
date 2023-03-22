using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaNosaApp.DTO
{
    internal class AlumnoToEmpresaDTO
    {
        public int id { get; set; }
        public int idEmpresa { get; set; }
        public int idAlumno { get; set; }
        public char estado { get; set; }
    }
}
