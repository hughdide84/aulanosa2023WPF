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

        bool documento = false;
        bool presentacion = false;

        public ProyectoModificar()
        {
            InitializeComponent();
            // Tomar los atributos del elemento a editar para mostrarlos
            tbxId.Text = Statics.proyectoSeleccionado.id.ToString();
            tbxIdAlumno.Text = Statics.proyectoSeleccionado.idalumno.ToString();
            if (Statics.proyectoSeleccionado.documento == 's')
            {
                btnEditarDocumento.Content = "Inserta un documento";
                btnEditarDocumento.IsEnabled = true;
            }
            else
            {
                btnEditarDocumento.Content = "Insertado";
                btnEditarDocumento.IsEnabled = false;
            }
            if (Statics.proyectoSeleccionado.presentacion == 's')
            {
                btnEditarPresentacion.Content = "Inserta una presentacion";
                btnEditarPresentacion.IsEnabled = true;
            }
            else
            {
                btnEditarPresentacion.Content = "Insertado";
                btnEditarPresentacion.IsEnabled = false;
            }
            tbxNotaDocumento.Text = Statics.proyectoSeleccionado.notadocumento.ToString();
            tbxNotaPresentacion.Text = Statics.proyectoSeleccionado.notapresentacion.ToString();
            tbxNotaFinal.Text = Statics.proyectoSeleccionado.notafinal.ToString();
        }

        // Accion al modificar un documento
        private void btnEditarDocumento_Click(object sender, RoutedEventArgs e)
        {
            if (btnEditarDocumento.IsEnabled == false)
            {
                btnEditarDocumento.Content = "Inserta un documento";
                btnEditarDocumento.IsEnabled = true;
            }
            else 
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Archivos PDF (*.pdf)|*.pdf";

                if (openFileDialog.ShowDialog() == true)
                {
                    documento = true;
                    btnEditarDocumento.Content = "Insertado";
                    btnEditarDocumento.IsEnabled = false;
                }
            }
        }

        // Accion al modificar una presentacion
        private void btnEditarPresentacion_Click(object sender, RoutedEventArgs e)
        {
            if (btnEditarPresentacion.IsEnabled == false)
            {
                btnEditarPresentacion.Content = "Inserta una presentacion";
                btnEditarPresentacion.IsEnabled = true;
            }
            else
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Archivos PDF (*.pdf)|*.pdf";

                if (openFileDialog.ShowDialog() == true)
                {
                    presentacion = true;
                    btnEditarPresentacion.Content = "Insertado";
                    btnEditarPresentacion.IsEnabled = false;
                }
            }
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
            // Verificar que se introdujo una nota de documentacion de dos caracteres o mas
            if (tbxNotaDocumento.Text.Length == 0)
            {
                lblErrorNotaDocumento.Content = "Nota vacia";
            }
            else if (tbxNotaDocumento.Text.Length > 2)
            {
                lblErrorNotaDocumento.Content = "Máximo dos dígitos de nota de documentación";
            }
            else
            {
                lblErrorNotaDocumento.Content = "";
            }
            // Verificar que se introdujo una nota de presentacion de dos caracteres o mas
            if (tbxNotaPresentacion.Text.Length == 0)
            {
                lblErrorNotaPresentacion.Content = "Nota vacia";
            }
            else if (tbxNotaPresentacion.Text.Length > 2)
            {
                lblErrorNotaPresentacion.Content = "Máximo dos dígitos de nota de presentacion";
            }
            else
            {
                lblErrorNotaPresentacion.Content = "";
            }
            // Verificar que se introdujo una nota final de dos caracteres o mas
            if (tbxNotaFinal.Text.Length == 0)
            {
                lblErrorNotaFinal.Content = "Nota vacia";
            }
            else if (tbxNotaFinal.Text.Length > 2)
            {
                lblErrorNotaFinal.Content = "Máximo dos dígitos de nota final";
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
                proyecto.idalumno = int.Parse(tbxIdAlumno.Text);
                if (documento)
                {
                    proyecto.documento = 's';
                }
                else
                {
                    proyecto.documento = 'a';
                }
                if (presentacion)
                {
                    proyecto.presentacion = 's';
                }
                else
                {
                    proyecto.presentacion = 'a';
                }
                proyecto.notadocumento = int.Parse(tbxNotaDocumento.Text);
                proyecto.notapresentacion = int.Parse(tbxNotaPresentacion.Text);
                proyecto.notafinal = int.Parse(tbxNotaFinal.Text);
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
    }
}
