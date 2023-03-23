using AulaNosaApp.DTO;
using AulaNosaApp.DTO.AdministracionCursos;
using AulaNosaApp.Servicios;
using AulaNosaApp.Servicios.AdministracionCursos;
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

namespace AulaNosaApp.Ventanas.GestionAlumnadoExterno
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
            tbxId.Text = alumnoExternoDTO.id.ToString();
            tbxNombre.Text = alumnoExternoDTO.nombre.ToString();
            tbxCorreo.Text = alumnoExternoDTO.email.ToString();
            tbxTelefono.Text = alumnoExternoDTO.telefono.ToString();
            tbxUniversidad.Text = alumnoExternoDTO.universidad.ToString();
            tbxTitulacion.Text = alumnoExternoDTO.titulacion.ToString();
            tbxEspecialidad.Text = alumnoExternoDTO.especialidad.ToString();
            tbxCurso.Text = alumnoExternoDTO.idCurso.ToString();
            if(alumnoExternoDTO.tipo.ToString() == "M")
            {
                tbxTipo.SelectedIndex = 0;
            }else if(alumnoExternoDTO.tipo.ToString() == "O")
            {
                tbxTipo.SelectedIndex = 1;
            }
            dtpInicio.Text = alumnoExternoDTO.inicio.ToString();
            dtpFin.Text = alumnoExternoDTO.fin.ToString();
            chbCv.IsChecked = alumnoExternoDTO.cv.Equals("a");
            chbHorario.IsChecked = alumnoExternoDTO.horario.Equals("a");
            chbConvenio.IsChecked = alumnoExternoDTO.convenio.Equals("a");
            chbEvaluacion.IsChecked = alumnoExternoDTO.evaluacion.Equals("a");
        }

        private void Guardar_Click(object sender, RoutedEventArgs e)
        {

            // Si se introdujo todo correctamente
            if (tbxNombre.Text.Length > 0)
            {
                int id;
                if (!int.TryParse(tbxId.Text, out id))
                {
                    MessageBox.Show("El valor introducido en el campo 'Curso' no es válido. Introduzca un número entero.");
                    return;
                }

                int Curso;
                if (!int.TryParse(tbxCurso.Text, out Curso))
                {
                    MessageBox.Show("El valor introducido en el campo 'Curso' no es válido. Introduzca un número entero.");
                    return;
                }
                // Crear objeto
                AlumnoExternoDTO alumnoExternoInsertar = new AlumnoExternoDTO();
                alumnoExternoInsertar.id = id;
                alumnoExternoInsertar.nombre = tbxNombre.Text.ToString();
                alumnoExternoInsertar.email = tbxCorreo.Text.ToString();
                alumnoExternoInsertar.telefono = tbxTelefono.Text.ToString();
                alumnoExternoInsertar.universidad = tbxUniversidad.Text.ToString();
                alumnoExternoInsertar.titulacion = tbxTitulacion.Text.ToString();
                alumnoExternoInsertar.especialidad = tbxEspecialidad.Text.ToString();
                alumnoExternoInsertar.idCurso = Curso;
                CursoDTO curso = CursosApi.filtrarCursoId(Curso.ToString());
                if (curso == null)
                {
                    MessageBox.Show("El curso indicado no existe. Por favor, seleccione un curso válido.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (tbxTipo.SelectedIndex == 0)
                {
                    alumnoExternoInsertar.tipo = "M";
                }
                else if (tbxTipo.SelectedIndex == 1)
                {
                    alumnoExternoInsertar.tipo = "O";
                }
                try
                {
                    alumnoExternoInsertar.inicio = DateTime.Parse(dtpInicio.Text);
                    alumnoExternoInsertar.fin = DateTime.Parse(dtpFin.Text);

                    if (alumnoExternoInsertar.fin <= alumnoExternoInsertar.inicio)
                    {
                        MessageBox.Show("La fecha de finalización debe ser posterior a la de inicio.");
                        return;
                    }
                }
                catch (FormatException ex)
                {
                    MessageBox.Show("Formato incorrecto: " + ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                if ((bool)chbCv.IsChecked)
                {
                    alumnoExternoInsertar.cv = "a";
                }
                else
                {
                    alumnoExternoInsertar.cv = "b";
                }
                if ((bool)chbHorario.IsChecked)
                {
                    alumnoExternoInsertar.horario = "a";
                }
                else
                {
                    alumnoExternoInsertar.horario = "b";
                }
                if ((bool)chbConvenio.IsChecked)
                {
                    alumnoExternoInsertar.convenio = "a";
                }
                else
                {
                    alumnoExternoInsertar.convenio = "b";
                }
                if ((bool)chbEvaluacion.IsChecked)
                {
                    alumnoExternoInsertar.evaluacion = "a";
                }
                else
                {
                    alumnoExternoInsertar.evaluacion = "b";
                }
                // Editar alumnno externo
                AlumnoExternoApi.EditarAlumnoExterno(alumnoExternoInsertar);
                // Cerrar ventana
                Close();
            }
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
