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

        internal static List<AlumnoExternoDTO> ListarAlumnosExternos()
        {
            List<AlumnoExternoDTO> lista = new List<AlumnoExternoDTO>();
            var client = new RestClient("http://localhost:8080");
            client.AddDefaultHeader("Authorization", string.Format("Bearer {0}", App.Current.Properties["token"]));
            var request = new RestRequest("/api/alumnoExterno/", Method.Get);
            var response = client.Execute<List<AlumnoExternoDTO>>(request);

            if (response != null)
            {
                var resultado = JsonSerializer.Deserialize<List<AlumnoExternoDTO>>(response.Content);
                if (resultado != null)
                {
                    lista = resultado;
                }
            }

            return lista;
        }
        public static string EliminarAlumnoExterno(int id)
        {
            string controlEliminar = "Se ha producido un error no controlado";
            var client = new RestClient("http://localhost:8080");
            client.AddDefaultHeader("Authorization", string.Format("Bearer {0}", App.Current.Properties["token"]));
            var request = new RestRequest("/api/alumnoExterno/" + id.ToString(), Method.Delete);
            var response = client.Execute(request);

            if (response != null)
            {
                controlEliminar = "";
            }
            else
            {
                //  Temporal - Falta que WS devuelva un ErrorDTO
                //  ErrorDTO? error = JsonSerializer.Deserialize<ErrorDTO>(response.Content);
                //  if ((error != null) && (error.mensaje != null))
                //  {
                controlEliminar = "Se ha producido un error";
                //  }
            }

            return controlEliminar;
        }
        internal static string EditarAlumnoExterno(AlumnoExternoDTO cursoDTO)
        {
            string controlEditar = "Se ha producido un error no controlado";
            var client = new RestClient("http://localhost:8080");
            client.AddDefaultHeader("Authorization", string.Format("Bearer {0}", App.Current.Properties["token"]));
            var request = new RestRequest("/api/alumnoExterno/", Method.Put);
            request.RequestFormat = RestSharp.DataFormat.Json;
            request.AddBody(JsonSerializer.Serialize(cursoDTO));
            var response = client.Execute(request);

            if (response != null)
            {
                controlEditar = "";
            }
            else
            {
                //  Temporal - Falta que WS devuelva un ErrorDTO
                //  ErrorDTO? error = JsonSerializer.Deserialize<ErrorDTO>(response.Content);
                //  if ((error != null) && (error.mensaje != null))
                //  {
                controlEditar = "Se ha producido un error";
                //  }
            }

            return controlEditar;
        }
        internal static string AgregarAlumnoExterno(AlumnoExternoDTO alumnoextDTO)
        {
            string resultado = "Se ha producido un error no controlado";
            var client = new RestClient("http://localhost:8080");
            //client.AddDefaultHeader("Authorization", string.Format("Bearer {0}", App.Current.Properties["token"]));
            var request = new RestRequest("/api/alumnoExterno/", Method.Post);
            request.RequestFormat = RestSharp.DataFormat.Json;
            request.AddBody(JsonSerializer.Serialize(alumnoextDTO));
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

        internal static AlumnoExternoDTO ListarAlumnoExternoPorId(int id)
        {
            AlumnoExternoDTO objeto = new AlumnoExternoDTO();
            var client = new RestClient("http://localhost:8080");
            client.AddDefaultHeader("Authorization", string.Format("Bearer {0}", App.Current.Properties["token"]));
            var request = new RestRequest("/api/alumnoExterno/" + id.ToString(), Method.Get);
            var response = client.Execute(request);

            if (response != null)
            {
                var resultado = JsonSerializer.Deserialize<AlumnoExternoDTO>(response.Content);
                if (resultado != null)
                {
                    objeto = resultado;
                }
            }

            return objeto;
        }

        internal static AlumnoExternoDTO ListarAlumnoExternoPorNombre(String nombre)
        {
            AlumnoExternoDTO objeto = new AlumnoExternoDTO();
            var client = new RestClient("http://localhost:8080");
            client.AddDefaultHeader("Authorization", string.Format("Bearer {0}", App.Current.Properties["token"]));
            var request = new RestRequest("/cursos/alumnoExterno/" + nombre, Method.Get);
            var response = client.Execute(request);

            if (response != null)
            {
                var resultado = JsonSerializer.Deserialize<AlumnoExternoDTO>(response.Content);
                if (resultado != null)
                {
                    objeto = resultado;
                }
            }

            return objeto;
        }
    }
}
