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

        //Listar todos los cursos
        public static List<CursoDTO> ListarCursos()
        {
            List<CursoDTO> lista = new List<CursoDTO>();
            var client = new RestClient("http://localhost:8080");
            client.AddDefaultHeader("Authorization", string.Format("Bearer {0}", App.Current.Properties["token"]));
            var request = new RestRequest("/api/curso", Method.Get);
            var response = client.Execute(request);

            if (response != null)
            {
                var resultado = JsonSerializer.Deserialize<List<CursoDTO>>(response.Content);
                if (resultado != null)
                {
                    lista = resultado;
                }
            }

            return lista;
        }

        //Crear un registro
        public static string AgregarCurso(CursoDTO cursoDTO)
        {
            string resultado = "Se ha producido un error no controlado";
            var client = new RestClient("http://localhost:8080");
            client.AddDefaultHeader("Authorization", string.Format("Bearer {0}", App.Current.Properties["token"]));
            var request = new RestRequest("/api/curso", Method.Post);
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

        //Modificar un registro
        public static string EditarCurso(CursoDTO cursoDTO)
        {
            string resultado = "Se ha producido un error no controlado";
            var client = new RestClient("http://localhost:8080");
            client.AddDefaultHeader("Authorization", string.Format("Bearer {0}", App.Current.Properties["token"]));
            var request = new RestRequest("/api/curso", Method.Put);
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

        //Eliminar un registro
        public static string EliminarCurso(int id)
        {
            string resultado = "Se ha producido un error no controlado";
            var client = new RestClient("http://localhost:8080");
            client.AddDefaultHeader("Authorization", string.Format("Bearer {0}", App.Current.Properties["token"]));
            var request = new RestRequest("/api/curso/" + id.ToString(), Method.Delete);
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

        //Buscar curso por ID
        public static CursoDTO ListarCursoPorId(int id)
        {
            CursoDTO objeto = new CursoDTO();
            var client = new RestClient("http://localhost:8080");
            client.AddDefaultHeader("Authorization", string.Format("Bearer {0}", App.Current.Properties["token"]));
            var request = new RestRequest("/api/curso/" + id.ToString(), Method.Get);
            var response = client.Execute(request);

            if (response != null)
            {
                var resultado = JsonSerializer.Deserialize<CursoDTO>(response.Content);
                if (resultado != null)
                {
                    objeto = resultado;
                }
            }

            return objeto;
        }

        //Buscar curso por Nombre
        public static CursoDTO ListarCursoPorNombre(String nombre)
        {
            CursoDTO objeto = new CursoDTO();
            var client = new RestClient("http://localhost:8080");
            client.AddDefaultHeader("Authorization", string.Format("Bearer {0}", App.Current.Properties["token"]));
            var request = new RestRequest("/cursos/nombre/" + nombre, Method.Get);
            var response = client.Execute(request);

            if (response != null)
            {
                var resultado = JsonSerializer.Deserialize<CursoDTO>(response.Content);
                if (resultado != null)
                {
                    objeto = resultado;
                }
            }

            return objeto;
        }

        //Buscar cursos por estado
        public static List<CursoDTO> ListarCursoPorEstado(char estado)
        {
            List<CursoDTO> lista = new List<CursoDTO>();
            var client = new RestClient("http://localhost:8080");
            client.AddDefaultHeader("Authorization", string.Format("Bearer {0}", App.Current.Properties["token"]));
            var request = new RestRequest("/cursos/estado/" + estado, Method.Get);
            var response = client.Execute(request);

            if (response != null)
            {
                var resultado = JsonSerializer.Deserialize<List<CursoDTO>>(response.Content);
                if (resultado != null)
                {
                    lista = resultado;
                }
            }

            return lista;
        }
    }
}
