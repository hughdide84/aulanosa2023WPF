using AulaNosaApp.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaNosaApp.DTO
{
    internal class AlumnoExternoDTO
    {
        List<AlumnoExterno> listaAlumnos = new List<AlumnoExterno>();

        // Propiedades que corresponden a las columnas de la tabla Alumnos en la base de datos
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

        // Método que modifica los datos de un alumno en la base de datos
        public void ModificarAlumno(int idAlumno, string nombre, string correo, string telefono, string universidad, string titulacion, string especialidad, string curso)
        {
        // Código para modificar el alumno en la base de datos
        }

        // Método que devuelve una lista con todos los alumnos de la base de datos
        public List<AlumnoExterno> ObtenerTodosLosAlumnos()
        {
        // Código para obtener la lista de alumnos de la base de datos
        }

        // Método que devuelve un alumno por su ID
        public AlumnoExterno ObtenerAlumnoPorId(int id)
        {
            AlumnoExterno alumnoEncontrado = null;

            foreach (AlumnoExterno alumno in listaAlumnos)
            {
                if (alumno.id == id)
                {
                    alumnoEncontrado = alumno;
                    break;
                }
            }

            return alumnoEncontrado;
        }

        public int ObtenerIdAlumnoSiguiente(int idActual)
        {
            int idSiguiente = -1;

            // Buscar el índice del alumno actual en la lista de alumnos
            int indiceActual = -1;
            for (int i = 0; i < listaAlumnos.Count; i++)
            {
                if (listaAlumnos[i].id == idActual)
                {
                    indiceActual = i;
                    break;
                }
            }

            // Si el índice del alumno actual se encontró, buscar el índice del siguiente alumno
            if (indiceActual != -1 && indiceActual < listaAlumnos.Count - 1)
            {
                idSiguiente = listaAlumnos[indiceActual + 1].id;
            }

            return idSiguiente;
        }
        public int ObtenerIdAlumnoAnterior(int idActual)
        {
            int idAnterior = -1;

            // Buscar el índice del alumno actual en la lista de alumnos
            int indiceActual = -1;
            for (int i = 0; i < listaAlumnos.Count; i++)
            {
                if (listaAlumnos[i].id == idActual)
                {
                    indiceActual = i;
                    break;
                }
            }

            // Si el índice del alumno actual se encontró, buscar el índice del alumno anterior
            if (indiceActual > 0)
            {
                idAnterior = listaAlumnos[indiceActual - 1].id;
            }

            return idAnterior;
        }
        public void ModificarAlumno(AlumnoExterno alumnoModificado)
        {
            foreach (AlumnoExterno alumno in listaAlumnos)
            {
                if (alumno.id == alumnoModificado.id)
                {
                    // Actualizar los datos del alumno existente con los datos del alumno modificado
                    alumno.Nombre = alumnoModificado.Nombre;
                    alumno.Email = alumnoModificado.Email;
                    alumno.Telefono = alumnoModificado.Telefono;
                    alumno.Universidad = alumnoModificado.Universidad;
                    alumno.Titulacion = alumnoModificado.Titulacion;
                    alumno.Especialidad = alumnoModificado.Especialidad;
                    alumno.IdCurso = alumnoModificado.IdCurso;

                    // Terminar la búsqueda
                    break;
                }
            }
        }
    }
}
