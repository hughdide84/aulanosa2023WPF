using AulaNosaApp.DTO;
using AulaNosaApp.Util;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaNosaApp.Servicios
{
    internal class ProyectoEntregaApi
    {

        public static List<ProyectoEntregaDTO> ListarProyectosEntrega()
        {
            var cliente = new RestClient(Constantes.client);
            //cliente.AddDefaultHeader("Authorization", string.Format("Bearer {0}", App.Current.Properties["token"]));
            var request = new RestRequest("api/proyectoEntrega/all", Method.Get);
            var response = cliente.Execute<List<ProyectoEntregaDTO>>(request);
            var apiResponse = response.Data;
            return apiResponse;
        }

    }
}
