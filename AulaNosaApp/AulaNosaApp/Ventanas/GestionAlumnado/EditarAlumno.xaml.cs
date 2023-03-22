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

namespace AulaNosaApp.Ventanas.GestionAlumnado
{
    /// <summary>
    /// Lógica de interacción para EditarAlumno.xaml
    /// </summary>
    public partial class EditarAlumno : Window
    {
        public EditarAlumno(AlumnoDTO alumnoDTO)
        {
            InitializeComponent();
            // Tomar los atributos del elemento a editar para mostrarlos
            txtid.Text = alumnoDTO.id.ToString();
            txtNombre.Text = alumnoDTO.nombre.ToString();
            txtEmpresa.Text = alumnoDTO.idEmpresa.ToString();
            txtEstudios.Text = alumnoDTO.idEstudios.ToString();
            txtCurso.Text = alumnoDTO.idCurso.ToString();
        }

        private void Guardar_Click(object sender, RoutedEventArgs e)
        {


            // Si se introdujo todo correctamente
            if (txtNombre.Text.Length > 0)
            {
                int id;
                if (!int.TryParse(txtid.Text, out id))
                {
                    MessageBox.Show("El valor introducido en el campo 'Id' no es válido. Introduzca un número entero.");
                    return;
                }

                int Curso;
                if (!int.TryParse(txtCurso.Text, out Curso))
                {
                    MessageBox.Show("El valor introducido en el campo 'Curso' no es válido. Introduzca un número entero.");
                    return;
                }
                int Estudios;
                if (!int.TryParse(txtEstudios.Text, out Estudios))
                {
                    MessageBox.Show("El valor introducido en el campo 'Estudios' no es válido. Introduzca un número entero.");
                    return;
                }
                int Empresa;
                if (!int.TryParse(txtEmpresa.Text, out Empresa))
                {
                    MessageBox.Show("El valor introducido en el campo 'Empresa' no es válido. Introduzca un número entero.");
                    return;
                }
                // Crear objeto
                DateTime inicio = DateTime.Parse("2022-04-22T22:00:00.000+00:00");
                DateTime fin = DateTime.Parse("2022-04-22T22:00:00.000+00:00");
                AlumnoDTO alumnoInsertar = new AlumnoDTO();
                alumnoInsertar.id = id;
                alumnoInsertar.nombre = txtNombre.Text.ToString();
                alumnoInsertar.idCurso = Curso;
                alumnoInsertar.idEmpresa = Empresa;
                alumnoInsertar.idEstudios = Estudios;
                alumnoInsertar.inicioPr = inicio;
                alumnoInsertar.finPr = fin;
                alumnoInsertar.cv = "a";
                alumnoInsertar.carta = "a";
                // Editar alumno
                AlumnoApi.EditarAlumno(alumnoInsertar);
                // Cerrar ventana
                Close();
            }
        }
    }
}
