using AulaNosaApp.DTO;
using AulaNosaApp.Util;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AulaNosaApp.Servicios
{
    public class AlumnoApi
    {

        //Metodo Listar Alumnos
        internal static List<AlumnoDTO> ListarAlumnos()
        {
            List<AlumnoDTO> lista = new List<AlumnoDTO>();
            var client = new RestClient("http://localhost:8080");
            client.AddDefaultHeader("Authorization", string.Format("Bearer {0}", App.Current.Properties["token"]));
            var request = new RestRequest("/api/alumno", Method.Get);
            var response = client.Execute<List<AlumnoDTO>>(request);

            if (response != null)
            {
                var resultado = JsonSerializer.Deserialize<List<AlumnoDTO>>(response.Content);
                if (resultado != null)
                {
                    lista = resultado;
                }
            }

            return lista;
        }

        //Metodo Listar Alumnos por Id
        internal static AlumnoDTO ListarAlumnoPorId(int id)
        {
            AlumnoDTO objeto = new AlumnoDTO();
            var client = new RestClient("http://localhost:8080");
            client.AddDefaultHeader("Authorization", string.Format("Bearer {0}", App.Current.Properties["token"]));
            var request = new RestRequest("/api/alumno/" + id.ToString(), Method.Get);
            var response = client.Execute(request);

            if (response != null)
            {
                var resultado = JsonSerializer.Deserialize<AlumnoDTO>(response.Content);
                if (resultado != null)
                {
                    objeto = resultado;
                }
            }

            return objeto;
        }

        //Metodo Eliminar Alumnos
        public static string EliminarAlumno(int id)
        {
            string controlEliminar = "Se ha producido un error no controlado";
            var client = new RestClient("http://localhost:8080");
            client.AddDefaultHeader("Authorization", string.Format("Bearer {0}", App.Current.Properties["token"]));
            var request = new RestRequest("/api/alumno/" + id.ToString(), Method.Delete);
            var response = client.Execute(request);

            if (response != null)
            {
                controlEliminar = "";
            }
            else
            {
                controlEliminar = "Se ha producido un error";
            }

            return controlEliminar;
        }

        //Metodo Agregar Alumnos
        internal static string AgregarAlumno(AlumnoDTO alumnoDTO)
        {
            string resultado = "Se ha producido un error no controlado";
            var client = new RestClient("http://localhost:8080");
            client.AddDefaultHeader("Authorization", string.Format("Bearer {0}", App.Current.Properties["token"]));
            var request = new RestRequest("/api/alumno", Method.Post);
            request.RequestFormat = RestSharp.DataFormat.Json;
            request.AddBody(JsonSerializer.Serialize(alumnoDTO));
            var response = client.Execute(request);

            if (response != null)
            {
                resultado = "";
            }
            else
            {
                resultado = "Se ha producido un error";
            }

            return resultado;
        }

        //Metodo Editar Alumnos
        internal static string EditarAlumno(AlumnoDTO alumnoDTO)
        {
            string controlEditar = "Se ha producido un error no controlado";
            var client = new RestClient("http://localhost:8080");
            client.AddDefaultHeader("Authorization", string.Format("Bearer {0}", App.Current.Properties["token"]));
            var request = new RestRequest("/api/alumno", Method.Put);
            request.RequestFormat = RestSharp.DataFormat.Json;
            request.AddBody(JsonSerializer.Serialize(alumnoDTO));
            var response = client.Execute(request);

            if (response != null)
            {
                controlEditar = "";
            }
            else
            {
                controlEditar = "Se ha producido un error";
            }

            return controlEditar;
        }
    }
}