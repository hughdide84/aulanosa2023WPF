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

        // Boton de añadir usuario
        private void btnAñadir_Click(object sender, RoutedEventArgs e)
        {
            // Verificar si se introdujo un nombre de curso
            if (tbxAñadirNombre.Text.Length == 0)
            {
                lblErrorNombre.Content = "Nombre de curso vacio";
            }
            else
            {
                lblErrorNombre.Content = "";
            }
            // Verificar si se introdujo una fecha de inicio
            if (dtpAñadirInicio.SelectedDate == null)
            {
                lblErrorFechaInicio.Content = "Fecha de inicio vacio";
            }
            else
            {
                lblErrorFechaInicio.Content = "";
            }
            // Verificar si se introdujo una fecha de fin y que esta sea despues de la fecha de inicio
            if (dtpAñadirFin.SelectedDate == null)
            {
                lblErrorFechaFin.Content = "Fecha de fin vacio";
            }else if (dtpAñadirFin.SelectedDate.Value.Date < dtpAñadirInicio.SelectedDate.Value.Date || dtpAñadirFin.SelectedDate.Value.Date == dtpAñadirInicio.SelectedDate.Value.Date)
            {
                lblErrorFechaFin.Content = "La fecha de fin no puede ser anterior a la fecha de inicio";
            }
            else
            {
                lblErrorFechaFin.Content = "";
            }
            // Si se introdujo todo correctamente
            if (tbxAñadirNombre.Text.Length > 0 && dtpAñadirInicio.SelectedDate != null && dtpAñadirFin.SelectedDate != null && (dtpAñadirFin.SelectedDate.Value.Date > dtpAñadirInicio.SelectedDate.Value.Date))
            {
                // Crear objeto
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
                // Crear curso
                CursosApi.crearCurso(cursoInsertar);
                // Cerrar ventana
                Close();
            }
        }

        // Accion al cerrar la ventana
        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            // Cerrar ventana
            Close();
        }
    }
}
