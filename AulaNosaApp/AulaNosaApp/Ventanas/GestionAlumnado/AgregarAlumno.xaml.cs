using AulaNosaApp.DTO;
using AulaNosaApp.DTO.AdministracionCursos;
using AulaNosaApp.Servicios;
using AulaNosaApp.Servicios.AdministracionCursos;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Globalization;
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
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace AulaNosaApp.Ventanas.GestionAlumnado
{
    /// <summary>
    /// Lógica de interacción para AgregarAlumno.xaml
    /// </summary>
    public partial class AgregarAlumno : Window
    {
        public AgregarAlumno()
        {
            InitializeComponent();
        }
        AlumnoDTO alumno = new AlumnoDTO();
        private async void Guardar_Click(object sender, RoutedEventArgs e)
        {
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
            alumno.nombre = txtNombre.Text;


            try
            {
                alumno.inicioPr = DateTime.Parse(DPInicio.Text);
                alumno.finPr = DateTime.Parse(DPFinal.Text);

                if (alumno.finPr <= alumno.inicioPr)
                {
                    MessageBox.Show("La fecha de finalización debe ser posterior a la de inicio.");
                    return;
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Formato incorrecto: " + ex.Message);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return;
            }
            alumno.idCurso = Curso;
            CursoDTO curso = CursosApi.filtrarCursoId(Curso.ToString());
            if (curso == null)
            {
                MessageBox.Show("El curso indicado no existe. Por favor, seleccione un curso válido.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            alumno.idEmpresa = Empresa;
            EmpresaDTO empresa = EmpresaAPI.consultarEmpresaId(Empresa);
            if (empresa == null)
            {
                MessageBox.Show("La empresa indicada no existe. Por favor, seleccione una empresa válida.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            alumno.idEstudios = Estudios;
            EstudioDTO estudio = new EstudioDTO();
            estudio.id = Estudios;

            estudio = EstudioApi.filtrarEstudioId(Estudios.ToString());

            if (estudio == null)
            {
                MessageBox.Show("El estudio introducido no existe. Introduzca un idEstudios válido.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }




            if (string.IsNullOrEmpty(alumno.nombre))
            {
                // Mostrar un mensaje de error indicando que el nombre del alumno es obligatorio
                MessageBox.Show("El nombre del alumno es obligatorio", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if ((bool)chbxCv.IsChecked)
            {
                alumno.cv = "a";
            }
            else
            {
                alumno.cv = "b";
            }
            if ((bool)chbxCarta.IsChecked)
            {
                alumno.carta = "a";
            }
            else
            {
                alumno.carta = "b";
            }

            string v = AlumnoApi.AgregarAlumno(alumno);

            this.Close();

        }
    }
}
