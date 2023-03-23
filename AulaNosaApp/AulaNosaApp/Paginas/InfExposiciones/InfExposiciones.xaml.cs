using AulaNosaApp.DTO;
using AulaNosaApp.Servicios;
using System;
using System.Collections;
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

namespace AulaNosaApp.Paginas.GestionExposiciones
{
    /// <summary>
    /// Lógica de interacción para GestionExposiciones.xaml
    /// </summary>
    public partial class GestionExposiciones : Page
    {
        public List<ProyectoEntregaDTO> lista;
        public GestionExposiciones()
        {
            InitializeComponent();
            RefrescarDatos();
        }

        // Refrescar lista de estudios
        private void RefrescarDatos()
        {
            lista = ProyectoEntregaApi.ListarProyectosEntrega();
            lista = new List<ProyectoEntregaDTO>();
            //lista.Clear();
            ProyectoEntregaDTO proyecto1 = new ProyectoEntregaDTO();
            proyecto1.nombre = "Pepe";
            proyecto1.fecha = new DateTime(2021,10,12);
            proyecto1.comentarios = "Esto es un comentario para rellenar el espacio en blanco que aparece en el datagrid y no se que mas poner solo quiero que llegue al final para saver si se pone debajo o si no se ve pero imagino que se pondra debajo claramente, o como diria yo mismo evidentemente " +
                "ajskidhgfjagssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss";

            ProyectoEntregaDTO proyecto2 = new ProyectoEntregaDTO();
            proyecto2.nombre = "Pepe2";
            proyecto2.fecha = new DateTime(2021, 10, 12);
            proyecto2.comentarios = "Esto es un comentario para rellenar el espacio en blanco que aparece en el datagrid y no se que mas poner solo quiero que llegue al final para saver si se pone debajo o si no se ve pero imagino que se pondra debajo claramente, o como diria yo mismo evidentemente";

            ProyectoEntregaDTO proyecto3 = new ProyectoEntregaDTO();
            proyecto3.nombre = "Pepe3";
            proyecto3.fecha = new DateTime(2021, 10, 12);
            proyecto3.comentarios = "Esto es un comentario para rellenar el espacio en blanco que aparece en el datagrid y no se que mas poner solo quiero que llegue al final para saver si se pone debajo o si no se ve pero imagino que se pondra debajo claramente, o como diria yo mismo evidentemente";

            lista.Add(proyecto1);
            lista.Add(proyecto2);
            lista.Add(proyecto3);
            this.dgListado.ItemsSource = lista;
        }
    }
}
