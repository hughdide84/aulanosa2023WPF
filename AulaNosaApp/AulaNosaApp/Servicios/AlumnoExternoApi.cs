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
    public class AlumnoExternoApi
    {
        public static List<AlumnoExternoDTO> ListarAlumnosExternos()
        {
            var cliente = new RestClient(Constantes.client);
            //cliente.AddDefaultHeader("Authorization", string.Format("Bearer {0}", App.Current.Properties["token"]));
            var request = new RestRequest("api/alumnoExterno/all", Method.Get);
            var response = cliente.Execute<List<AlumnoExternoDTO>>(request);
            var apiResponse = response.Data;
            return apiResponse;
        }
    }
}
