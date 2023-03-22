using AulaNosaApp.DTO.AdministracionCursos;
using AulaNosaApp.DTO;
using AulaNosaApp.Servicios;
using AulaNosaApp.Servicios.AdministracionCursos;
using AulaNosaApp.Util;
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

namespace AulaNosaApp.Ventanas.AdministracionEmpresas
{
    /// <summary>
    /// Lógica de interacción para EmpresaEditar.xaml
    /// </summary>
    public partial class EmpresaEditar : Window
    {
        List<CursoDTO> cursos = null;
        List<EstudioDTO> estudios = null;

        public EmpresaEditar()
        {
            InitializeComponent();
            cargarCursos();
            cargarEstudios();
            cargarCampos();
        }

        // Función que llama a la API para cargar los cursos en una lista (`cursos') y los nombres de estos ('nombresCurso') en otra
        void cargarCursos()
        {
            List<String> nombresCursos = new List<string>();

            cursos = CursosApi.listarCursos();

            foreach (CursoDTO curso in cursos)
            {
                nombresCursos.Add(curso.nombre);
            }

            cbCursos.ItemsSource = nombresCursos;
        }

        // Función que llama a la API para cargar los estudios en una lista (`estudios') y los nombres de estos ('nombresEstudios') en otra
        void cargarEstudios()
        {
            List<String> nombresEstudios = new List<string>();

            estudios = EstudioApi.ListarEstudios();

            foreach (EstudioDTO estudio in estudios)
            {
                nombresEstudios.Add(estudio.nombre);
            }

            cbEstudios.ItemsSource = nombresEstudios;
        }

        // Función que verifica que los campos no estén vacíos
        void cargarCampos()
        {
            cbCursos.SelectedValue = CursosApi.filtrarCursoId(Statics.empresaSeleccionada.idCurso.ToString()).nombre;
            cbEstudios.SelectedValue = EstudioApi.filtrarEstudioId(Statics.empresaSeleccionada.idEstudios.ToString()).nombre;
            tbxNombre.Text = Statics.empresaSeleccionada.nombre;
            tbxDireccionSocial.Text = Statics.empresaSeleccionada.direccionSocial;
            tbxDireccionTrabajo.Text = Statics.empresaSeleccionada.direccionTrabajo;
            tbxCIF.Text = Statics.empresaSeleccionada.cif;
            tbxRepresentante.Text = Statics.empresaSeleccionada.representante;
            tbxContacto.Text = Statics.empresaSeleccionada.contacto;
            tbxTutor1.Text = Statics.empresaSeleccionada.tutor1;
            tbxTutor2.Text = Statics.empresaSeleccionada.tutor2;
            tbxTutor3.Text = Statics.empresaSeleccionada.tutor3;
            tbxConvenio.Text = Statics.empresaSeleccionada.convenio.ToString();
            tbxPlanIndividual.Text = Statics.empresaSeleccionada.planIndividual.ToString();
            tbxHojaActividades.Text = Statics.empresaSeleccionada.hojaActividades.ToString();
        }

        // Función que verifica que los campos no estén vacíos
        bool validarCampos()
        {
            if (tbxNombre.Text.Length > 0 && tbxDireccionSocial.Text.Length > 0 && tbxDireccionTrabajo.Text.Length > 0 && tbxCIF.Text.Length > 0 && tbxRepresentante.Text.Length > 0
                && tbxContacto.Text.Length > 0 && tbxTutor1.Text.Length > 0 && tbxTutor2.Text.Length > 0 && tbxTutor3.Text.Length > 0 && tbxConvenio.Text.Length > 0
                && tbxPlanIndividual.Text.Length > 0 && tbxHojaActividades.Text.Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        // Botón que al accionarse cierra la plantilla de creación de empresas
        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        // Botón que al accionarse, en función de la validez de los campos, se modifica o no una empresa en la BD
        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            if (tbxNombre.Text.Length == 0)
            {
                lblErrorNombre.Content = "Campo vacío";
            }
            else
            {
                lblErrorNombre.Content = "";
            }

            if (tbxDireccionSocial.Text.Length == 0)
            {
                lblErrortbxDireccionSocial.Content = "Campo vacío";
            }
            else
            {
                lblErrortbxDireccionSocial.Content = "";
            }

            if (tbxDireccionTrabajo.Text.Length == 0)
            {
                lblErrortbxDireccionTrabajo.Content = "Campo vacío";
            }
            else
            {
                lblErrortbxDireccionTrabajo.Content = "";
            }

            if (tbxCIF.Text.Length == 0)
            {
                lblErrortbxCIF.Content = "Campo vacío";
            }
            else
            {
                lblErrortbxCIF.Content = "";
            }

            if (tbxRepresentante.Text.Length == 0)
            {
                lblErrortbxRepresentante.Content = "Campo vacío";
            }
            else
            {
                lblErrortbxRepresentante.Content = "";
            }

            if (tbxContacto.Text.Length == 0)
            {
                lblErrortbxContacto.Content = "Campo vacío";
            }
            else
            {
                lblErrortbxContacto.Content = "";
            }

            if (tbxTutor1.Text.Length == 0)
            {
                lblErrortbxTutor1.Content = "Campo vacío";
            }
            else
            {
                lblErrortbxTutor1.Content = "";
            }

            if (tbxTutor2.Text.Length == 0)
            {
                lblErrortbxTutor2.Content = "Campo vacío";
            }
            else
            {
                lblErrortbxTutor2.Content = "";
            }

            if (tbxTutor3.Text.Length == 0)
            {
                lblErrortbxTutor3.Content = "Campo vacío";
            }
            else
            {
                lblErrortbxTutor3.Content = "";
            }

            if (tbxConvenio.Text.Length == 0)
            {
                lblErrortbxConvenio.Content = "Campo vacío";
            }
            else
            {
                lblErrortbxConvenio.Content = "";
            }

            if (tbxPlanIndividual.Text.Length == 0)
            {
                lblErrortbxPlanIndividual.Content = "Campo vacío";
            }
            else
            {
                lblErrortbxPlanIndividual.Content = "";
            }

            if (tbxHojaActividades.Text.Length == 0)
            {
                lblErrortbxHojaActividades.Content = "Campo vacío";
            }
            else
            {
                lblErrortbxHojaActividades.Content = "";
            }

            if (validarCampos())
            {
                EmpresaDTO empresa = new EmpresaDTO();
                empresa.id = Statics.empresaSeleccionada.id;
                empresa.idCurso = cursos[cbCursos.SelectedIndex].id;
                empresa.idEstudios = estudios[cbEstudios.SelectedIndex].id;
                empresa.nombre = tbxNombre.Text;
                empresa.direccionSocial = tbxDireccionSocial.Text;
                empresa.direccionTrabajo = tbxDireccionTrabajo.Text;
                empresa.cif = tbxCIF.Text;
                empresa.representante = tbxRepresentante.Text;
                empresa.contacto = tbxContacto.Text;
                empresa.tutor1 = tbxTutor1.Text;
                empresa.tutor2 = tbxTutor2.Text;
                empresa.tutor3 = tbxTutor3.Text;
                empresa.convenio = tbxConvenio.Text.ToCharArray()[0];
                empresa.planIndividual = tbxPlanIndividual.Text.ToCharArray()[0];
                empresa.hojaActividades = tbxHojaActividades.Text.ToCharArray()[0];

                EmpresaAPI.editarEmpresa(empresa);

                Close();
            }
            else
            {

            }
        }
    }
}
