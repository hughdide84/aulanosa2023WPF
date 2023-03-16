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
    internal class AlumnoApi
    {
        public static List<AlumnoDTO> ListarAlumnos()
        {
            List<AlumnoDTO> alumnos = new List<AlumnoDTO>();
            var cliente = new RestClient(Constantes.client);
            cliente.AddDefaultHeader("Authorization", string.Format("Bearer {0}", App.Current.Properties["token"]));
            var request = new RestRequest("api/alumno", Method.Get);
            var response = cliente.Execute(request);

            if (response != null)
            {
                if ((response.StatusCode == System.Net.HttpStatusCode.OK) && (response.Content != null))
                {

                    var resultado = JsonSerializer.Deserialize<List<AlumnoDTO>>(response.Content);
                    if (resultado != null)
                    {
                        alumnos = resultado;
                    }
                    Console.WriteLine(response.Content);
                }
            }

            return alumnos;
        }
    }
}
