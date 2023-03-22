using AulaNosaApp.DTO;
using AulaNosaApp.Servicios;
using AulaNosaApp.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AulaNosaApp.Ventanas.AdministracionMatriculas
{
    /// <summary>
    /// Lógica de interacción para AgregarMatricula.xaml
    /// </summary>
    public partial class AgregarMatricula : Window
    {
        public AgregarMatricula()
        {
            InitializeComponent();
        }

        // Boton de añadir matricula
        private void btnAñadir_Click(object sender, RoutedEventArgs e)
        {
            bool nifCorrecto = Regex.IsMatch(tbxNifCrearMatricula.Text, "^[KLMXYZ]\\d{7}[A-Z]$");
            bool cuotaCorrecta = float.TryParse(tbxCuotaCrearMatricula.Text, out float cuota);
            bool matriculaCorrecta = float.TryParse(tbxMatriculaCrearMatricula.Text, out float matricula);
            // Verificar si se introdujo una factura
            if (tbxFacturaCrearMatricula.Text.Length == 0)
            {
                lblErrorFactura.Content = "Campo vacio";
            }
            else
            {
                lblErrorFactura.Content = "";
            }
            // Verificar si se introdujo un nombre
            if (tbxNombreCrearMatricula.Text.Length == 0)
            {
                lblErrorNombre.Content = "Campo vacio";
            }
            else
            {
                lblErrorNombre.Content = "";
            }
            // Verificar si se introdujo un NIF correctamente
            if (tbxNifCrearMatricula.Text.Length == 0)
            {
                lblErrorNif.Content = "Campo vacio";
            }
            else if (!nifCorrecto)
            {
                lblErrorNif.Content = "Error de formato";
            }
            else
            {
                lblErrorNif.Content = "";
            }
            // Verificar si se introdujo un numero de cuota
            if (tbxCuotaCrearMatricula.Text.Length == 0)
            {
                lblErrorCuota.Content = "Campo vacio";
            }
            else if (!cuotaCorrecta)
            {
                lblErrorCuota.Content = "Error de formato";
            }
            else
            {
                lblErrorCuota.Content = "";
            }
            // Verificar si se introdujo un numero de matricula
            if (tbxMatriculaCrearMatricula.Text.Length == 0)
            {
                lblErrorMatricula.Content = "Campo vacio";
            }
            else if (!matriculaCorrecta)
            {
                lblErrorMatricula.Content = "Error de formato";
            }
            else
            {
                lblErrorMatricula.Content = "";
            }
            // Verificar si se introdujo una observacion o no
            if (tbxObservacionCrearMatricula.Text.Length == 0)
            {
                lblErrorObservacion.Content = "Campo vacio";
            }
            else
            {
                lblErrorObservacion.Content = "";
            }
            // Verificar si se introdujo una fecha de inicio
            if (dtpAñadirInicio.SelectedDate == null)
            {
                lblErrorFechaInicio.Content = "Fecha de inicio vacio";
            }
            else
            {
                lblErrorFechaInicio.Content = "";
            }
            // Verificar si se introdujo una fecha de fin y que esta sea despues de la fecha de inicio
            if (dtpAñadirFin.SelectedDate == null)
            {
                lblErrorFechaFin.Content = "Fecha de fin vacio";
            }
            else if (dtpAñadirFin.SelectedDate.Value.Date < dtpAñadirInicio.SelectedDate.Value.Date)
            {
                lblErrorFechaFin.Content = "La fecha de fin no puede ser anterior a la fecha de inicio";
            }
            else if (dtpAñadirFin.SelectedDate.Value.Date == dtpAñadirInicio.SelectedDate.Value.Date)
            {
                lblErrorFechaFin.Content = "La fecha de fin no puede ser igual a la fecha de inicio";
            }
            else
            {
                lblErrorFechaFin.Content = "";
            }
            // Si se han cumplido todos los requisitos
            if (tbxFacturaCrearMatricula.Text.Length != 0 && tbxNombreCrearMatricula.Text.Length != 0 && tbxNifCrearMatricula.Text.Length != 0 && nifCorrecto 
                && tbxCuotaCrearMatricula.Text.Length != 0 && cuotaCorrecta && tbxMatriculaCrearMatricula.Text.Length != 0 && matriculaCorrecta 
                && tbxObservacionCrearMatricula.Text.Length != 0 && dtpAñadirInicio.SelectedDate != null && dtpAñadirFin.SelectedDate != null 
                && dtpAñadirFin.SelectedDate.Value.Date > dtpAñadirInicio.SelectedDate.Value.Date)
            {
                // Crear objeto
                MatriculaDTO matriculaCrear = new MatriculaDTO();
                matriculaCrear.id = 1;
                matriculaCrear.factura = tbxFacturaCrearMatricula.Text;
                matriculaCrear.nombre = tbxNombreCrearMatricula.Text;
                matriculaCrear.nif = tbxNifCrearMatricula.Text;
                matriculaCrear.cuota = float.Parse(tbxCuotaCrearMatricula.Text);
                matriculaCrear.matricula = float.Parse(tbxMatriculaCrearMatricula.Text);
                matriculaCrear.idCurso = 1;
                matriculaCrear.observaciones = tbxObservacionCrearMatricula.Text;
                matriculaCrear.fecha = dtpAñadirInicio.SelectedDate;
                matriculaCrear.idUsuario = Statics.usuarioLogin.id;
                matriculaCrear.fechaBaja = dtpAñadirFin.SelectedDate;
                // Crear matricula
                MatriculaApi.crearMatricula(matriculaCrear);
                // Cerrar
                Close();
            }
        }

        // Boton de cancelar crear matricula
        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
