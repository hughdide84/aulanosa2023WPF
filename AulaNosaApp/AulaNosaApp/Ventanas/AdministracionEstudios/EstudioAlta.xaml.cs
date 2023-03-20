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

        // Accion al clickear el boton de creacion del estudio
        private void btnAnadir_Click(object sender, RoutedEventArgs e)
        {
            // Verificar si se introdujo un nombre de estudio
            if (tbxNombre.Text.Length == 0)
            {
                lblErrorNombreEstudio.Content = "Nombre de estudio vacio";
            }
            // Si esta todo completo
            else
            {
                lblErrorNombreEstudio.Content = "";
                // Crear un objeto
                EstudioDTO estudio = new EstudioDTO();
                estudio.nombre = tbxNombre.Text;
                estudio.fct = (bool)chbFct.IsChecked ? true : false;
                estudio.pext = (bool)chbPext.IsChecked ? true : false;
                // Crear estudio
                EstudioApi.AltaEstudio(estudio);
                // Cerrar ventana
                Close();
            }
        }

        // Accion al clickear el boton de salir
        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            // Cerrar ventana
            Close();
        }
    }
}
