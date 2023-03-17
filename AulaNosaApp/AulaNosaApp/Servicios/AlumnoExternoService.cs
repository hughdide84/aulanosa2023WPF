using AulaNosaApp.DTO;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace AulaNosaApp.Servicios
{
    public class AlumnoExternoService
    {
        List<AlumnoExterno> listaAlumnos = new List<AlumnoExterno>();

        private readonly HttpClient _httpClient;

        public AlumnoExternoService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://ejemplo.com/api/") // URL de la API
            };
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // Método que devuelve una lista con todos los alumnos de la base de datos
        /* public List<AlumnoExterno> ObtenerTodosLosAlumnos()
         {
         // Código para obtener la lista de alumnos de la base de datos
         }*/

        // Método que devuelve un alumno por su ID
        /* public AlumnoExterno ObtenerAlumnoPorId(int id)
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
         }*/

        internal async Task<AlumnoExterno> ObtenerAlumnoPorId(int id)
        {
            AlumnoExterno alumnoEncontrado = null;

            try
            {
                // 1. Definir la URL base de la API y la ruta específica para obtener un alumno por su ID.
                string url = "https://ejemplo.com/api/alumnos/" + id;

                // 2. Crear un objeto HttpClient para enviar la solicitud a la API.
                using (HttpClient clienteHttp = new HttpClient())
                {
                    // 3. Agregar el encabezado "Accept" para indicar que se espera recibir una respuesta en formato JSON.
                    clienteHttp.DefaultRequestHeaders.Add("Accept", "application/ejemplo");

                    // 4. Enviar la solicitud GET al servidor y obtener la respuesta.
                    HttpResponseMessage respuesta = await clienteHttp.GetAsync(url);

                    // 5. Leer la respuesta JSON y convertirla a un objeto AlumnoExterno.
                    if (respuesta.IsSuccessStatusCode)
                    {
                        string contenidoRespuesta = await respuesta.Content.ReadAsStringAsync();
                        alumnoEncontrado = JsonConvert.DeserializeObject<AlumnoExterno>(contenidoRespuesta);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener el alumno con ID " + id + ": " + ex.Message);
            }

            // 6. Devolver el objeto AlumnoExterno.
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
        internal async void ModificarAlumno(AlumnoExterno alumnoModificado)
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
            using (var httpClient = new HttpClient())
            {
                var url = "https://tu-api.com/alumnos/" + alumnoModificado.id;
                var json = JsonConvert.SerializeObject(alumnoModificado);
                var content = new StringContent(json, Encoding.UTF8, "application/ejemplo");

                var response = await httpClient.PutAsync(url, content);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Error al modificar el alumno en la base de datos");
                }
            }
        }
        internal static string AgregarAlumnoExterno(AlumnoExternoDTO cursoDTO)
        {
            string resultado = "Se ha producido un error no controlado";
            var client = new RestClient("http://localhost:8080");
            client.AddDefaultHeader("Authorization", string.Format("Bearer {0}", App.Current.Properties["token"]));
            var request = new RestRequest("/api/alumnoExterno/", Method.Post);
            request.RequestFormat = RestSharp.DataFormat.Json;
            request.AddBody(JsonSerializer.Serialize(cursoDTO));
            var response = client.Execute(request);

            if (response != null)
            {
                resultado = "";
            }
            else
            {
                //  Temporal - Falta que WS devuelva un ErrorDTO
                //  ErrorDTO? error = JsonSerializer.Deserialize<ErrorDTO>(response.Content);
                //  if ((error != null) && (error.mensaje != null))
                //  {
                resultado = "Se ha producido un error";
                //  }
            }

            return resultado;
        }
    }
}
