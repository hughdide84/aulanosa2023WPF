using AulaNosaApp.DTO;
using AulaNosaApp.Servicios;
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
    /// Lógica de interacción para EstudiosAlta.xaml
    /// </summary>
    public partial class EstudioAlta : Window
    {
        public EstudioAlta()
        {
            InitializeComponent();
        }

        private void btnAnadir_Click(object sender, RoutedEventArgs e)
        {
            if (tbxNombre.Text.Length == 0)
            {
                lblErrorNombreEstudio.Content = "Nombre de estudio vacio";
            }
            else
            {
                lblErrorNombreEstudio.Content = "";
                // Crear objeto Estudio
                EstudioDTO estudio = new EstudioDTO();
                estudio.nombre = tbxNombre.Text;
                estudio.fct = (bool)chbFct.IsChecked ? true : false;
                estudio.pext = (bool)chbPext.IsChecked ? true : false;
                // Funcion de crear usuario
                EstudioApi.AltaEstudio(estudio);
                // Cerrar ventana
                Close();
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
