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
    /// Lógica de interacción para EditarMatricula.xaml
    /// </summary>
    public partial class EditarMatricula : Window
    {
        public EditarMatricula()
        {
            InitializeComponent();
            tbxIdEditarMatricula.Text = Statics.matriculaSeleccionada.id.ToString();
            tbxFacturaEditarMatricula.Text = Statics.matriculaSeleccionada.factura;
            tbxNombreEditarMatricula.Text = Statics.matriculaSeleccionada.nombre;
            tbxNifEditarMatricula.Text = Statics.matriculaSeleccionada.nif;
            tbxCuotaEditarMatricula.Text = Statics.matriculaSeleccionada.cuota.ToString();
            tbxMatriculaEditarMatricula.Text = Statics.matriculaSeleccionada.matricula.ToString();
            tbxObservacionEditarMatricula.Text = Statics.matriculaSeleccionada.observaciones.ToString();
            dtpEditarInicio.SelectedDate = Statics.matriculaSeleccionada.fecha;
            dtpEditarFin.SelectedDate = Statics.matriculaSeleccionada.fechaBaja;
        }

        // Boton de editar matricula
        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            bool nifCorrecto = Regex.IsMatch(tbxNifEditarMatricula.Text, "^[KLMXYZ]\\d{7}[A-Z]$");
            bool cuotaCorrecta = float.TryParse(tbxCuotaEditarMatricula.Text, out float cuota);
            bool matriculaCorrecta = float.TryParse(tbxMatriculaEditarMatricula.Text, out float matricula);
            // Verificar si se introdujo una factura
            if (tbxFacturaEditarMatricula.Text.Length == 0)
            {
                lblErrorFactura.Content = "Campo vacio";
            }
            else
            {
                lblErrorFactura.Content = "";
            }
            // Verificar si se introdujo un nombre
            if (tbxNombreEditarMatricula.Text.Length == 0)
            {
                lblErrorNombre.Content = "Campo vacio";
            }
            else
            {
                lblErrorNombre.Content = "";
            }
            // Verificar si se introdujo un NIF correctamente
            if (tbxNifEditarMatricula.Text.Length == 0)
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
            if (tbxCuotaEditarMatricula.Text.Length == 0)
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
            if (tbxMatriculaEditarMatricula.Text.Length == 0)
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
            if (tbxObservacionEditarMatricula.Text.Length == 0)
            {
                lblErrorObservacion.Content = "Campo vacio";
            }
            else
            {
                lblErrorObservacion.Content = "";
            }
            // Verificar si se introdujo una fecha de inicio
            if (dtpEditarInicio.SelectedDate == null)
            {
                lblErrorFechaInicio.Content = "Fecha de inicio vacio";
            }
            else
            {
                lblErrorFechaInicio.Content = "";
            }
            // Verificar si se introdujo una fecha de fin y que esta sea despues de la fecha de inicio
            if (dtpEditarFin.SelectedDate == null)
            {
                lblErrorFechaFin.Content = "Fecha de fin vacio";
            }
            else if (dtpEditarFin.SelectedDate.Value.Date < dtpEditarInicio.SelectedDate.Value.Date)
            {
                lblErrorFechaFin.Content = "La fecha de fin no puede ser anterior a la fecha de inicio";
            }
            else if (dtpEditarFin.SelectedDate.Value.Date == dtpEditarInicio.SelectedDate.Value.Date)
            {
                lblErrorFechaFin.Content = "La fecha de fin no puede ser igual a la fecha de inicio";
            }
            else
            {
                lblErrorFechaFin.Content = "";
            }
            // Verificar si todo esta correcto
            if (tbxFacturaEditarMatricula.Text.Length != 0 && tbxNombreEditarMatricula.Text.Length != 0 && tbxNifEditarMatricula.Text.Length != 0 && nifCorrecto
                && tbxCuotaEditarMatricula.Text.Length != 0 && cuotaCorrecta && tbxMatriculaEditarMatricula.Text.Length != 0 && matriculaCorrecta
                && tbxObservacionEditarMatricula.Text.Length != 0 && dtpEditarInicio.SelectedDate != null && dtpEditarFin.SelectedDate != null
                && dtpEditarFin.SelectedDate.Value.Date > dtpEditarInicio.SelectedDate.Value.Date)
            {
                // Editar objeto
                MatriculaDTO matriculaEditar = new MatriculaDTO();
                matriculaEditar.id = Statics.matriculaSeleccionada.id;
                matriculaEditar.factura = tbxFacturaEditarMatricula.Text;
                matriculaEditar.nombre = tbxNombreEditarMatricula.Text;
                matriculaEditar.nif = tbxNifEditarMatricula.Text;
                matriculaEditar.cuota = float.Parse(tbxCuotaEditarMatricula.Text);
                matriculaEditar.matricula = float.Parse(tbxMatriculaEditarMatricula.Text);
                matriculaEditar.idCurso = Statics.idCursoElegido;
                matriculaEditar.observaciones = tbxObservacionEditarMatricula.Text;
                matriculaEditar.fecha = dtpEditarInicio.SelectedDate;
                matriculaEditar.idUsuario = Statics.usuarioLogin.id;
                matriculaEditar.fechaBaja = dtpEditarFin.SelectedDate;
                // Editar matricula
                MatriculaApi.editarMatricula(matriculaEditar);
                // Cerrar
                Close();
            }
        }

        // Boton de cancelar editar matricula
        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
