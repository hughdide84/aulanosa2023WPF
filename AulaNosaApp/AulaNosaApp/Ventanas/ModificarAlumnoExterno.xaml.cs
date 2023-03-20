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
            lblid.Text = alumnoExternoDTO.id.ToString();
            txtNombre.Text = alumnoExternoDTO.nombre.ToString();
            txtCorreo.Text = alumnoExternoDTO.email.ToString();
            txtTelefono.Text = alumnoExternoDTO.telefono.ToString();
            txtUniversidad.Text = alumnoExternoDTO.universidad.ToString();
            txtTitulacion.Text = alumnoExternoDTO.titulacion.ToString();
            txtEspecialidad.Text = alumnoExternoDTO.especialidad.ToString();
            txtCurso.Text = alumnoExternoDTO.idCurso.ToString();
            txtTipo.Text = alumnoExternoDTO.tipo.ToString();
        }
    
        private void Guardar_Click(object sender, RoutedEventArgs e)
        {
            
            // Si se introdujo todo correctamente
            if (txtNombre.Text.Length > 0)
            {
                int id;
                if (!int.TryParse(lblid.Text, out id))
                {
                    MessageBox.Show("El valor introducido en el campo 'Curso' no es válido. Introduzca un número entero.");
                    return;
                }
                int Curso;
                if (!int.TryParse(txtCurso.Text, out Curso))
                {
                    MessageBox.Show("El valor introducido en el campo 'Curso' no es válido. Introduzca un número entero.");
                    return;
                }
                // Crear objeto
                AlumnoExternoDTO cursoInsertar = new AlumnoExternoDTO();
                cursoInsertar.id = id;
                cursoInsertar.nombre = txtNombre.Text.ToString();
                cursoInsertar.email = txtCorreo.Text.ToString();
                cursoInsertar.telefono = txtTelefono.Text.ToString();
                cursoInsertar.universidad = txtUniversidad.Text.ToString();
                cursoInsertar.titulacion = txtTitulacion.Text.ToString();
                cursoInsertar.especialidad = txtEspecialidad.Text.ToString();
                cursoInsertar.idCurso = Curso;
                cursoInsertar.tipo = txtTipo.Text.ToString();
                cursoInsertar.inicio = "2022-04-22T22:00:00.000+00:00";
                cursoInsertar.fin = "2022-04-22T22:00:00.000+00:00";
                cursoInsertar.cv = "a";
                cursoInsertar.horario = "a";
                cursoInsertar.convenio = "a";
                cursoInsertar.evaluacion = "a";
                // Editar curso
                AlumnoExternoService.EditarAlumnoExterno(cursoInsertar);
                // Cerrar ventana
                Close();
            }
        }
    }
}
