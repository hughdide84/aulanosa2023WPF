using AulaNosaApp.DTO.AdministracionCursos;
using AulaNosaApp.Servicios.AdministracionCursos;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AulaNosaApp
{
    /// <summary>
    /// Lógica de interacción para NuevoCurso.xaml
    /// </summary>
    public partial class NuevoCurso : Window
    {
        public NuevoCurso()
        {
            InitializeComponent();
            cmbAñadirEstado.SelectedIndex = 0;
        }
    }
}
