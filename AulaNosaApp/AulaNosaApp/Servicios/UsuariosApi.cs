using AulaNosaApp.Util;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AulaNosaApp.Servicios.AdministracionUsuarios
{
    public class UsuariosApi
    {
        static RestClient client;
        static RestRequest request;

        // Listar todos los usuarios
        public static List<UsuarioDTO> listarUsuarios()
        {
            client = new RestClient(Constantes.client);
            request = new RestRequest("/api/usuario", Method.Get);
            var response = client.Execute<List<UsuarioDTO>>(request);
            var apiResponse = response.Data;
            return apiResponse;
        }

        // Crear usuario
        public static void crearUsuario(UsuarioDTO usuario)
        {
            client = new RestClient(Constantes.client);
            request = new RestRequest("/api/usuario", Method.Get);
            var response = client.Execute<List<UsuarioDTO>>(request);
            var apiResponse = response.Data;
            bool existeUsuario = false;
            for (int i = 0; i < apiResponse.Count; i++)
            {
                if (apiResponse[i].nombre.Equals(usuario.nombre))
                {
                    existeUsuario = true;
                }
            }
            if (existeUsuario)
            {
                MessageBox.Show("Error: ya existe usuario", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                request = new RestRequest("/api/usuario", Method.Post);
                request.AddJsonBody(usuario);
                client.Execute<UsuarioDTO>(request);
                MessageBox.Show("Usuario creado", "Exito", MessageBoxButton.OK);
            }
        }

        // Modificar usuario
        public static void modificarUsuario(UsuarioDTO usuario)
        {
            client = new RestClient(Constantes.client);
            request = new RestRequest("/api/usuario", Method.Get);
            var response = client.Execute<List<UsuarioDTO>>(request);
            var apiResponse = response.Data;
            int contUsuariosIguales = 0;
            for (int i = 0; i < apiResponse.Count; i++)
            {
                if (apiResponse[i].nombre.Equals(usuario.nombre))
                {
                    contUsuariosIguales += 1;
                }
            }
            if (contUsuariosIguales > 1)
            {
                MessageBox.Show("Error: ya existe usuario", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                request = new RestRequest("/api/usuario", Method.Put);
                request.AddJsonBody(usuario);
                client.Execute<UsuarioDTO>(request);
                MessageBox.Show("Usuario modificado", "Exito", MessageBoxButton.OK);
            }
        }

        // Eliminar usuario
        public static void eliminarUsuario(int idUsuarioEliminar)
        {
            request = new RestRequest("/api/usuario/" + idUsuarioEliminar, Method.Delete);
            var response = client.Execute(request);
        }

        // Buscar usuario por ID
        public static UsuarioDTO filtrarUsuarioId(String filtro)
        {
            client = new RestClient(Constantes.client);
            request = new RestRequest("/api/usuario/" + filtro, Method.Get);
            var response = client.Execute<UsuarioDTO>(request);
            var apiResponse = response.Data;
            return apiResponse;
        }

        // Filtrar usuarios por nombre
        public static List<UsuarioDTO> filtrarUsuarioNombre(String filtro)
        {
            client = new RestClient(Constantes.client);
            request = new RestRequest("/api/usuario/nombreContiene/" + filtro, Method.Get);
            var response = client.Execute<List<UsuarioDTO>>(request);
            var apiResponse = response.Data;
            return apiResponse;
        }

        // Filtrar usuarios por rol
        public static List<UsuarioDTO> filtrarUsuarioRol(String filtro)
        {
            client = new RestClient(Constantes.client);
            request = new RestRequest("/api/usuario/rolEs/" + filtro, Method.Get);
            var response = client.Execute<List<UsuarioDTO>>(request);
            var apiResponse = response.Data;
            return apiResponse;
        }

        // Filtrar usuarios por email
        public static List<UsuarioDTO> filtrarUsuarioEmail(String filtro)
        {
            client = new RestClient(Constantes.client);
            request = new RestRequest("/api/usuario/emailContiene/" + filtro, Method.Get);
            var response = client.Execute<List<UsuarioDTO>>(request);
            var apiResponse = response.Data;
            return apiResponse;
        }
    }
}
