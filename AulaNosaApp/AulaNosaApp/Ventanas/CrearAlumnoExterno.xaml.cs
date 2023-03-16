using AulaNosaApp.Servicios;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Text.Json;
using Newtonsoft.Json;

namespace AulaNosaApp.Ventanas
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

        private void SubirArchivo(Button boton)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos PDF (*.pdf)|*.pdf";

            if (openFileDialog.ShowDialog() == true)
            {
                string fileName = openFileDialog.FileName;
                // aquí puedes guardar el archivo en algún lugar o almacenarlo en una base de datos

                boton.Content = "Archivo subido";
                boton.IsEnabled = false;
            }
        }

        private void btnSubirCV_Click(object sender, RoutedEventArgs e)
        {
            SubirArchivo(btnSubirCV);
        }

        private void btnSubirConvenio_Click(object sender, RoutedEventArgs e)
        {
            SubirArchivo(btnSubirConvenio);
        }

        private void btnSubirEvaluacion_Click(object sender, RoutedEventArgs e)
        {
            SubirArchivo(btnSubirEvaluacion);
        }

        private void btnSubirHorario_Click(object sender, RoutedEventArgs e)
        {
            SubirArchivo(btnSubirHorario);
        }

        private async void Guardar_Click(object sender, RoutedEventArgs e)
        {
            AlumnoExterno alumno = new AlumnoExterno();
            int Curso;
            if (!int.TryParse(txtCurso.Text, out Curso))
            {
                MessageBox.Show("El valor introducido en el campo 'Curso' no es válido. Introduzca un número entero.");
                return;
            }
            alumno.Nombre = txtNombre.Text;
            alumno.Email = txtCorreo.Text;
            alumno.Telefono = txtTelefono.Text;
            alumno.Universidad = txtUniversidad.Text;
            alumno.Titulacion = txtTitulacion.Text;
            alumno.Especialidad = txtEspecialidad.Text;
            alumno.IdCurso = Curso;



            if (string.IsNullOrEmpty(alumno.Nombre))
            {
                // Mostrar un mensaje de error indicando que el nombre del alumno es obligatorio
                MessageBox.Show("El nombre del alumno es obligatorio", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrEmpty(alumno.Email))
            {
                // Mostrar un mensaje de error indicando que el email del alumno es obligatorio
                MessageBox.Show("El email del alumno es obligatorio", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrEmpty(alumno.Telefono))
            {
                // Mostrar un mensaje de error indicando que el teléfono del alumno es obligatorio
                MessageBox.Show("El teléfono del alumno es obligatorio", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrEmpty(alumno.Universidad))
            {
                // Mostrar un mensaje de error indicando que la universidad del alumno es obligatoria
                MessageBox.Show("La universidad del alumno es obligatoria", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrEmpty(alumno.Titulacion))
            {
                // Mostrar un mensaje de error indicando que la titulación del alumno es obligatoria
                MessageBox.Show("La titulación del alumno es obligatoria", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrEmpty(alumno.Especialidad))
            {
                // Mostrar un mensaje de error indicando que la especialidad del alumno es obligatoria
                MessageBox.Show("La especialidad del alumno es obligatoria", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // aquí puedes guardar los detalles del alumno en una base de datos
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://url-de-tu-api.com");

            // Convertir el objeto alumno a formato JSON
            string alumnoJson = JsonConvert.SerializeObject(alumno);

            // Crear un objeto HttpContent para enviar el objeto JSON en la solicitud POST
            HttpContent contenido = new StringContent(alumnoJson, Encoding.UTF8, "application/ejemplo");

            // Enviar la solicitud HTTP POST a la API
            HttpResponseMessage respuesta = await httpClient.PostAsync("/ruta-de-la-api-para-insertar-alumnos-externos", contenido);

            // Verificar si la solicitud fue exitosa
            if (respuesta.IsSuccessStatusCode)
            {
                MessageBox.Show("Alumno externo guardado exitosamente");
            }
            else
            {
                MessageBox.Show("Error al guardar el alumno externo. Código de estado: " + respuesta.StatusCode);
            }
        }
    }
}
