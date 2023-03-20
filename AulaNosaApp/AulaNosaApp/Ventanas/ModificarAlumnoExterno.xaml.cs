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
    /// Lógica de interacción para ModificarAlumnoExterno.xaml
    /// </summary>
    public partial class ModificarAlumnoExterno : Window
    {
        internal ModificarAlumnoExterno(AlumnoExternoDTO alumnoExternoDTO)
        {
            InitializeComponent();
            // Tomar los atributos del elemento a editar para mostrarlos
            txtNombre.Text = alumnoExternoDTO.nombre.ToString();
        }
    
        private void Guardar_ClickAsync(object sender, RoutedEventArgs e)
        {
            
            // Si se introdujo todo correctamente
            if (txtNombre.Text.Length > 0)
            {
                // Crear objeto
                AlumnoExternoDTO cursoInsertar = new AlumnoExternoDTO();
                cursoInsertar.nombre = txtNombre.Text.ToString();
                // Editar curso
                AlumnoExternoService.EditarAlumnoExterno(cursoInsertar);
                // Cerrar ventana
                Close();
            }
        }
    }
}
