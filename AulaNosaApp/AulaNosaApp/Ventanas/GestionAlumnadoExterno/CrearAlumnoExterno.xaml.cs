using AulaNosaApp.DTO;
using AulaNosaApp.DTO.AdministracionCursos;
using AulaNosaApp.Servicios;
using AulaNosaApp.Servicios.AdministracionCursos;
using AulaNosaApp.Util;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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
            alumno.nombre = tbxNombre.Text;
            if(tbxTipo.SelectedIndex == 0)
            {
                alumno.tipo = "M";
            }
            else if (tbxTipo.SelectedIndex == 1)
            {
                alumno.tipo = "O";
            }
            else
            {
                MessageBox.Show("Debes elegir una opción para el tipo");
                return;
            }
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
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return;
            }
            alumno.idCurso = Statics.idCursoElegido;

            if (string.IsNullOrEmpty(alumno.nombre))
            {
                // Mostrar un mensaje de error indicando que el nombre del alumno es obligatorio
                MessageBox.Show("El nombre del alumno es obligatorio", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if(alumno.nombre.Length > 50 || alumno.nombre.Length < 3)
            {
                MessageBox.Show("El nombre del alumno no puede tener menos de 3 caracteres o mas de 50", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(alumno.tipo))
            {
                // Mostrar un mensaje de error indicando que el nombre del alumno es obligatorio
                MessageBox.Show("El tipo del alumno es obligatorio", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(alumno.email))
            {
                // Mostrar un mensaje de error indicando que el email del alumno es obligatorio
                MessageBox.Show("El email del alumno es obligatorio", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                MailAddress correo = new MailAddress(tbxCorreo.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("El correo electrónico no es válido.", "Error");
                return;
            }

            if (string.IsNullOrEmpty(alumno.telefono))
            {
                // Mostrar un mensaje de error indicando que el teléfono del alumno es obligatorio
                MessageBox.Show("El teléfono del alumno es obligatorio", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if(alumno.telefono.Length != 9)
            {
                MessageBox.Show("El teléfono del alumno tiene que tener 9 caracteres", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
                alumno.cv = "S";
            }
            else
            {
                alumno.cv = "N";
            }
            if ((bool)chbHorario.IsChecked)
            {
                alumno.horario = "S";
            }
            else
            {
                alumno.horario = "N";
            }
            if ((bool)chbConvenio.IsChecked)
            {
                alumno.convenio = "S";
            }
            else
            {
                alumno.convenio = "N";
            }
            if ((bool)chbEvaluacion.IsChecked)
            {
                alumno.evaluacion = "S";
            }
            else
            {
                alumno.evaluacion = "N";
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
