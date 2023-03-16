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
    public class AdmUsuariosAPI
    {
        static RestClient client;
        static RestRequest request;

        // Listar usuarios
        public static List<UsuarioDTO> listarUsuarios()
        {
            client = new RestClient(Constantes.client);
            request = new RestRequest("/api/usuario", Method.Get);
            var response = client.Execute<List<UsuarioDTO>>(request);
            var apiResponse = response.Data;
            return apiResponse;
        }

        // Crear usuarios
        public static void crearUsuario(UsuarioDTO usuario)
        {
            // Almacenar todos los usuarios actuales en una lista
            client = new RestClient(Constantes.client);
            request = new RestRequest("/api/usuario", Method.Get);
            var response = client.Execute<List<UsuarioDTO>>(request);
            var apiResponse = response.Data;
            // Comprobar que el usuario no existe
            bool existeUsuario = false;
            // Comparar si el nombre de usuario que se ha puesto esta en la BBDD
            for (int i = 0; i < apiResponse.Count; i++)
            {
                if (apiResponse[i].nombre.Equals(usuario.nombre))
                {
                    existeUsuario = true;
                }
            }
            // Si esta, no se anade a la BBDD
            if (existeUsuario)
            {
                MessageBox.Show("Error: ya existe usuario", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            // Si no existe, se anade a la BBDD
            else
            {
                // Ir al metodo Post para anadir usuarios
                request = new RestRequest("/api/usuario", Method.Post);
                request.AddJsonBody(usuario);
                client.Execute<UsuarioDTO>(request);
                MessageBox.Show("Usuario creado", "Exito", MessageBoxButton.OK);
                Statics.ultimoIdUsuario += 1;
                Statics.usuariosLista = AdmUsuariosAPI.listarUsuarios();
            }
        }

        // Modificar usuario
        public static void modificarUsuario(UsuarioDTO usuario)
        {
            // Almacenar todos los usuarios actuales en una lista
            client = new RestClient(Constantes.client);
            request = new RestRequest("/api/usuario", Method.Get);
            var response = client.Execute<List<UsuarioDTO>>(request);
            var apiResponse = response.Data;
            // Comparar si el nombre de usuario que se ha puesto esta en la BBDD
            // (si solo hay uno, es el usuario que estas modificando, es decir, toma el Usuario actual antes de modificarlo)
            int contUsuariosIguales = 0;
            for (int i = 0; i < apiResponse.Count; i++)
            {
                if (apiResponse[i].nombre.Equals(usuario.nombre))
                {
                    contUsuariosIguales += 1;
                }
            }
            // Si hay mas de uno que se llamaria igual, mostrara un error
            if (contUsuariosIguales > 1)
            {
                MessageBox.Show("Error: ya existe usuario", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                request = new RestRequest("/api/usuario", Method.Put);
                // Si hay uno o cero, se actualiza
                request.AddJsonBody(usuario);
                client.Execute<UsuarioDTO>(request);
                MessageBox.Show("Usuario modificado", "Exito", MessageBoxButton.OK);
                Statics.usuariosLista = AdmUsuariosAPI.listarUsuarios();
            }
        }

        public static void eliminarUsuario(int idUsuarioEliminar)
        {
            // Eliminar usuario
            request = new RestRequest("/api/usuario/" + idUsuarioEliminar, Method.Delete);
            var response = client.Execute(request);
        }


        // Filtros (primera version no disponibles aun) (aun no terminados)
        public static UsuarioDTO filtrarUsuarioId(String filtro)
        {
            client = new RestClient(Constantes.client);
            request = new RestRequest("/api/usuario/"+filtro, Method.Get);
            var response = client.Execute<UsuarioDTO>(request);
            var apiResponse = response.Data;
            return apiResponse;
        }

        public static List<UsuarioDTO> filtrarUsuarioNombre(String filtro)
        {
            client = new RestClient(Constantes.client);
            request = new RestRequest("/api/usuario/" + filtro, Method.Get);
            var response = client.Execute<List<UsuarioDTO>>(request);
            var apiResponse = response.Data;
            return apiResponse;
        }

        public static List<UsuarioDTO> filtrarUsuarioRol(String filtro)
        {
            client = new RestClient(Constantes.client);
            request = new RestRequest("/api/usuario/" + filtro, Method.Get);
            var response = client.Execute<List<UsuarioDTO>>(request);
            var apiResponse = response.Data;
            return apiResponse;
        }

        public static List<UsuarioDTO> filtrarUsuarioEmail(String filtro)
        {
            client = new RestClient(Constantes.client);
            request = new RestRequest("/api/usuario/" + filtro, Method.Get);
            var response = client.Execute<List<UsuarioDTO>>(request);
            var apiResponse = response.Data;
            return apiResponse;
        }
    }
}
