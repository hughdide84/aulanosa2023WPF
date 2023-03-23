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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AulaNosaApp.Paginas.PaginasPagos
{
    /// <summary>
    /// Lógica de interacción para EditarPago.xaml
    /// </summary>
    public partial class EditarPago : Page
    {
        public EditarPago()
        {
            InitializeComponent();
            tbxEditarRecibo.Text = Statics.pagoSeleccionado.recibo;
            tbxEditarObservacion.Text = Statics.pagoSeleccionado.observaciones;
            dtpEditarFecha.SelectedDate = Statics.pagoSeleccionado.fecha;
            if (Statics.pagoSeleccionado.estado == 'C')
            {
                cbbEditarEstado.SelectedIndex = 0;
            }
            else
            {
                cbbEditarEstado.SelectedIndex = 1;
            }
        }

        // Boton de editar pago
        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            // Verificar si se introdujo un recibo
            if (tbxEditarRecibo.Text.Length == 0)
            {
                lblErrorRecibo.Content = "Campo vacio";
            }
            else
            {
                lblErrorRecibo.Content = "";
            }
            // Verificar si se introdujo una observacion
            if (tbxEditarObservacion.Text.Length == 0)
            {
                lblErrorObservacion.Content = "Campo vacio";
            }
            else
            {
                lblErrorObservacion.Content = "";
            }
            // Verificar si se introdujo una fecha
            if (dtpEditarFecha.Text.Length == 0)
            {
                lblErrorFecha.Content = "Campo vacio";
            }
            else
            {
                lblErrorFecha.Content = "";
            }
            // Si se introdujo todo
            if (tbxEditarRecibo.Text.Length > 0 && tbxEditarObservacion.Text.Length > 0 && dtpEditarFecha.Text.Length > 0)
            {
                // Crear objeto
                PagoDTO pagoEditado = new PagoDTO();
                pagoEditado.id = Statics.pagoSeleccionado.id;
                pagoEditado.idMatricula = Statics.matriculaSeleccionada.id;
                pagoEditado.recibo = tbxEditarRecibo.Text.ToString();
                pagoEditado.pago = Statics.matriculaSeleccionada.cuota;
                pagoEditado.fecha = dtpEditarFecha.SelectedDate;
                pagoEditado.observaciones = tbxEditarObservacion.Text.ToString();
                pagoEditado.idUsuario = Statics.usuarioLogin.id;
                if (cbbEditarEstado.SelectedIndex == 0)
                {
                    pagoEditado.estado = 'C';
                }
                else
                {
                    pagoEditado.estado = 'D';
                }
                // Editar pago
                PagosApi.editarPago(pagoEditado);
            }
        }

        // Boton de cancelar editar pago
        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
