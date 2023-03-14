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
    public class EstudioApi
    {
        public static string AltaEstudio(EstudioDTO estudio)
        {
            //pendiente de modificar
            string resultado = "Se ha producido un error no controlado";
            var client = new RestClient(Constantes.baseApi);
            client.AddDefaultHeader("Authorization", string.Format("Bearer {0}", App.Current.Properties["token"]));
            var request = new RestRequest("api/productos", Method.Post);
            request.RequestFormat = RestSharp.DataFormat.Json;
            request.AddBody(JsonSerializer.Serialize(estudio));
            var response = client.Execute(request);

            if ((response != null) && (response.Content != null))
            {
                if ((response.StatusCode == System.Net.HttpStatusCode.Created))
                {
                    resultado = "";
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

        public static List<EstudioDTO> ListarEstudios() {

            //pendiente de modificar
            List<EstudioDTO> estudios = new List<EstudioDTO>();
            var cliente = new RestClient(Constantes.baseApi);
            cliente.AddDefaultHeader("Authorization", string.Format("Bearer {0}", App.Current.Properties["token"]));
            var request = new RestRequest("api/estudios", Method.Get);
            var response = cliente.Execute(request);

            if (response != null) {
                if ((response.StatusCode == System.Net.HttpStatusCode.OK) && (response.Content != null)) {

                    var resultado = JsonSerializer.Deserialize<List<EstudioDTO>>(response.Content);
                    if (resultado != null)
                    {
                        estudios = resultado;
                    }
                    Console.WriteLine(response.Content);
                }
            }

            return estudios;
        }

        public static string EditarEstudio(EstudioDTO estudio)
        {
            //pendiente de modificar
            string resultado = "Se ha producido un error no controlado";
            var cliente = new RestClient(Constantes.baseApi);
            cliente.AddDefaultHeader("Authorization", string.Format("Bearer {0}", App.Current.Properties["token"]));
            var request = new RestRequest("api/estudios", Method.Put);
            request.RequestFormat = RestSharp.DataFormat.Json;
            request.AddBody(JsonSerializer.Serialize(estudio));
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
