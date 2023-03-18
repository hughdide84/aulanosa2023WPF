using AulaNosaApp.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaNosaApp.Util
{
    class Statics
    {
        // Usuario
        public static int ultimoIdUsuario = 0; // Obtener el ultimo ID del ultimo usuario del DataGrid
        public static UsuarioDTO usuarioSeleccionado = null; // Obtener el usuario que se ha seleccionado
        public static List<UsuarioDTO> usuariosLista = null; // Lista de usuarios actuales
        // Estudio
        public static EstudioDTO estudioSeleccionado = null; // Obtener el estudio que se ha seleccionado
    }
}
