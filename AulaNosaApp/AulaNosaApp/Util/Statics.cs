using AulaNosaApp.DTO;
using AulaNosaApp.DTO.AdministracionCursos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaNosaApp.Util
{
    // Clases estaticas para utilizarlas entre pagina/ventana
    class Statics
    {
        // Usuario
        public static UsuarioDTO usuarioSeleccionado = null; // Obtener el usuario que se ha seleccionado
        // Estudio
        public static EstudioDTO estudioSeleccionado = null; // Obtener el estudio que se ha seleccionado
        // Curso
        public static CursoDTO cursoSeleccionado = null; // Obtener el curso que se ha seleccionado
        // Empresa
        public static EmpresaDTO empresaSeleccionada = null; // Obtener la empresa que se ha seleccionado
    }
}
