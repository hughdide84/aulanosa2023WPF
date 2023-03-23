using AulaNosaApp.DTO;
using AulaNosaApp.Servicios;
using AulaNosaApp.Util;
using iText.Svg.Renderers.Path.Impl;
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
    /// Lógica de interacción para NuevoPago.xaml
    /// </summary>
    public partial class NuevoPago : Page
    {
        public NuevoPago()
        {
            InitializeComponent();
            cbbAñadirEstado.SelectedIndex = 0;
            dtpAñadirFecha.SelectedDate = DateTime.Now;
        }

        // Boton de añadir pago
        private void btnAñadir_Click(object sender, RoutedEventArgs e)
        {
            // Verificar si se introdujo un recibo
            if (tbxAñadirRecibo.Text.Length == 0)
            {
                lblErrorRecibo.Content = "Campo vacio";
            }
            else
            {
                lblErrorRecibo.Content = "";
            }
            // Verificar si se introdujo una observacion
            if (tbxAñadirObservacion.Text.Length == 0)
            {
                lblErrorObservacion.Content = "Campo vacio";
            }
            else
            {
                lblErrorObservacion.Content = "";
            }
            // Verificar si se introdujo una fecha
            if (dtpAñadirFecha.Text.Length == 0)
            {
                lblErrorFecha.Content = "Campo vacio";
            }
            else
            {
                lblErrorFecha.Content = "";
            }
            // Si se introdujo todo
            if (tbxAñadirRecibo.Text.Length > 0 && tbxAñadirObservacion.Text.Length > 0 && dtpAñadirFecha.Text.Length > 0)
            {
                // Crear objeto
                PagoDTO pagoCreado = new PagoDTO();
                pagoCreado.id = 1;
                pagoCreado.idMatricula = Statics.matriculaSeleccionada.id;
                pagoCreado.recibo = tbxAñadirRecibo.Text.ToString();
                pagoCreado.pago = Statics.matriculaSeleccionada.cuota;
                pagoCreado.fecha = dtpAñadirFecha.SelectedDate;
                pagoCreado.observaciones = tbxAñadirObservacion.Text.ToString();
                pagoCreado.idUsuario = Statics.usuarioLogin.id;
                if (cbbAñadirEstado.SelectedIndex == 0)
                {
                    pagoCreado.estado = 'C';
                }
                else
                {
                    pagoCreado.estado = 'D';
                }
                // Crear pago
                PagosApi.crearPago(pagoCreado);
            }
        }

        // Boton de cancelar crear pago
        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
