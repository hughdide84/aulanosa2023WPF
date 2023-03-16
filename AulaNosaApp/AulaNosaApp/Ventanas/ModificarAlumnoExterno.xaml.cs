﻿using AulaNosaApp.DTO;
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
using System.Windows.Shapes;

namespace AulaNosaApp.Ventanas
{
    /// <summary>
    /// Lógica de interacción para ModificarAlumnoExterno.xaml
    /// </summary>
    public partial class ModificarAlumnoExterno : Window
    {
        AlumnoExternoDTO alumnoExternoDTO = new AlumnoExternoDTO();
        public int idAlumno = 1;
        public ModificarAlumnoExterno(int idAlumno)
        {
            InitializeComponent();

            this.idAlumno = idAlumno;

            // Cargar los datos del alumno con el id proporcionado
            AlumnoExterno alumno = alumnoExternoDTO.ObtenerAlumnoPorId(idAlumno);
            if (alumno != null)
            {
                txtNombre.Text = alumno.Nombre;
                txtCorreo.Text = alumno.Email;
                txtTelefono.Text = alumno.Telefono;
                txtUniversidad.Text = alumno.Universidad;
                txtTitulacion.Text = alumno.Titulacion;
                txtEspecialidad.Text = alumno.Especialidad;
                txtCurso.Text = alumno.IdCurso.ToString();
            }
        }

        public ModificarAlumnoExterno()
        {
        }

        private void Guardar_Click(object sender, RoutedEventArgs e)
        {
            AlumnoExterno alumnoAModificar = alumnoExternoDTO.ObtenerAlumnoPorId(idAlumno);

            if (alumnoAModificar != null)
            {
                // Crear un nuevo objeto Alumno con los valores de los controles de la ventana
                AlumnoExterno alumnoModificado = new AlumnoExterno
                {
                    id = idAlumno,
                    Nombre = txtNombre.Text,
                    Email = txtCorreo.Text,
                    Telefono = txtTelefono.Text,
                    Universidad = txtUniversidad.Text,
                    Titulacion = txtTitulacion.Text,
                    Especialidad = txtEspecialidad.Text,
                    IdCurso = alumnoAModificar.IdCurso
                };

                // Modificar los datos del alumno en la lista de alumnos
                alumnoExternoDTO.ModificarAlumno(alumnoModificado);
            }

            // Cerrar la ventana de modificación
            this.Close();
        }

        private void btnAtras_Click(object sender, RoutedEventArgs e)
        {
            // Obtener el id del alumno actual
            int idActual = idAlumno;

            // Obtener el id del alumno anterior
            int idAnterior = alumnoExternoDTO.ObtenerIdAlumnoAnterior(idActual);

            // Si no hay alumno anterior, salir del método
            if (idAnterior == -1) return;

            // Cargar los datos del alumno anterior
            alumnoExternoDTO.ObtenerAlumnoPorId(idAnterior);
        }

        private void btnAdelante_Click(object sender, RoutedEventArgs e)
        {
            // Obtener el id del alumno actual
            int idActual = idAlumno;

            // Obtener el id del alumno siguiente
            int idSiguiente = alumnoExternoDTO.ObtenerIdAlumnoSiguiente(idActual);

            // Si no hay alumno siguiente, salir del método
            if (idSiguiente == -1) return;

            // Cargar los datos del alumno anterior
            alumnoExternoDTO.ObtenerAlumnoPorId(idSiguiente);
        }
        
    }
}