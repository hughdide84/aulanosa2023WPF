using AulaNosaApp.DTO;
using AulaNosaApp.DTO.AdministracionCursos;
using AulaNosaApp.Servicios;
using AulaNosaApp.Servicios.AdministracionCursos;
using AulaNosaApp.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Lógica de interacción para ModificarAlumnoExterno.xaml
    /// </summary>
    public partial class ModificarAlumnoExterno : Window
    {
        internal ModificarAlumnoExterno(AlumnoExternoDTO alumnoExternoDTO)
        {
            InitializeComponent();
            // Tomar los atributos del elemento a editar para mostrarlos
            tbxId.Text = alumnoExternoDTO.id.ToString();
            tbxNombre.Text = alumnoExternoDTO.nombre.ToString();
            tbxCorreo.Text = alumnoExternoDTO.email.ToString();
            tbxTelefono.Text = alumnoExternoDTO.telefono.ToString();
            tbxUniversidad.Text = alumnoExternoDTO.universidad.ToString();
            tbxTitulacion.Text = alumnoExternoDTO.titulacion.ToString();
            tbxEspecialidad.Text = alumnoExternoDTO.especialidad.ToString();
            if (alumnoExternoDTO.tipo.ToString() == "M")
            {
                tbxTipo.SelectedIndex = 0;
            }
            else if (alumnoExternoDTO.tipo.ToString() == "O")
            {
                tbxTipo.SelectedIndex = 1;
            }
            dtpInicio.Text = alumnoExternoDTO.inicio.ToString();
            dtpFin.Text = alumnoExternoDTO.fin.ToString();
            chbCv.IsChecked = alumnoExternoDTO.cv.Equals("S");
            chbHorario.IsChecked = alumnoExternoDTO.horario.Equals("S");
            chbConvenio.IsChecked = alumnoExternoDTO.convenio.Equals("S");
            chbEvaluacion.IsChecked = alumnoExternoDTO.evaluacion.Equals("S");
        }

        private void Guardar_Click(object sender, RoutedEventArgs e)
        {
            int id;
            if (!int.TryParse(tbxId.Text, out id))
            {
                MessageBox.Show("El valor introducido en el campo 'Curso' no es válido. Introduzca un número entero.");
                return;
            }
            // Crear objeto
            AlumnoExternoDTO alumnoExternoInsertar = new AlumnoExternoDTO();
            alumnoExternoInsertar.id = id;
            alumnoExternoInsertar.nombre = tbxNombre.Text;
            alumnoExternoInsertar.email = tbxCorreo.Text.ToString();
            alumnoExternoInsertar.telefono = tbxTelefono.Text.ToString();
            alumnoExternoInsertar.universidad = tbxUniversidad.Text;
            alumnoExternoInsertar.titulacion = tbxTitulacion.Text;
            alumnoExternoInsertar.especialidad = tbxEspecialidad.Text;
            alumnoExternoInsertar.idCurso = Statics.idCursoElegido;
            if (tbxTipo.SelectedIndex == 0)
            {
                alumnoExternoInsertar.tipo = "M";
            }
            else if (tbxTipo.SelectedIndex == 1)
            {
                alumnoExternoInsertar.tipo = "O";
            }
            else
            {
                MessageBox.Show("Debes elegir una opción para el tipo");
                return;
            }
            try
            {
                alumnoExternoInsertar.inicio = DateTime.Parse(dtpInicio.Text);
                alumnoExternoInsertar.fin = DateTime.Parse(dtpFin.Text);

                if (alumnoExternoInsertar.fin <= alumnoExternoInsertar.inicio)
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
            if ((bool)chbCv.IsChecked)
            {
                alumnoExternoInsertar.cv = "S";
            }
            else
            {
                alumnoExternoInsertar.cv = "N";
            }
            if ((bool)chbHorario.IsChecked)
            {
                alumnoExternoInsertar.horario = "S";
            }
            else
            {
                alumnoExternoInsertar.horario = "N";
            }
            if ((bool)chbConvenio.IsChecked)
            {
                alumnoExternoInsertar.convenio = "S";
            }
            else
            {
                alumnoExternoInsertar.convenio = "N";
            }
            if ((bool)chbEvaluacion.IsChecked)
            {
                alumnoExternoInsertar.evaluacion = "S";
            }
            else
            {
                alumnoExternoInsertar.evaluacion = "N";
            }
            if (string.IsNullOrEmpty(alumnoExternoInsertar.nombre))
            {
                // Mostrar un mensaje de error indicando que el nombre del alumno es obligatorio
                MessageBox.Show("El nombre del alumno es obligatorio", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (alumnoExternoInsertar.nombre.Length > 50 || alumnoExternoInsertar.nombre.Length < 3)
            {
                MessageBox.Show("El nombre del alumno no puede tener menos de 3 caracteres o mas de 50", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(alumnoExternoInsertar.tipo))
            {
                // Mostrar un mensaje de error indicando que el nombre del alumno es obligatorio
                MessageBox.Show("El tipo del alumno es obligatorio", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(alumnoExternoInsertar.email))
            {
                // Mostrar un mensaje de error indicando que el email del alumno es obligatorio
                MessageBox.Show("El email del alumno es obligatorio", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(alumnoExternoInsertar.telefono))
            {
                // Mostrar un mensaje de error indicando que el teléfono del alumno es obligatorio
                MessageBox.Show("El teléfono del alumno es obligatorio", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrEmpty(alumnoExternoInsertar.universidad))
            {
                // Mostrar un mensaje de error indicando que la universidad del alumno es obligatoria
                MessageBox.Show("La universidad del alumno es obligatoria", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrEmpty(alumnoExternoInsertar.titulacion))
            {
                // Mostrar un mensaje de error indicando que la titulación del alumno es obligatoria
                MessageBox.Show("La titulación del alumno es obligatoria", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrEmpty(alumnoExternoInsertar.especialidad))
            {
                // Mostrar un mensaje de error indicando que la especialidad del alumno es obligatoria
                MessageBox.Show("La especialidad del alumno es obligatoria", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            bool terminacion;

            terminacion = tbxCorreo_LostFocus(sender, e);
            if (terminacion == false)
            {
                MessageBox.Show("El correo electrónico debe terminar en .com o .es", "Error de validación");
                return;
            }
            // Editar alumnno externo
            AlumnoExternoApi.EditarAlumnoExterno(alumnoExternoInsertar);
            // Cerrar ventana
            Close();

        }
        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private bool tbxCorreo_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!tbxCorreo.Text.EndsWith(".com") && !tbxCorreo.Text.EndsWith(".es"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
