using AulaNosaApp.DTO;
using AulaNosaApp.Servicios;
using AulaNosaApp.Servicios.AdministracionUsuarios;
using AulaNosaApp.Util;
using Microsoft.Win32;
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

namespace AulaNosaApp.Ventanas.GestionProyectos
{
    /// <summary>
    /// Lógica de interacción para ProyectoCrear.xaml
    /// </summary>
    public partial class ProyectoCrear : Window
    {

        public ProyectoCrear()
        {
            InitializeComponent();
        }

        // Accion al clickear el boton de creacion del proyecto
        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            // Verificar si se introdujo un Id de Alumno vacío
            if (tbxIdAlumno.Text.Length == 0)
            {
                lblErrorIdAlumno.Content = "Id de alumno vacio";
            }
            else
            {
                lblErrorIdAlumno.Content = "";
            }
            // Verificar que se introdujo una nota de documentacion mayor que 10
            if (tbxNotaDocumento.Text == "" || int.Parse(tbxNotaDocumento.Text) == 0)
            {
                lblErrorNotaDocumento.Content = "Nota vacia o 0";
            }
            else if (int.Parse(tbxNotaDocumento.Text) > 10)
            {
                lblErrorNotaDocumento.Content = "La nota máxima del documento es un 10";
            }
            else
            {
                lblErrorNotaDocumento.Content = "";
            }
            // Verificar que se introdujo una nota de presentacion mayor que 10
            if (tbxNotaPresentacion.Text == "" || int.Parse(tbxNotaPresentacion.Text) == 0)
            {
                lblErrorNotaPresentacion.Content = "Nota vacia o 0";
            }
            else if (int.Parse(tbxNotaPresentacion.Text) > 10)
            {
                lblErrorNotaPresentacion.Content = "La nota máxima de la presentacion es un 10";
            }
            else
            {
                lblErrorNotaPresentacion.Content = "";
            }
            // Verificar que se introdujo una nota final mayor que 10
            if (tbxNotaFinal.Text == "" || int.Parse(tbxNotaFinal.Text) == 0)
            {
                lblErrorNotaFinal.Content = "Nota vacia o 0";
            }
            else if (int.Parse(tbxNotaFinal.Text) > 10)
            {
                lblErrorNotaFinal.Content = "La nota máxima final es un 10";
            }
            else
            {
                lblErrorNotaFinal.Content = "";
            }
            // Verificar si se introdujo una fecha de tutoria1
            if (dtpTutoria1.SelectedDate == null)
            {
                lblErrorFechaTutoria1.Content = "Fecha de tutoria1 vacia";
            }
            else
            {
                lblErrorFechaTutoria1.Content = "";
            }
            // Verificar si se introdujo una fecha de tutoria2 y que esta sea despues de la fecha de tutoria1
            if (dtpTutoria2.SelectedDate == null)
            {
                lblErrorFechaTutoria2.Content = "Fecha de tutoria2 vacia";
            }
            else if (dtpTutoria2.SelectedDate.Value.Date < dtpTutoria1.SelectedDate.Value.Date)
            {
                lblErrorFechaTutoria2.Content = "La fecha de tutoria2 no puede ser anterior a la fecha de tutoria1";
            }
            else if (dtpTutoria2.SelectedDate.Value.Date == dtpTutoria1.SelectedDate.Value.Date)
            {
                lblErrorFechaTutoria2.Content = "La fecha de tutoria2 no puede ser igual a la fecha de tutoria1";
            }
            else
            {
                lblErrorFechaTutoria2.Content = "";
            }
            // Verificar si se introdujo una fecha de tutoria3 y que esta sea despues de la fecha de tutoria2
            if (dtpTutoria3.SelectedDate == null)
            {
                lblErrorFechaTutoria3.Content = "Fecha de tutoria3 vacia";
            }
            else if (dtpTutoria3.SelectedDate.Value.Date < dtpTutoria2.SelectedDate.Value.Date)
            {
                lblErrorFechaTutoria3.Content = "La fecha de tutoria3 no puede ser anterior a la fecha de tutoria2";
            }
            else if (dtpTutoria3.SelectedDate.Value.Date == dtpTutoria2.SelectedDate.Value.Date)
            {
                lblErrorFechaTutoria3.Content = "La fecha de tutoria3 no puede ser igual a la fecha de tutoria2";
            }
            else
            {
                lblErrorFechaTutoria3.Content = "";
            }
            // Verificar si se introdujo una fecha de exposicion y que esta sea despues de la fecha de tutoria3
            if (dtpExposicion.SelectedDate == null)
            {
                lblErrorFechaExposicion.Content = "Fecha de exposicion vacia";
            }
            else if (dtpExposicion.SelectedDate.Value.Date < dtpTutoria3.SelectedDate.Value.Date)
            {
                lblErrorFechaExposicion.Content = "La fecha de exposicion no puede ser anterior a la fecha de tutoria3";
            }
            else if (dtpExposicion.SelectedDate.Value.Date == dtpTutoria3.SelectedDate.Value.Date)
            {
                lblErrorFechaExposicion.Content = "La fecha de exposicion no puede ser igual a la fecha de tutoria3";
            }
            else
            {
                lblErrorFechaExposicion.Content = "";
            }
            // Si se cumplen todos los requisitos, entrara en la accion de crear el proyecto
            if (lblErrorIdAlumno.Content == "" && lblErrorNotaDocumento.Content == "" && lblErrorNotaPresentacion.Content == "" && lblErrorNotaFinal.Content == "" && lblErrorFechaTutoria1.Content == "" && lblErrorFechaTutoria2.Content == "" && lblErrorFechaTutoria3.Content == "" && lblErrorFechaExposicion.Content == "")
            {
                // Crear un objeto
                ProyectoDTO proyecto = new ProyectoDTO();
                proyecto.id = 1; // (al ser un id autoincremental, este sera el ultimo id registrado + 1, pero se pone aqui un id por que el objeto tiene que tener un valor en el atributo)
                proyecto.idAlumno = int.Parse(tbxIdAlumno.Text);
                if (chbDocumento.IsChecked == true)
                {
                    proyecto.documento = 's';
                }
                else
                {
                    proyecto.documento = 'a';
                }
                if (chbPresentacion.IsChecked == true)
                {
                    proyecto.presentacion = 's';
                }
                else
                {
                    proyecto.presentacion = 'a';
                }
                proyecto.notaDoc = int.Parse(tbxNotaDocumento.Text);
                proyecto.notaPres = int.Parse(tbxNotaPresentacion.Text);
                proyecto.notaFinal = int.Parse(tbxNotaFinal.Text);
                proyecto.exposicion = DateTime.Parse(dtpExposicion.Text);
                proyecto.tutoria1 = DateTime.Parse(dtpTutoria1.Text);
                proyecto.tutoria2 = DateTime.Parse(dtpTutoria2.Text);
                proyecto.tutoria3 = DateTime.Parse(dtpTutoria3.Text);
                if (cbbEstadoTutoria1.SelectedIndex == 0)
                {
                    proyecto.estadoTutoria1 = 'p';
                }
                else if (cbbEstadoTutoria1.SelectedIndex == 1)
                {
                    proyecto.estadoTutoria1 = 'a';
                }
                else
                {
                    proyecto.estadoTutoria1 = 'f';
                }
                if (cbbEstadoTutoria2.SelectedIndex == 0)
                {
                    proyecto.estadoTutoria2 = 'p';
                }
                else if (cbbEstadoTutoria2.SelectedIndex == 1)
                {
                    proyecto.estadoTutoria2 = 'a';
                }
                else
                {
                    proyecto.estadoTutoria2 = 'f';
                }
                if (cbbEstadoTutoria3.SelectedIndex == 0)
                {
                    proyecto.estadoTutoria3 = 'p';
                }
                else if (cbbEstadoTutoria3.SelectedIndex == 1)
                {
                    proyecto.estadoTutoria3 = 'a';
                }
                else
                {
                    proyecto.estadoTutoria3 = 'f';
                }
                // Crear proyecto
                ProyectoApi.crearProyecto(proyecto);
                // Cerrar ventana
                Close();
            }
        }

        // Accion al clickear el boton de salir
        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        //Controladores de que no se puedan insertar letras en los TextBox
        private void tbxIdAlumno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void tbxNotaDocumento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void tbxNotaPresentacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void tbxNotaFinal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
                e.Handled = false;
            else
                e.Handled = true;
        }
    }
}
