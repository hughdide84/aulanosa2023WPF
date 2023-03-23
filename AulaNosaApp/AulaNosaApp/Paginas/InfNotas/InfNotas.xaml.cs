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

namespace AulaNosaApp.Paginas.InfNotas
{
    /// <summary>
    /// Lógica de interacción para InfNotas.xaml
    /// </summary>
    public partial class InfNotas : Page
    {
        List<ProyectoDTO> proyectos;
        public InfNotas()
        {
            InitializeComponent();
        }

        // Boton de refrescar la lista de proyectos
        private void btnRefrescar_Click(object sender, RoutedEventArgs e)
        {
            refrescarProyectos();
        }

        // Boton de generar PDF
        private void btnGenerarPDF_Click(object sender, RoutedEventArgs e)
        {
            ProyectoApi.exportarPDF(proyectos);
        }

        // Refrescar lista proyectos
        void refrescarProyectos()
        {
            proyectos = ProyectoApi.listarProyectos();
            dgvAlumnoEmpresa.ItemsSource = null;
            dgvAlumnoEmpresa.Items.Clear();
            dgvAlumnoEmpresa.ItemsSource = proyectos;
        }
    }
}
