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
        // Accion al clickear el boton de modificacion del estudio
        public EstudioEditar()
        {
            // Tomar los atributos del elemento a editar para mostrarlos
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
            // Verificar si se introdujo un nombre de estudio
            if (tbxEditarNombre.Text.Length == 0)
            {
                lblErrorNombreEstudio.Content = "Nombre de estudio vacio";
            }
            // Si esta todo completo
            else
            {
                lblErrorNombreEstudio.Content = "";
                // Modificar objeto
                Statics.estudioSeleccionado.nombre = tbxEditarNombre.Text;
                Statics.estudioSeleccionado.fct = (bool)chbFCT.IsChecked ? true : false;
                Statics.estudioSeleccionado.pext = (bool)chbPEXT.IsChecked ? true : false;
                // Modificar estudio
                EstudioApi.EditarEstudio(Statics.estudioSeleccionado);
                // Cerrar ventana
                Close();
            }
        }

        // Accion al clickear el boton de salir
        private void btnCancelarEstudio_Click(object sender, RoutedEventArgs e)
        {
            // Cerrar ventana
            Close();
        }
    }
}
