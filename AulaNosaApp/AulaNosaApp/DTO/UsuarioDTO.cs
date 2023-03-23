using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaNosaApp.Util
{
    public class UsuarioDTO
    {
        public int id { get; set; }
        public String nombre { get; set; }
        public String password { get; set; }
        public String rol { get; set; }
        public String rolNombre { get; set; }
        public String email { get; set; }
    }
}
