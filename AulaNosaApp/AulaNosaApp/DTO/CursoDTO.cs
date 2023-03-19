using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaNosaApp.DTO.AdministracionCursos
{
    public class CursoDTO
    {
        public int id { get; set; }
        public String nombre { get; set; }
        public DateTime? inicio { get; set; }
        public DateTime? fin { get; set; }
        public char estado { get; set; }
    }
}