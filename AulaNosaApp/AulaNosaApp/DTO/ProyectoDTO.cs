using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace AulaNosaApp.DTO
{
    public class ProyectoDTO
    {
        public int id { get; set; }
        public int idAlumno { get; set; }
        public char documento { get; set; }
        public char presentacion { get; set; }
        public int notaDoc { get; set; }
        public int notaPres { get; set; }
        public int notaFinal { get; set; }
    }
}
