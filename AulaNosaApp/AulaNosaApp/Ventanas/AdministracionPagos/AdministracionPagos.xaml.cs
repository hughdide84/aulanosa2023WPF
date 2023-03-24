using AulaNosaApp.DTO;
using AulaNosaApp.DTO.AdministracionCursos;
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

namespace AulaNosaApp.Ventanas.AdministracionPagos
{
    /// <summary>
    /// Lógica de interacción para AdministracionPagos.xaml
    /// </summary>
    public partial class AdministracionPagos : Window
    {

        List<PagoDTO> pagosLista;

        public AdministracionPagos()
        {
            InitializeComponent();
            refrescarLista();
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
            var pagoSeleccionado = dgvPagos.SelectedItem as PagoDTO;
            Statics.pagoSeleccionado = pagoSeleccionado;
            frmPagos.Navigate(new Uri("/Paginas/AdministracionPagos/EditarPago.xaml", UriKind.Relative));
        }

        // Refrescar lista
        void refrescarLista()
        {
            pagosLista = PagosApi.listarPagosIdMatricula(Statics.matriculaSeleccionada.id);
            dgvPagos.ItemsSource = null;
            dgvPagos.Items.Clear();
            dgvPagos.ItemsSource = pagosLista;
        }

        // Seleccionar elemento del DataGrid
        private void dgvPagos_Selected(object sender, RoutedEventArgs e)
        {
            btnEditarPago.IsEnabled = true;
            var pagoSeleccionado = dgvPagos.SelectedItem as PagoDTO;
        }
    }
}
