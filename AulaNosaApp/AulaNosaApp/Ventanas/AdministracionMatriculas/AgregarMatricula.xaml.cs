using System;
using System.Collections.Generic;
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

namespace AulaNosaApp.Ventanas.AdministracionMatriculas
{
    /// <summary>
    /// Lógica de interacción para AgregarMatricula.xaml
    /// </summary>
    public partial class AgregarMatricula : Window
    {
        public AgregarMatricula()
        {
            InitializeComponent();
        }

        // Boton de añadir matricula
        private void btnAñadir_Click(object sender, RoutedEventArgs e)
        {

        }

        // Boton de cancelar crear matricula
        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
