using AulaNosaApp.DTO;
using AulaNosaApp.Util;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AulaNosaApp.Servicios
{
    public class ProyectoApi
    {
        static RestClient client;
        static RestRequest request;

        // Listar todos los proyectos
        public static List<ProyectoDTO> listarProyectos()
        {
            client = new RestClient(Constantes.client);
            request = new RestRequest("/api/proyectos", Method.Get);
            var response = client.Execute<List<ProyectoDTO>>(request);
            var apiResponse = response.Data;
            return apiResponse;
        }

        // Crear proyecto
        public static void crearProyecto(ProyectoDTO proyecto)
        {
            client = new RestClient(Constantes.client);
            request = new RestRequest("/api/proyectos/alta", Method.Post);
            request.AddJsonBody(proyecto);
            client.Execute<ProyectoDTO>(request);
            MessageBox.Show("Proyecto creado", "Exito", MessageBoxButton.OK);
        }

        // Modificar proyecto
        public static void modificarProyecto(ProyectoDTO proyecto)
        {
            client = new RestClient(Constantes.client);
            request = new RestRequest("/api/proyectos", Method.Put);
            request.AddJsonBody(proyecto);
            client.Execute<ProyectoDTO>(request);
            MessageBox.Show("Proyecto modificado", "Exito", MessageBoxButton.OK);
        }

        // Eliminar proyecto
        public static void eliminarProyecto(int idProyecto)
        {
            request = new RestRequest("/api/proyectos/" + idProyecto, Method.Delete);
            var response = client.Execute(request);
        }

        // Buscar proyecto por ID
        public static ProyectoDTO filtrarProyectoId(int idProyecto)
        {
            client = new RestClient(Constantes.client);
            request = new RestRequest("/api/proyectos/" + idProyecto, Method.Get);
            var response = client.Execute<ProyectoDTO>(request);
            var apiResponse = response.Data;
            return apiResponse;
        }
    }
}
