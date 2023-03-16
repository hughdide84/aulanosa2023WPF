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
            tbxEditarID.Text = cursoEditar.id.ToString();
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
            tbkErrores.Text = "";
            tbkErrores.Visibility = Visibility.Collapsed;
            if (tbxEditarNombre.Text == "" || dtpEditarInicio.Text == "" || dtpEditarFin.Text == "")
            {
                tbkErrores.Text += "Alguno de los campos está vacío\n";
                tbkErrores.Visibility = Visibility.Visible;
            }
            if (tbxEditarNombre.Text.Length > 50)
            {
                tbkErrores.Text += "El nombre excede el límite de caracteres\n";
                tbkErrores.Visibility = Visibility.Visible;
            }

            if (tbkErrores.Visibility != Visibility.Visible)
            {
                CursoDTO cursoDTO = new CursoDTO();
                cursoDTO.id = int.Parse(tbxEditarID.Text);
                cursoDTO.nombre = tbxEditarNombre.Text;
                cursoDTO.inicio = DateTime.Parse(dtpEditarInicio.ToString());
                cursoDTO.fin = DateTime.Parse(dtpEditarFin.ToString());

                if (cmbEditarEstado.SelectedIndex == 0)
                {
                    cursoDTO.estado = 'a';
                }
                else
                {
                    cursoDTO.estado = 'b';
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
