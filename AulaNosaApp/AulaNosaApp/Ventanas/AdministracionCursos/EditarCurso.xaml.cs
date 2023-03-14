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

namespace AulaNosaApp
{
    /// <summary>
    /// Lógica de interacción para EditarCurso.xaml
    /// </summary>
    public partial class EditarCurso : Window
    {
        public EditarCurso()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (tbxEditarNombre.Text == "" || dtpEditarInicio.Text == "" || dtpEditarFin.Text == "" || cmbEditarEstado.SelectedIndex == 0) {
                MessageBox.Show("Alguno de los campos está vacío", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                //Modificar la lista de cursos con los nuevos datos
            }
        }
    }
}
