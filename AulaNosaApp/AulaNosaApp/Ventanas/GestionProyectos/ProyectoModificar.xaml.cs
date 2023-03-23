using AulaNosaApp.DTO;
using AulaNosaApp.Servicios;
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
    /// Lógica de interacción para ProyectoModificar.xaml
    /// </summary>
    public partial class ProyectoModificar : Window
    {

        public ProyectoModificar()
        {
            InitializeComponent();
            // Tomar los atributos del elemento a editar para mostrarlos
            tbxId.Text = Statics.proyectoSeleccionado.id.ToString();
            tbxIdAlumno.Text = Statics.proyectoSeleccionado.idAlumno.ToString();
            if (Statics.proyectoSeleccionado.documento == 's')
            {
                chbDocumento.IsChecked = true;
            }
            else
            {
                chbDocumento.IsChecked = false;
            }
            if (Statics.proyectoSeleccionado.presentacion == 's')
            {
                chbPresentacion.IsChecked = true;
            }
            else
            {
                chbPresentacion.IsChecked = false;
            }
            tbxNotaDocumento.Text = Statics.proyectoSeleccionado.notaDoc.ToString();
            tbxNotaPresentacion.Text = Statics.proyectoSeleccionado.notaPres.ToString();
            tbxNotaFinal.Text = Statics.proyectoSeleccionado.notaFinal.ToString();
        }

        // Accion al clickear el boton de creacion del proyecto
        private void btnModificar_Click(object sender, RoutedEventArgs e)
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
            // Si se cumplen todos los requisitos, entrara en la accion de crear el proyecto
            if (lblErrorIdAlumno.Content == "" && lblErrorNotaDocumento.Content == "" && lblErrorNotaPresentacion.Content == "" && lblErrorNotaFinal.Content == "")
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
                // Crear proyecto
                ProyectoApi.modificarProyecto(proyecto);
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
