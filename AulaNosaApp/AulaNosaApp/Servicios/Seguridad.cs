using AulaNosaApp.Util;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaNosaApp.Servicios
{
    public class Seguridad
    {

        public static bool Acceso(string usuario, string password)
        {
            var client = new RestClient(Constantes.client);
            //client.Authenticator = new HttpBasicAuthenticator(usuario, password);
            var request = new RestRequest("token", Method.Post);
            var response = client.Execute(request);
            Console.WriteLine(response.Content);
            if ((response != null) && (response.StatusCode == System.Net.HttpStatusCode.OK))
            {
                App.Current.Properties["token"] = response.Content;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
