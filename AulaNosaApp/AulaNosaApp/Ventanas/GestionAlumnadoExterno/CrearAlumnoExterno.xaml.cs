using AulaNosaApp.DTO;
using AulaNosaApp.DTO.AdministracionCursos;
using AulaNosaApp.Servicios;
using AulaNosaApp.Servicios.AdministracionCursos;
using Microsoft.Win32;
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

namespace AulaNosaApp.Ventanas.GestionAlumnadoExterno
{
    /// <summary>
    /// Lógica de interacción para CrearAlumnoExterno.xaml
    /// </summary>
    public partial class CrearAlumnoExterno : Window
    {
        public CrearAlumnoExterno()
        {
            InitializeComponent();
        }
        AlumnoExternoDTO alumno = new AlumnoExternoDTO();
        private async void Guardar_Click(object sender, RoutedEventArgs e)
        {
            int Curso;
            if (!int.TryParse(tbxCurso.Text, out Curso))
            {
                MessageBox.Show("El valor introducido en el campo 'Curso' no es válido. Introduzca un número entero.");
                return;
            }
            alumno.nombre = tbxNombre.Text;
            alumno.tipo = tbxTipo.Text;
            alumno.email = tbxCorreo.Text;
            alumno.telefono = tbxTelefono.Text;
            alumno.universidad = tbxUniversidad.Text;
            alumno.titulacion = tbxTitulacion.Text;
            alumno.especialidad = tbxEspecialidad.Text;
            try
            {
                alumno.inicio = DateTime.Parse(dtpInicio.Text);
                alumno.fin = DateTime.Parse(dtpFin.Text);

                if (alumno.fin <= alumno.inicio)
                {
                    MessageBox.Show("La fecha de finalización debe ser posterior a la de inicio.");
                    return;
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Formato incorrecto: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            alumno.idCurso = Curso;
            CursoDTO curso = CursosApi.filtrarCursoId(Curso.ToString());
            if (curso == null)
            {
                MessageBox.Show("El curso indicado no existe. Por favor, seleccione un curso válido.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            if (string.IsNullOrEmpty(alumno.nombre))
            {
                // Mostrar un mensaje de error indicando que el nombre del alumno es obligatorio
                MessageBox.Show("El nombre del alumno es obligatorio", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(alumno.tipo))
            {
                // Mostrar un mensaje de error indicando que el nombre del alumno es obligatorio
                MessageBox.Show("El tipo del alumno es obligatorio", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (alumno.tipo.Length > 1)
            {
                MessageBox.Show("El tipo del alumno no puede tener más de un caracter", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrEmpty(alumno.email))
            {
                // Mostrar un mensaje de error indicando que el email del alumno es obligatorio
                MessageBox.Show("El email del alumno es obligatorio", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrEmpty(alumno.telefono))
            {
                // Mostrar un mensaje de error indicando que el teléfono del alumno es obligatorio
                MessageBox.Show("El teléfono del alumno es obligatorio", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrEmpty(alumno.universidad))
            {
                // Mostrar un mensaje de error indicando que la universidad del alumno es obligatoria
                MessageBox.Show("La universidad del alumno es obligatoria", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrEmpty(alumno.titulacion))
            {
                // Mostrar un mensaje de error indicando que la titulación del alumno es obligatoria
                MessageBox.Show("La titulación del alumno es obligatoria", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrEmpty(alumno.especialidad))
            {
                // Mostrar un mensaje de error indicando que la especialidad del alumno es obligatoria
                MessageBox.Show("La especialidad del alumno es obligatoria", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if ((bool)chbCv.IsChecked)
            {
                alumno.cv = "a";
            }
            else
            {
                alumno.cv = "b";
            }
            if ((bool)chbHorario.IsChecked)
            {
                alumno.horario = "a";
            }
            else
            {
                alumno.horario = "b";
            }
            if ((bool)chbConvenio.IsChecked)
            {
                alumno.convenio = "a";
            }
            else
            {
                alumno.convenio = "b";
            }
            if ((bool)chbEvaluacion.IsChecked)
            {
                alumno.evaluacion = "a";
            }
            else
            {
                alumno.evaluacion = "b";
            }

            string v = AlumnoExternoApi.AgregarAlumnoExterno(alumno);

            this.Close();

        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
