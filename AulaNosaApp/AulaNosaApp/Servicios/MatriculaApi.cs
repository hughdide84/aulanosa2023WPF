using AulaNosaApp.DTO;
using AulaNosaApp.DTO.AdministracionCursos;
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
    public class MatriculaApi
    {
        static RestClient client;
        static RestRequest request;

        // Listar todos las matriculas
        public static List<MatriculaDTO> listarMatriculas()
        {
            client = new RestClient(Constantes.client);
            request = new RestRequest("/api/matricula", Method.Get);
            var response = client.Execute<List<MatriculaDTO>>(request);
            var apiResponse = response.Data;
            return apiResponse;
        }

        // Crear una matricula
        public static void crearMatricula(MatriculaDTO matriculaDTO)
        {
            client = new RestClient(Constantes.client);
            request = new RestRequest("/api/matricula", Method.Post);
            request.AddJsonBody(matriculaDTO);
            client.Execute<MatriculaDTO>(request);
            MessageBox.Show("Matricula creada", "Exito", MessageBoxButton.OK);
        }

        // Editar una matricula
        public static void editarMatricula(MatriculaDTO matriculaDTO)
        {
            client = new RestClient(Constantes.client);
            request = new RestRequest("/api/matricula", Method.Put);
            request.AddJsonBody(matriculaDTO);
            client.Execute<MatriculaDTO>(request);
            MessageBox.Show("Matricula editada", "Exito", MessageBoxButton.OK);
        }
    }
}