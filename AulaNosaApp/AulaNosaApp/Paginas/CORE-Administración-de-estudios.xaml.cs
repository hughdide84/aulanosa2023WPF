using AulaNosaApp.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace AulaNosaApp.Paginas
{
    /// <summary>
    /// Lógica de interacción para CORE_Administración_de_estudios.xaml
    /// </summary>
    public partial class CORE_Administración_de_estudios : Page
    {
        public List<EstudiosDTO> lista;
        public ObservableCollection<EstudiosDTO> listaGrid { get; set; }

        public CORE_Administración_de_estudios()
        {
            InitializeComponent();
            
        }

        private void RefrescarDatos() {
            lista = EstudiosApi.ListarEstudios();
            this.dgListado.ItemsSource = lista;
        }

        private void btnRefrescar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
