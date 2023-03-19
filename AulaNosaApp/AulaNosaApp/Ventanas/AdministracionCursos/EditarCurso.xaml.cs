using AulaNosaApp.DTO.AdministracionCursos;
using AulaNosaApp.Servicios.AdministracionCursos;
using AulaNosaApp.Util;
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
            tbxEditarID.Text = Statics.cursoSeleccionado.id.ToString();
            tbxEditarNombre.Text = Statics.cursoSeleccionado.nombre.ToString();
            dtpEditarInicio.SelectedDate = Statics.cursoSeleccionado.inicio;
            dtpEditarFin.SelectedDate = Statics.cursoSeleccionado.fin;
            if (Statics.cursoSeleccionado.estado == 'A') {
                cbbEditarEstado.SelectedIndex = 0;
            }
            {
                cbbEditarEstado.SelectedIndex = 1;
            }
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (tbxEditarNombre.Text.Length == 0)
            {
                lblErrorNombre.Content = "Nombre de curso vacio";
            }
            else
            {
                lblErrorNombre.Content = "";
            }
            if (dtpEditarInicio.SelectedDate == null)
            {
                lblErrorFechaInicio.Content = "Fecha de inicio vacio";
            }
            else
            {
                lblErrorFechaInicio.Content = "";
            }
            if (dtpEditarFin.SelectedDate == null)
            {
                lblErrorFechaFin.Content = "Fecha de fin vacio";
            }
            else if (dtpEditarFin.SelectedDate.Value.Date < dtpEditarInicio.SelectedDate.Value.Date)
            {
                lblErrorFechaFin.Content = "La fecha de fin no puede ser anterior a la fecha de inicio";
            }
            else
            {
                lblErrorFechaFin.Content = "";
            }
            if (tbxEditarNombre.Text.Length > 0 && dtpEditarInicio.SelectedDate != null && dtpEditarFin.SelectedDate != null && (dtpEditarFin.SelectedDate.Value.Date > dtpEditarInicio.SelectedDate.Value.Date))
            {
                CursoDTO cursoInsertar = new CursoDTO();
                cursoInsertar.id = Statics.cursoSeleccionado.id;
                cursoInsertar.nombre = tbxEditarNombre.Text.ToString();
                cursoInsertar.inicio = dtpEditarInicio.SelectedDate;
                cursoInsertar.fin = dtpEditarFin.SelectedDate;
                if (cbbEditarEstado.SelectedIndex == 0)
                {
                    cursoInsertar.estado = 'A';
                }
                else
                {
                    cursoInsertar.estado = 'B';
                }
                CursosApi.editarCurso(cursoInsertar);
                Close();
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
