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

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnAñadir_Click(object sender, RoutedEventArgs e)
        {
            if (tbxAñadirNombre.Text == "" || dtpAñadirInicio.Text == "" || dtpAñadirFin.Text == "")
            {
                MessageBox.Show("Alguno de los campos está vacío", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                tbkErrores.Visibility = Visibility.Collapsed;
                CursoDTO cursoDTO = new CursoDTO();
                cursoDTO.nombre = tbxAñadirNombre.Text;
                cursoDTO.inicio = DateTime.Parse(dtpAñadirInicio.ToString());
                cursoDTO.fin = DateTime.Parse(dtpAñadirFin.ToString());

                if (cmbAñadirEstado.SelectedIndex == 0) 
                {
                    cursoDTO.estado = 'a';
                }
                else
                {
                    cursoDTO.estado = 'b';
                }

                string errores = CursosApi.AgregarCurso(cursoDTO);

                if (!errores.Equals(""))
                {
                    tbkErrores.Text = errores;
                    tbkErrores.Visibility = Visibility.Visible;
                }
                else
                {
                    Close();
                }
            }
        }
    }
}
