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
using System.Windows.Shapes;

namespace AulaNosaApp.Ventanas
{
    /// <summary>
    /// Lógica de interacción para EstudiosAlta.xaml
    /// </summary>
    public partial class EstudioAlta : Window
    {
        public EstudioAlta()
        {
            InitializeComponent();
        }

        private void Cancelar(object sender, RoutedEventArgs e)
        {
            string mensaje = "Va a abandonar la pantalla sin guardar las modificaciones, ¿está seguro?";
            string titulo = "Confirmación";
            if (!tbxNombre.Text.Equals(""))
            {
                if (MessageBox.Show(mensaje, titulo, MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
                    this.Close();
            }
            else
            {
                this.Close();
            }
        }

        private void Aceptar(object sender, RoutedEventArgs e)
        {
            tbkErrores.Visibility = Visibility.Hidden;
            EstudioDTO estudio = new EstudioDTO();
            estudio.nombre = tbxNombre.Text;
            estudio.fct = (bool)chbFct.IsChecked ? true : false;
            estudio.pext = (bool)chbPext.IsChecked ? true : false;
            string errores = EstudioApi.AltaEstudio(estudio);

            if (!errores.Equals(""))
            {
                tbkErrores.Text = errores;
                tbkErrores.Visibility = Visibility.Visible;
            }
            else
            {
                Close();
            }
        }
    }
}