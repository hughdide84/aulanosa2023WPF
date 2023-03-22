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
    internal class EmpresaAPI
    {
        static RestClient client;
        static RestRequest request;

        // Crear una empresa
        public static void crearEmpresa(EmpresaDTO empresa)
        {
            client = new RestClient(Constantes.client);
            request = new RestRequest("/api/empresa", Method.Post);
            request.AddJsonBody(empresa);
            client.Execute<EmpresaDTO>(request);
            MessageBox.Show("Empresa creada", "Exito", MessageBoxButton.OK);
        }

        // Buscar empresa por ID
        public static EmpresaDTO consultarEmpresaId(int id)
        {
            client = new RestClient(Constantes.client);
            request = new RestRequest("/api/empresa/" + id, Method.Get);
            var response = client.Execute<EmpresaDTO>(request);
            var apiResponse = response.Data;
            return apiResponse;
        }

        // Editar una empresa
        public static void editarEmpresa(EmpresaDTO empresa)
        {
            client = new RestClient(Constantes.client);
            request = new RestRequest("/api/empresa", Method.Put);
            request.AddJsonBody(empresa);
            client.Execute<EmpresaDTO>(request);
            MessageBox.Show("Empresa modificada", "Exito", MessageBoxButton.OK);
        }

        // Eliminar una empresa
        public static void eliminarEmpresa(int id)
        {
            client = new RestClient(Constantes.client);
            request = new RestRequest("/api/empresa/" + id, Method.Delete);
            client.Execute(request);
        }

        // Listar todos las empresas
        public static List<EmpresaDTO> listarEmpresas()
        {
            client = new RestClient(Constantes.client);
            request = new RestRequest("/api/empresa", Method.Get);
            var response = client.Execute<List<EmpresaDTO>>(request);
            var apiResponse = response.Data;
            return apiResponse;
        }

        // Listar todos los alumnos asociados a una empresa
        public static List<AlumnoDTO> listarAlumnosEnEmpresa(int id)
        {
            client = new RestClient(Constantes.client);
            request = new RestRequest("/api/empresa/" + id + "/alumno", Method.Get);
            var response = client.Execute<List<AlumnoDTO>>(request);
            var apiResponse = response.Data;
            return apiResponse;
        }

        // Listar todos los alumnos con el estado activo
        public static List<AlumnoToEmpresaDTO> buscarEmpresaAlumno(int idCurso, int idEstudio)
        {
            client = new RestClient(Constantes.client);
            request = new RestRequest("/api/empresa/alumno/" + idCurso + "/" + idEstudio, Method.Get);
            var response = client.Execute<List<AlumnoToEmpresaDTO>>(request);
            var apiResponse = response.Data;
            return apiResponse;
        }

    }
}
