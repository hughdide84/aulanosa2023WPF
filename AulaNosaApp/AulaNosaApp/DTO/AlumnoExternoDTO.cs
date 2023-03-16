using AulaNosaApp.Servicios;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AulaNosaApp.DTO
{
    internal class AlumnoExternoDTO
    {

        // Propiedades que corresponden a las columnas de la tabla AlumnosExternos en la base de datos
        public int id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Universidad { get; set; }
        public string Titulacion { get; set; }
        public string Especialidad { get; set; }
        public string IdCurso { get; set; }

        // Constructor que toma todos los valores
        public AlumnoExternoDTO(int Id, string nombre, string email, string telefono, string universidad, string titulacion, string especialidad, string idcurso)
        {
            id = Id;
            Nombre = nombre;
            Email = email;
            Telefono = telefono;
            Universidad = universidad;
            Titulacion = titulacion;
            Especialidad = especialidad;
            IdCurso = idcurso;
        }
        // Constructor por defecto
        public AlumnoExternoDTO()
        {
        }

    }
}
