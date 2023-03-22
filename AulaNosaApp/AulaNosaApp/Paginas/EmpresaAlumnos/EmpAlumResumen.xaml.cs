using AulaNosaApp.DTO;
using AulaNosaApp.Servicios;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AulaNosaApp.Paginas.EmpresaAlumnos
{
    /// <summary>
    /// Lógica de interacción para EmpAlumResumen.xaml
    /// </summary>
    public partial class EmpAlumResumen : Page
    {
        List<EmpresaAlumnosDTO> listaEmpresaAlumnos;
        public EmpAlumResumen()
        {
            InitializeComponent();
            refrescarEmpresaAlumnos();
        }

        // Boton de refrescar la lista de empresa-alumnos
        private void btnRefrescar_Click(object sender, RoutedEventArgs e)
        {
            refrescarEmpresaAlumnos();
        }

        // Boton de generar PDF
        private void btnGenerarPDF_Click(object sender, RoutedEventArgs e)
        {
            EmpresaAlumnosApi.exportarPDF(listaEmpresaAlumnos);
        }

        // Refrescar lista empresa-alumnos
        void refrescarEmpresaAlumnos()
        {
            listaEmpresaAlumnos = EmpresaAlumnosApi.listarEmpresaAlumnos(Statics.idCursoElegido, Statics.idEstudioElegido);
            dgvAlumnoEmpresa.ItemsSource = null;
            dgvAlumnoEmpresa.Items.Clear();
            dgvAlumnoEmpresa.ItemsSource = listaEmpresaAlumnos;
        }
    }
}
