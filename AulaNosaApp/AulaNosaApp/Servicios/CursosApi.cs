using AulaNosaApp.DTO.AdministracionCursos;
using AulaNosaApp.Util;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;

namespace AulaNosaApp.Servicios.AdministracionCursos
{
    public class CursosApi
    {
        static RestClient client;
        static RestRequest request;

        // Listar todos los cursos
        public static List<CursoDTO> listarCursos()
        {
            client = new RestClient(Constantes.client);
            request = new RestRequest("/api/curso/all", Method.Get);
            var response = client.Execute<List<CursoDTO>>(request);
            var apiResponse = response.Data;
            return apiResponse;
        }

        // Crear un curso
        public static void crearCurso(CursoDTO curso)
        {
            client = new RestClient(Constantes.client);
            request = new RestRequest("/api/curso", Method.Post);
            request.AddJsonBody(curso);
            client.Execute<CursoDTO>(request);
            MessageBox.Show("Curso creado", "Exito", MessageBoxButton.OK);
        }

        // Editar un curso
        public static void editarCurso(CursoDTO curso)
        {
            client = new RestClient(Constantes.client);
            request = new RestRequest("/api/curso", Method.Put);
            request.AddJsonBody(curso);
            client.Execute<CursoDTO>(request);
            MessageBox.Show("Curso modificado", "Exito", MessageBoxButton.OK);
        }

        // Eliminar un curso
        public static void eliminarCurso(int idCursoSeleccionado)
        {
            client = new RestClient(Constantes.client);
            request = new RestRequest("/api/curso/"+idCursoSeleccionado, Method.Delete);
            var response = client.Execute(request);
        }

        // Buscar curso por ID
        public static CursoDTO filtrarCursoId(String filtro)
        {
            client = new RestClient(Constantes.client);
            request = new RestRequest("/api/curso/" + filtro, Method.Get);
            var response = client.Execute<CursoDTO>(request);
            var apiResponse = response.Data;
            return apiResponse;
        }

        // Listar cursos activos
        public static List<CursoDTO> listarCursosActivos()
        {
            client = new RestClient(Constantes.client);
            request = new RestRequest("/api/curso/cursosActivos", Method.Get);
            var response = client.Execute<List<CursoDTO>>(request);
            var apiResponse = response.Data;
            return apiResponse;
        }

        // Listar cursos finalizados
        public static List<CursoDTO> listarCursosFinalizados()
        {
            client = new RestClient(Constantes.client);
            request = new RestRequest("/api/curso/all", Method.Get);
            var response = client.Execute<List<CursoDTO>>(request);
            var apiResponse = response.Data;
            List<CursoDTO> cursosNoActivos = new List<CursoDTO>();
            for (int i = 0; i<apiResponse.Count; i++)
            {
                if (apiResponse[i].estado == 'B' || apiResponse[i].estado == 'b')
                {
                    cursosNoActivos.Add(apiResponse[i]);
                }
            }
            return cursosNoActivos;
        }
    }
}
