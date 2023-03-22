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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AulaNosaApp.Paginas.AlumnoEmpresa
{
    /// <summary>
    /// Lógica de interacción para AlumEmpResumen.xaml
    /// </summary>
    public partial class AlumEmpResumen : Page
    {

        List<AlumnoEmpresaDTO> listaAlumnoEmpresa;

        public AlumEmpResumen()
        {
            InitializeComponent();
            refrescarAlumnoEmpresa();
        }

        // Boton de refrescar la lista de alumno-empresa
        private void btnRefrescar_Click(object sender, RoutedEventArgs e)
        {
            refrescarAlumnoEmpresa();
        }

        // Boton de generar PDF
        private void btnGenerarPDF_Click(object sender, RoutedEventArgs e)
        {
            AlumnoEmpresaApi.exportarPDF(listaAlumnoEmpresa);
        }

        // Refrescar lista alumno-empresa
        void refrescarAlumnoEmpresa()
        {
            listaAlumnoEmpresa = AlumnoEmpresaApi.listarAlumnoEmpresa(1, 3);
            dgvAlumnoEmpresa.ItemsSource = null;
            dgvAlumnoEmpresa.Items.Clear();
            dgvAlumnoEmpresa.ItemsSource = listaAlumnoEmpresa;
        }

    }
}
