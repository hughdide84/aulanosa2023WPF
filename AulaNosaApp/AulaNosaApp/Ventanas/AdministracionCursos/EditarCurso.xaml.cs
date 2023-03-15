using AulaNosaApp.DTO.AdministracionCursos;
using AulaNosaApp.Servicios.AdministracionCursos;
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
        public EditarCurso(DTO.AdministracionCursos.CursoDTO cursoEditar)
        {
            InitializeComponent();
            tbxEditarNombre.Text = cursoEditar.nombre;
            dtpEditarInicio.Text = cursoEditar.inicio.ToString();
            dtpEditarFin.Text = cursoEditar.fin.ToString();
            cmbEditarEstado.Text = cursoEditar.estado.ToString();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (tbxEditarNombre.Text == "" || dtpEditarInicio.Text == "" || dtpEditarFin.Text == "")
            {
                MessageBox.Show("Alguno de los campos está vacío", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                tbkErrores.Visibility = Visibility.Collapsed;
                CursoDTO cursoDTO = new CursoDTO();
                cursoDTO.nombre = tbxEditarNombre.Text;
                cursoDTO.inicio = DateTime.Parse(dtpEditarInicio.ToString());
                cursoDTO.fin = DateTime.Parse(dtpEditarFin.ToString());

                if (cmbEditarEstado.SelectedIndex == 0)
                {
                    cursoDTO.estado = true;
                }
                else
                {
                    cursoDTO.estado = false;
                }

                string errores = CursosApi.EditarCurso(cursoDTO);

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
