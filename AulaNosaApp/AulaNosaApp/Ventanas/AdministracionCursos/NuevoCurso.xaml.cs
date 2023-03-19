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
            cbbAñadirEstado.SelectedIndex = 0;
        }

        private void btnAñadir_Click(object sender, RoutedEventArgs e)
        {
            if (tbxAñadirNombre.Text.Length == 0)
            {
                lblErrorNombre.Content = "Nombre de curso vacio";
            }
            else
            {
                lblErrorNombre.Content = "";
            }
            if (dtpAñadirInicio.SelectedDate == null)
            {
                lblErrorFechaInicio.Content = "Fecha de inicio vacio";
            }
            else
            {
                lblErrorFechaInicio.Content = "";
            }
            if (dtpAñadirFin.SelectedDate == null)
            {
                lblErrorFechaFin.Content = "Fecha de fin vacio";
            }else if (dtpAñadirFin.SelectedDate.Value.Date < dtpAñadirInicio.SelectedDate.Value.Date)
            {
                lblErrorFechaFin.Content = "La fecha de fin no puede ser anterior a la fecha de inicio";
            }
            else
            {
                lblErrorFechaFin.Content = "";
            }
            if (tbxAñadirNombre.Text.Length > 0 && dtpAñadirInicio.SelectedDate != null && dtpAñadirFin.SelectedDate != null)
            {
                CursoDTO cursoInsertar = new CursoDTO();
                cursoInsertar.nombre = tbxAñadirNombre.Text.ToString();
                cursoInsertar.inicio = dtpAñadirInicio.SelectedDate;
                cursoInsertar.fin = dtpAñadirFin.SelectedDate;
                if (cbbAñadirEstado.SelectedIndex == 0)
                {
                    cursoInsertar.estado = 'A';
                }
                else
                {
                    cursoInsertar.estado = 'B';
                }
                CursosApi.crearCurso(cursoInsertar);
                Close();
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
