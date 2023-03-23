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
        public DateTime? inicio { get; set; }
        public DateTime? fin { get; set; }
        public string cv { get; set; }
        public string convenio { get; set; }
        public string evaluacion { get; set; }
        public string horario { get; set; }

        internal AlumnoExternoDTO(int id, string tipo, string nombre, string email, string telefono, string universidad, string titulacion, string especialidad, DateTime? inicio, DateTime? fin, string cv, string convenio, string evaluacion, string horario, int idcurso)
        {
            this.id = id;
            this.tipo = tipo;
            this.nombre = nombre;
            this.email = email;
            this.telefono = telefono;
            this.universidad = universidad;
            this.titulacion = titulacion;
            this.especialidad = especialidad;
            this.inicio = inicio;
            this.fin = fin;
            this.cv = cv;
            this.evaluacion = evaluacion;
            this.convenio = convenio;
            this.horario = horario;
            this.idCurso = idcurso;
        }
        // Constructor por defecto
        public AlumnoExternoDTO()
        {
        }
    }

}
