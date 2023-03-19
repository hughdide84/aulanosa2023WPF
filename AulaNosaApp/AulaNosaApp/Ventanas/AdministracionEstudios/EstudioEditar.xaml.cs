using AulaNosaApp.DTO;
using AulaNosaApp.Servicios;
using AulaNosaApp.Util;
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
    /// Lógica de interacción para EstudioEditar.xaml
    /// </summary>
    public partial class EstudioEditar : Window
    {
        public EstudioEditar()
        {
            InitializeComponent();
            tbkId.Text = Statics.estudioSeleccionado.id.ToString();
            tbxEditarNombre.Text = Statics.estudioSeleccionado.nombre.ToString();
            if (Statics.estudioSeleccionado.fct)
            {
                chbFCT.IsChecked = true;
            }
            else
            {
                chbFCT.IsChecked = false;
            }
            if (Statics.estudioSeleccionado.pext)
            {
                chbPEXT.IsChecked = true;
            }
            else
            {
                chbPEXT.IsChecked = false;
            }
        }

        private void btnEditarEstudio_Click(object sender, RoutedEventArgs e)
        {
            if (tbxEditarNombre.Text.Length == 0)
            {
                lblErrorNombreEstudio.Content = "Nombre de estudio vacio";
            }
            else
            {
                lblErrorNombreEstudio.Content = "";
                Statics.estudioSeleccionado.nombre = tbxEditarNombre.Text;
                Statics.estudioSeleccionado.fct = (bool)chbFCT.IsChecked ? true : false;
                Statics.estudioSeleccionado.pext = (bool)chbPEXT.IsChecked ? true : false;
                EstudioApi.EditarEstudio(Statics.estudioSeleccionado);
                Close();
            }
        }

        private void btnCancelarEstudio_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
