﻿using AulaNosaApp.DTO;
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

namespace AulaNosaApp.Paginas.InfEmpresas
{
    /// <summary>
    /// Lógica de interacción para InfEmpresas.xaml
    /// </summary>
    public partial class InfEmpresas : Page
    {
        List<EmpresaDTO> listaEmpresas;
        public InfEmpresas()
        {
            InitializeComponent();
            refrescarEmpresasDisponibles();
        }

        private void btnRefrescar_Click(object sender, RoutedEventArgs e)
        {
            refrescarEmpresasDisponibles();
        }

        private void btnGenerarPDF_Click(object sender, RoutedEventArgs e)
        {
            EmpresaPFC.exportarPDF(listaEmpresas);
        }

        void refrescarEmpresasDisponibles()
        {
            listaEmpresas = EmpresaPFC.ListarEmpresas();
            dgvEmpresaDisponible.ItemsSource = null;
            dgvEmpresaDisponible.Items.Clear();
            dgvEmpresaDisponible.ItemsSource = listaEmpresas;
        }
    }
}
