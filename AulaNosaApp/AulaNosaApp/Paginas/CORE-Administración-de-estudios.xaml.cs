using AulaNosaApp.DTO;
using AulaNosaApp.Servicios;
using AulaNosaApp.Ventanas;
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
        public List<EstudioDTO> lista;
        public ObservableCollection<EstudioDTO> listaGrid { get; set; }

        public CORE_Administración_de_estudios()
        {
            InitializeComponent();
            
        }

        private void RefrescarDatos() {
            lista = EstudioApi.ListarEstudios();
            this.dgListado.ItemsSource = lista;
        }

        private void btnRefrescar_Click(object sender, RoutedEventArgs e)
        {
            RefrescarDatos();
        }

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            EstudioAlta pantalla = new EstudioAlta();
            pantalla.ShowDialog();
            RefrescarDatos();
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            EstudioDTO estudio = dgListado.SelectedItem as EstudioDTO;

            if (estudio != null) {
                EstudioEditar pantalla = new EstudioEditar(estudio);
                pantalla.ShowDialog();
                RefrescarDatos();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un estudio", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            EstudioDTO estudio = dgListado.SelectedItem as EstudioDTO;

            if (estudio != null)
            {
                EstudioApi.EliminarEstudio(estudio.id);
                RefrescarDatos();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un estudio", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
