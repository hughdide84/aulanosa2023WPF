using AulaNosaApp.DTO.AdministracionCursos;
using AulaNosaApp.Util;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaNosaApp.Servicios
{
    public class InfoPFCApi
    {
        static RestClient client;
        static RestRequest request;

        //Recuperar la información de la rúbrica
        public static string mostrarInformacion()
        {
            client = new RestClient(Constantes.client);
            request = new RestRequest("/api/infoPFC", Method.Get);
            var response = client.Execute<string>(request);
            var apiResponse = response.Data;
            return apiResponse;
        }
    }
}
