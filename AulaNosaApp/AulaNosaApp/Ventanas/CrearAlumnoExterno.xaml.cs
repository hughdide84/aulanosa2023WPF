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
    }
}
