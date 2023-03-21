using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaNosaApp.DTO
{
    public class ProyectoDTO
    {
        public int id { get; set; }
        public int idalumno { get; set; }
        public char documento { get; set; }
        public char presentacion { get; set; }
        public int notadocumento { get; set; }
        public int notapresentacion { get; set; }
        public int notafinal { get; set; }
    }
}
