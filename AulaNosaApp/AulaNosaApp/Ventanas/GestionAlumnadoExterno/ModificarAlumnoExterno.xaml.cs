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

namespace AulaNosaApp.Ventanas.GestionAlumnadoExterno
{
    /// <summary>
    /// Lógica de interacción para ModificarAlumnoExterno.xaml
    /// </summary>
    public partial class ModificarAlumnoExterno : Window
    {
        internal ModificarAlumnoExterno(AlumnoExternoDTO alumnoExternoDTO)
        {
            InitializeComponent();
            // Tomar los atributos del elemento a editar para mostrarlos
            tbxId.Text = alumnoExternoDTO.id.ToString();
            tbxNombre.Text = alumnoExternoDTO.nombre.ToString();
            tbxCorreo.Text = alumnoExternoDTO.email.ToString();
            tbxTelefono.Text = alumnoExternoDTO.telefono.ToString();
            tbxUniversidad.Text = alumnoExternoDTO.universidad.ToString();
            tbxTitulacion.Text = alumnoExternoDTO.titulacion.ToString();
            tbxEspecialidad.Text = alumnoExternoDTO.especialidad.ToString();
            tbxCurso.Text = alumnoExternoDTO.idCurso.ToString();
            tbxTipo.Text = alumnoExternoDTO.tipo.ToString();
        }

        private void Guardar_Click(object sender, RoutedEventArgs e)
        {

            // Si se introdujo todo correctamente
            if (tbxNombre.Text.Length > 0)
            {
                int id;
                if (!int.TryParse(tbxId.Text, out id))
                {
                    MessageBox.Show("El valor introducido en el campo 'Curso' no es válido. Introduzca un número entero.");
                    return;
                }

                int Curso;
                if (!int.TryParse(tbxCurso.Text, out Curso))
                {
                    MessageBox.Show("El valor introducido en el campo 'Curso' no es válido. Introduzca un número entero.");
                    return;
                }
                // Crear objeto
                AlumnoExternoDTO cursoInsertar = new AlumnoExternoDTO();
                cursoInsertar.id = id;
                cursoInsertar.nombre = tbxNombre.Text.ToString();
                cursoInsertar.email = tbxCorreo.Text.ToString();
                cursoInsertar.telefono = tbxTelefono.Text.ToString();
                cursoInsertar.universidad = tbxUniversidad.Text.ToString();
                cursoInsertar.titulacion = tbxTitulacion.Text.ToString();
                cursoInsertar.especialidad = tbxEspecialidad.Text.ToString();
                cursoInsertar.idCurso = Curso;
                cursoInsertar.tipo = tbxTipo.Text.ToString();
                cursoInsertar.inicio = "2022-04-22T22:00:00.000+00:00";
                cursoInsertar.fin = "2022-04-22T22:00:00.000+00:00";
                cursoInsertar.cv = "a";
                cursoInsertar.horario = "a";
                cursoInsertar.convenio = "a";
                cursoInsertar.evaluacion = "a";
                // Editar curso
                AlumnoExternoApi.EditarAlumnoExterno(cursoInsertar);
                // Cerrar ventana
                Close();
            }
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
