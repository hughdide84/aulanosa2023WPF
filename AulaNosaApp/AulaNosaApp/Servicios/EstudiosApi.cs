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
    public class EstudiosApi
    {
        public static List<EstudiosDTO> ListarEstudios() {

            //pendiente de modificar
            List<EstudiosDTO> estudios = new List<EstudiosDTO>();
            var cliente = new RestClient(Constantes.baseApi);
            cliente.AddDefaultHeader("Authorization", string.Format("Bearer {0}", App.Current.Properties["token"]));
            var request = new RestRequest("api/estudios", Method.Get);
            var response = cliente.Execute(request);

            if (response != null) {
                if ((response.StatusCode == System.Net.HttpStatusCode.OK) && (response.Content != null)) {

                    var resultado = JsonSerializer.Deserialize<List<EstudiosDTO>>(response.Content);
                    if (resultado != null)
                    {
                        estudios = resultado;
                    }
                    Console.WriteLine(response.Content);
                }
            }

            return estudios;
        }

        public static string EditarEstudio(EstudiosDTO estudiosDTO)
        {
            //pendiente de modificar
            string resultado = "Se ha producido un error no controlado";
            var cliente = new RestClient(Constantes.baseApi);
            cliente.AddDefaultHeader("Authorization", string.Format("Bearer {0}", App.Current.Properties["token"]));
            var request = new RestRequest("api/estudios", Method.Put);
            request.RequestFormat = RestSharp.DataFormat.Json;
            request.AddBody(JsonSerializer.Serialize(estudiosDTO));
            var response = cliente.Execute(request);

            if ((response != null) && (response.Content != null))
            {
                if ((response.StatusCode == System.Net.HttpStatusCode.OK))
                {
                    resultado = "Estudio editado";
                }
                else
                {

                    ErrorDTO error = JsonSerializer.Deserialize<ErrorDTO>(response.Content);
                    if ((error != null) && (error.mensaje != null))
                    {
                        resultado = "Se ha producido un error";
                    }
                }
            }

            return resultado;
        }

        public static string EliminarEstudio(int id)
        {
            //pendiente de modificar
            string resultado = "Se ha producido un error no controlado";
            var cliente = new RestClient(Constantes.baseApi);
            cliente.AddDefaultHeader("Authorization", string.Format("Bearer {0}", App.Current.Properties["token"]));
            var request = new RestRequest("api/estudios/" + id.ToString(), Method.Delete);
            var response = cliente.Execute(request);

            if ((response != null) && (response.Content != null))
            {
                if ((response.StatusCode == System.Net.HttpStatusCode.OK))
                {
                    resultado = "Estudio eliminado";
                }
                else
                {
                    ErrorDTO error = JsonSerializer.Deserialize<ErrorDTO>(response.Content);
                    if ((error != null) && (error.mensaje != null))
                    {
                        resultado = error.mensaje;
                    }
                }
            }

            return resultado;
        }

    }
}
