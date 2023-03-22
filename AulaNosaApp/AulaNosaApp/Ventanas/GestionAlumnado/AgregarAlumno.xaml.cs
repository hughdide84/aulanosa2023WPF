using AulaNosaApp.DTO;
using AulaNosaApp.Servicios;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace AulaNosaApp.Ventanas.GestionAlumnado
{
    /// <summary>
    /// Lógica de interacción para AgregarAlumno.xaml
    /// </summary>
    public partial class AgregarAlumno : Window
    {
        public AgregarAlumno()
        {
            InitializeComponent();
        }
        AlumnoDTO alumno = new AlumnoDTO();

        //Metodo Subir Archivo PDF
        private void SubirArchivo(Button boton, string tipoArchivo)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos PDF (*.pdf)|*.pdf";

            if (openFileDialog.ShowDialog() == true)
            {
                string fileName = openFileDialog.FileName;
                // aquí puedes guardar el archivo en algún lugar o almacenarlo en una base de datos

                switch (tipoArchivo)
                {
                    case "cv":
                        alumno.cv = "";
                        break;
                    case "carta":
                        alumno.carta = "";
                        break;
                    default:
                        break;
                }

                boton.Content = "Archivo subido";
                boton.IsEnabled = false;
            }
        }

        private void btnSubirCV_Click(object sender, RoutedEventArgs e)
        {
            SubirArchivo(btnSubirCV, "cv");
        }

        private void btnSubirCarta_Click(object sender, RoutedEventArgs e)
        {
            SubirArchivo(btnSubirCarta, "carta");
        }


        private async void Guardar_Click(object sender, RoutedEventArgs e)
        {
            int Curso;
            if (!int.TryParse(txtCurso.Text, out Curso))
            {
                MessageBox.Show("El valor introducido en el campo 'Curso' no es válido. Introduzca un número entero.");
                return;
            }
            int Estudios;
            if (!int.TryParse(txtEstudios.Text, out Estudios))
            {    
                MessageBox.Show("El valor introducido en el campo 'Estudios' no es válido. Introduzca un número entero.");
                return;                
            }
            int Empresa;
            if (!int.TryParse(txtEmpresa.Text, out Empresa))
            {
                MessageBox.Show("El valor introducido en el campo 'Empresa' no es válido. Introduzca un número entero.");
                return;
            }
            alumno.nombre = txtNombre.Text;


            try
            {
                alumno.inicioPr = DateTime.Parse(DPInicio.Text);
                alumno.finPr = DateTime.Parse(DPFinal.Text);
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
            alumno.idEmpresa = Empresa;
            alumno.idEstudios = Estudios;


            if (string.IsNullOrEmpty(alumno.nombre))
            {
                // Mostrar un mensaje de error indicando que el nombre del alumno es obligatorio
                MessageBox.Show("El nombre del alumno es obligatorio", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string v = AlumnoApi.AgregarAlumno(alumno);

            this.Close();

        }
    }
}
