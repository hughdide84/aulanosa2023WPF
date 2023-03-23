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

namespace AulaNosaApp.Ventanas.AdministracionPagos
{
    /// <summary>
    /// Lógica de interacción para AdministracionPagos.xaml
    /// </summary>
    public partial class AdministracionPagos : Window
    {
        public AdministracionPagos()
        {
            InitializeComponent();
        }

        // Boton de refrescar lista
        private void btnRefrescarPagos_Click(object sender, RoutedEventArgs e)
        {
            refrescarLista();
        }

        // Boton de nuevo pago
        private void btnNuevoPago_Click(object sender, RoutedEventArgs e)
        {
            frmPagos.Navigate(new Uri("/Paginas/AdministracionPagos/NuevoPago.xaml", UriKind.Relative));
        }

        // Boton de editar pago
        private void btnEditarPago_Click(object sender, RoutedEventArgs e)
        {
            frmPagos.Navigate(new Uri("/Paginas/AdministracionPagos/EditarPago.xaml", UriKind.Relative));
        }

        // Refrescar lista
        void refrescarLista()
        {
            frmPagos.Navigate(new Uri("/Paginas/VentanaVacia.xaml", UriKind.Relative));
        }
    }
}
