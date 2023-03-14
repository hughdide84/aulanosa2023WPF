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
    /// Lógica de interacción para EstudioEditar.xaml
    /// </summary>
    public partial class EstudioEditar : Window
    {
        public EstudioEditar(EstudioDTO estudio)
        {
            InitializeComponent();
            tbId.Text = estudio.id.ToString();
            tbNombre.Text = estudio.nombre.ToString();
            cbFct.IsChecked = estudio.fct;
            cbPext.IsChecked = estudio.pext;
        }

        private void Cancelar(object sender, RoutedEventArgs e)
        {
            string mensaje = "Va a abandonar la pantalla, podría perder las modificaciones realizadas. ¿Está seguro?";
            string titulo = "Confirmación";
            if (!tbNombre.Text.Equals(""))
            {
                if (MessageBox.Show(mensaje, titulo, MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
                    this.Close();
            }
            else
            {
                this.Close();
            }
        }

        private void Aceptar(object sender, RoutedEventArgs e)
        {
            tbErrores.Visibility = Visibility.Hidden;
            EstudioDTO estudio = new EstudioDTO();
            estudio.id = Convert.ToInt32(tbId.Text);
            estudio.nombre = tbNombre.Text;
            estudio.fct = (bool) cbFct.IsChecked ? true : false;
            estudio.pext = (bool) cbPext.IsChecked ? true : false;
            string errores = EstudioApi.EditarEstudio(estudio);
            if (!errores.Equals(""))
            {
                tbErrores.Text = errores;
                tbErrores.Visibility = Visibility.Visible;
            }
            else
            {
                Close();
            }
        }

    }
}
