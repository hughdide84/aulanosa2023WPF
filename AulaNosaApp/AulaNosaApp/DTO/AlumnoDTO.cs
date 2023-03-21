using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaNosaApp.DTO
{
    public class AlumnoDTO
    {
        public int id { get; set; }
        public int idCurso { get; set; }
        public int idEstudios { get; set; }
        public string nombre { get; set; }
        public string cv { get; set; }
        public string carta { get; set; }
        public int idEmpresa { get; set; }
        public DateTime inicioPr { get; set; }
        public DateTime finPr { get; set; }
        public string usuario { get; set; }
    }


}
