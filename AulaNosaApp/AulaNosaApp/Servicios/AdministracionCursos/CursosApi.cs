using AulaNosaApp.DTO.AdministracionCursos;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AulaNosaApp.Servicios.AdministracionCursos
{
    public class CursosApi
    {
        public static List<CursoDTO> ListarCursos()
        {
            List<CursoDTO> lista = new List<CursoDTO>();
            var client = new RestClient("http://localhost:8080");
            client.AddDefaultHeader("Authorization", string.Format("Bearer {0}", App.Current.Properties["token"]));
            var request = new RestRequest("/cursos/", Method.Get);
            var response = client.Execute(request);

            if (response != null)
            {
                if ((response.StatusCode == System.Net.HttpStatusCode.OK) && (response.Content != null))
                {
                    var resultado = JsonSerializer.Deserialize<List<CursoDTO>>(response.Content);
                    if (resultado != null)
                    {
                        lista = resultado;
                    }
                    Console.WriteLine(response.Content);
                }
            }

            return lista;
        }

        public static string AgregarCurso(CursoDTO cursoDTO)
        {
            string resultado = "Se ha producido un error no controlado";
            var client = new RestClient("http://localhost:8080");
            client.AddDefaultHeader("Authorization", string.Format("Bearer {0}", App.Current.Properties["token"]));
            var request = new RestRequest("/cursos/", Method.Post);
            request.RequestFormat = RestSharp.DataFormat.Json;
            request.AddBody(JsonSerializer.Serialize(cursoDTO));
            var response = client.Execute(request);

            if (response != null)
            {
                if ((response.StatusCode == System.Net.HttpStatusCode.OK) && (response.Content != null))
                {
                    if (resultado != null)
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
                }
            }

            return resultado;
        }

        public static string EditarCurso(CursoDTO cursoDTO)
        {
            string resultado = "Se ha producido un error no controlado";
            var client = new RestClient("http://localhost:8080");
            client.AddDefaultHeader("Authorization", string.Format("Bearer {0}", App.Current.Properties["token"]));
            var request = new RestRequest("/cursos/", Method.Put);
            request.RequestFormat = RestSharp.DataFormat.Json;
            request.AddBody(JsonSerializer.Serialize(cursoDTO));
            var response = client.Execute(request);

            if ((response != null) && (response.Content != null))
            {
                if ((response.StatusCode == System.Net.HttpStatusCode.OK))
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
            }

            return resultado;
        }

        public static string EliminarCurso(int id)
        {
            string resultado = "Se ha producido un error no controlado";
            var client = new RestClient("http://localhost:8080");
            client.AddDefaultHeader("Authorization", string.Format("Bearer {0}", App.Current.Properties["token"]));
            var request = new RestRequest("/cursos/" + id.ToString(), Method.Delete);
            var response = client.Execute(request);

            if ((response != null) && (response.Content != null))
            {
                if ((response.StatusCode == System.Net.HttpStatusCode.OK))
                {
                    resultado = "";
                }
                else
                {
                    //ErrorDTO? error = JsonSerializer.Deserialize<ErrorDTO>(response.Content);
                    //if ((error != null) && (error.mensaje != null))
                    //{
                    //    resultado = error.mensaje;
                    //}
                }
            }

            return resultado;
        }

        public static CursoDTO ListarCursoPorId(int id)
        {
            CursoDTO objeto = new CursoDTO();
            var client = new RestClient("http://localhost:8080");
            client.AddDefaultHeader("Authorization", string.Format("Bearer {0}", App.Current.Properties["token"]));
            var request = new RestRequest("/cursos/id/" + id.ToString(), Method.Get);
            var response = client.Execute(request);

            if (response != null)
            {
                if ((response.StatusCode == System.Net.HttpStatusCode.OK) && (response.Content != null))
                {
                    var resultado = JsonSerializer.Deserialize<CursoDTO>(response.Content);
                    if (resultado != null)
                    {
                        objeto = resultado;
                    }
                    Console.WriteLine(response.Content);
                }
            }

            return objeto;
        }

        public static CursoDTO ListarCursoPorNombre(String nombre)
        {
            CursoDTO objeto = new CursoDTO();
            var client = new RestClient("http://localhost:8080");
            client.AddDefaultHeader("Authorization", string.Format("Bearer {0}", App.Current.Properties["token"]));
            var request = new RestRequest("/cursos/nombre/" + nombre, Method.Get);
            var response = client.Execute(request);

            if (response != null)
            {
                if ((response.StatusCode == System.Net.HttpStatusCode.OK) && (response.Content != null))
                {
                    var resultado = JsonSerializer.Deserialize<CursoDTO>(response.Content);
                    if (resultado != null)
                    {
                        objeto = resultado;
                    }
                    Console.WriteLine(response.Content);
                }
            }

            return objeto;
        }

        public static List<CursoDTO> ListarCursoPorEstado(String estado)
        {
            List<CursoDTO> lista = new List<CursoDTO>();
            var client = new RestClient("http://localhost:8080");
            client.AddDefaultHeader("Authorization", string.Format("Bearer {0}", App.Current.Properties["token"]));
            var request = new RestRequest("/cursos/estado/" + estado, Method.Get);
            var response = client.Execute(request);

            if (response != null)
            {
                if ((response.StatusCode == System.Net.HttpStatusCode.OK) && (response.Content != null))
                {
                    var resultado = JsonSerializer.Deserialize<List<CursoDTO>>(response.Content);
                    if (resultado != null)
                    {
                        lista = resultado;
                    }
                    Console.WriteLine(response.Content);
                }
            }

            return lista;
        }
    }
}
