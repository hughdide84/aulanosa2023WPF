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

        private void btnGenerarPDF_Click(object sender, RoutedEventArgs e)
        {
            EmpresaAlumnosApi.exportarPDF(listaEmpresaAlumnos);
        }

        private void btnRefrescar_Click(object sender, RoutedEventArgs e)
        {
            refrescarEmpresaAlumnos();
        }

        void refrescarEmpresaAlumnos()
        {
            listaEmpresaAlumnos = EmpresaAlumnosApi.listarEmpresaAlumnos(1, 3);
            dgvAlumnoEmpresa.ItemsSource = null;
            dgvAlumnoEmpresa.Items.Clear();
            dgvAlumnoEmpresa.ItemsSource = listaEmpresaAlumnos;
        }
    }
}
