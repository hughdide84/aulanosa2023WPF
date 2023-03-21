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
    }
}
