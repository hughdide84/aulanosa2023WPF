using AulaNosaApp.DTO;
using AulaNosaApp.DTO.AdministracionCursos;
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
    /// Lógica de interacción para EmpresaAlta.xaml
    /// </summary>
    public partial class EmpresaAlta : Window
    {
        List<CursoDTO> cursos = null;
        List<EstudioDTO> estudios = null;

        public EmpresaAlta()
        {
            InitializeComponent();
        }
        
        // Función que verifica que los campos no estén vacíos
        bool validarCampos()
        {
            if (tbxNombre.Text.Length > 0 && tbxDireccionSocial.Text.Length > 0 && tbxDireccionTrabajo.Text.Length > 0 && tbxCIF.Text.Length > 0 && tbxRepresentante.Text.Length > 0
                && tbxContacto.Text.Length > 0 && tbxTutor1.Text.Length > 0 && tbxTutor2.Text.Length > 0 && tbxTutor3.Text.Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Botón que al accionarse, en función de la validez de los campos, almacena o no una nueva empresa en la BD
        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
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

            if (validarCampos())
            {
                EmpresaDTO empresa = new EmpresaDTO();
                empresa.idCurso = Statics.idCursoElegido;
                empresa.idEstudios = Statics.idEstudioElegido;
                empresa.nombre = tbxNombre.Text;
                empresa.direccionSocial = tbxDireccionSocial.Text;
                empresa.direccionTrabajo = tbxDireccionTrabajo.Text;
                empresa.cif = tbxCIF.Text;
                empresa.representante = tbxRepresentante.Text;
                empresa.contacto = tbxContacto.Text;
                empresa.tutor1 = tbxTutor1.Text;
                empresa.tutor2 = tbxTutor2.Text;
                empresa.tutor3 = tbxTutor3.Text;

                if (tbxConvenio.IsChecked == true)
                {
                    empresa.convenio = 'S';
                }
                else
                {
                    empresa.convenio = 'N';
                }

                if (tbxPlanIndividual.IsChecked == true)
                {
                    empresa.planIndividual = 'S';
                }
                else
                {
                    empresa.planIndividual = 'N';
                }

                if (tbxHojaActividades.IsChecked == true)
                {
                    empresa.hojaActividades = 'S';
                }
                else
                {
                    empresa.hojaActividades = 'N';
                }

                EmpresaAPI.crearEmpresa(empresa);

                Close();
            }
            else
            {

            }
        }

        // Botón que al accionarse cierra la plantilla de creación de empresas
        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
