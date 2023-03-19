using AulaNosaApp.DTO;
using AulaNosaApp.Util;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace AulaNosaApp.Servicios
{
    public class EstudioApi
    {
        public static List<EstudioDTO> ListarEstudios()
        {
            var cliente = new RestClient(Constantes.client);
            //cliente.AddDefaultHeader("Authorization", string.Format("Bearer {0}", App.Current.Properties["token"]));
            var request = new RestRequest("api/estudios/all", Method.Get);
            var response = cliente.Execute<List<EstudioDTO>>(request);
            var apiResponse = response.Data;
            return apiResponse;
        }

        public static void AltaEstudio(EstudioDTO estudio)
        {
            var client = new RestClient(Constantes.client);
           // client.AddDefaultHeader("Authorization", string.Format("Bearer {0}", App.Current.Properties["token"]));
            var request = new RestRequest("api/estudios", Method.Post);
            request.RequestFormat = RestSharp.DataFormat.Json;
            request.AddBody(JsonSerializer.Serialize(estudio));
            var response = client.Execute(request);
            MessageBox.Show("Estudio creado", "Exito", MessageBoxButton.OK);
        }

        public static void EditarEstudio(EstudioDTO estudio)
        {

            string resultado = "Se ha producido un error no controlado";
            var cliente = new RestClient(Constantes.client);
            //cliente.AddDefaultHeader("Authorization", string.Format("Bearer {0}", App.Current.Properties["token"]));
            var request = new RestRequest("api/estudios/update", Method.Put);
            request.RequestFormat = RestSharp.DataFormat.Json;
            request.AddBody(JsonSerializer.Serialize(estudio));
            var response = cliente.Execute(request);
            MessageBox.Show("Estudio modificado", "Exito", MessageBoxButton.OK);
        }

        public static void EliminarEstudio(int id)
        {
            var cliente = new RestClient(Constantes.client);
            //cliente.AddDefaultHeader("Authorization", string.Format("Bearer {0}", App.Current.Properties["token"]));
            var request = new RestRequest("api/estudios/delete/" + id.ToString(), Method.Delete);
            var response = cliente.Execute(request);
        }

        public static EstudioDTO filtrarEstudioId(String filtro)
        {
            var client = new RestClient(Constantes.client);
            var request = new RestRequest("/api/estudios/" + filtro, Method.Get);
            var response = client.Execute<EstudioDTO>(request);
            var apiResponse = response.Data;
            return apiResponse;
        }
    }
}
