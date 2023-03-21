using AulaNosaApp.DTO;
using AulaNosaApp.Servicios;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace AulaNosaApp.Paginas.CalendarioFEXT
{
    /// <summary>
    /// Lógica de interacción para CalendarioFEXT.xaml
    /// </summary>
    public partial class CalendarioFEXT : Page
    {
        private List<string> colores = new List<string>
        {
            "#FF69B4", "#FFD700", "#FFA07A", "#00FFFF", "#FF00FF",
            "#00FF00", "#FF1493", "#FFFF00", "#00FF7F", "#FF4500",
            "#FF6347", "#FF8C00", "#FF7F50", "#00FA9A", "#FFC0CB",
            "#FFDAB9", "#ADFF2F", "#FFB6C1", "#BA55D3", "#FF00CC"
        };
        public CalendarioFEXT()
        {
            InitializeComponent();
            generarCalendario();
        }
        private void generarCalendario()
        {
            List<AlumnoExternoDTO> alumnos = AlumnoExternoApi.ListarAlumnosExternos();
            alumnos.Clear();

            AlumnoExternoDTO alumno1 = new AlumnoExternoDTO();
            alumno1.inicio = new DateTime(2018, 1, 13);
            alumno1.fin = new DateTime(2018, 2, 10);
            alumno1.nombre = "Pepe";

            AlumnoExternoDTO alumno2 = new AlumnoExternoDTO();
            alumno2.inicio = new DateTime(2017, 10, 10);
            alumno2.fin = new DateTime(2018, 2, 23);
            alumno2.nombre = "Lurencio";

            AlumnoExternoDTO alumno3 = new AlumnoExternoDTO();
            alumno3.inicio = new DateTime(2018, 3, 20);
            alumno3.fin = new DateTime(2018, 5, 10);
            alumno3.nombre = "Parafleudio";

            alumnos.Add(alumno1);
            alumnos.Add(alumno2);
            alumnos.Add(alumno3);

            int nuncolor = 0;
            for (int i = 0; i < alumnos.Count; i++)
            {

                AlumnoExternoDTO alumno = alumnos[i];

                RowDefinition row = new RowDefinition();
                row.Height = new GridLength(30);
                grdLista.RowDefinitions.Add(row);

                Border border = new Border();
                border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(colores[nuncolor]));
                nuncolor++;
                if (nuncolor == colores.Count)
                {
                    nuncolor = 0;
                }
                border.CornerRadius = new CornerRadius(15);
                border.Margin = new Thickness(calcularComienzo(alumno), 3, 0, 3);
                border.Width = calcularFinal(alumno);
                border.HorizontalAlignment = HorizontalAlignment.Left;

                Grid grid = new Grid();
                grid.VerticalAlignment = VerticalAlignment.Center;

                ColumnDefinition cln1 = new ColumnDefinition();
                cln1.Width = new GridLength(100);
                grid.ColumnDefinitions.Add(cln1);

                ColumnDefinition cln2 = new ColumnDefinition();
                grid.ColumnDefinitions.Add(cln2);

                ColumnDefinition cln3 = new ColumnDefinition();
                cln3.Width = new GridLength(100);
                grid.ColumnDefinitions.Add(cln3);

                TextBlock tbkFechaInicio = new TextBlock();
                tbkFechaInicio.Text = alumno.inicio.Day.ToString() + "/" + alumno.inicio.Month.ToString() + "/" + alumno.inicio.Year.ToString();
                tbkFechaInicio.Margin = new Thickness(20, 0, 10, 0);
                tbkFechaInicio.Style = (Style)this.FindResource("fechasNombre");

                Grid.SetColumn(tbkFechaInicio, 0);
                grid.Children.Add(tbkFechaInicio);

                TextBlock tbkNombre = new TextBlock();
                tbkNombre.Text = alumno.nombre;
                tbkNombre.Style = (Style)this.FindResource("fechasNombre");
                tbkNombre.FontWeight = FontWeights.Bold;

                Grid.SetColumn(tbkNombre, 1);
                grid.Children.Add(tbkNombre);

                TextBlock tbkFechaFinal = new TextBlock();
                tbkFechaFinal.Text = alumno.fin.Day.ToString() + "/" + alumno.fin.Month.ToString() + "/" + alumno.fin.Year.ToString();
                tbkFechaFinal.Margin = new Thickness(10, 0, 20, 0);
                tbkFechaFinal.Style = (Style)this.FindResource("fechasNombre");

                Grid.SetColumn(tbkFechaFinal, 2);
                grid.Children.Add(tbkFechaFinal);

                border.Child = grid;

                Grid.SetRow(border, i + 1);

                grdLista.Children.Add(border);
            }


        }

        private int calcularComienzo(AlumnoExternoDTO alumno)
        {
            int mesInicio = alumno.inicio.Month;
            int diaInicio = alumno.inicio.Day;
            int aInicio = alumno.inicio.Year; //es el año
            int numeroDiasMesInicio = calcularDias(aInicio, mesInicio);

            int mesFinal = alumno.fin.Month;
            int diaFinal = alumno.fin.Day;

            Trace.WriteLine("pixel inicio: " + ((mesInicio >= 9 ? mesInicio - 9 : 9 - mesInicio) * 200).ToString());
            Trace.WriteLine("diferencia meses: " + (((mesFinal >= 9 ? mesFinal - 9 : 3 + mesFinal) * 200) - (((mesInicio >= 9 ? mesInicio - 9 : 3 + mesInicio) * 200))).ToString());
            //calcula el pixel donde comienza el mes y añade el porcentaje de pixeles que se corresponden con el numero de dias que han pasado de ese mes
            return ((mesInicio >= 9 ? mesInicio - 9 : 3 + mesInicio) * 200) + ((100 * diaInicio) / numeroDiasMesInicio) * 2;


        }

        private int calcularFinal(AlumnoExternoDTO alumno)
        {
            int mesInicio = alumno.inicio.Month;
            int diaInicio = alumno.inicio.Day;
            int aInicio = alumno.inicio.Year; //es el año
            int numeroDiasMesInicio = calcularDias(aInicio, mesInicio);

            int mesFinal = alumno.fin.Month;
            int diaFinal = alumno.fin.Day;
            int aFinal = alumno.fin.Year;
            int numeroDiasMesFinal = calcularDias(aFinal, mesFinal);


            //calcula el numero de pixeles restantes del mes inicial los suma al numero de meses y le añade el porcentaje de pixeles que se corresponden con el numnero de dias que han pasado desde el comienzo de mes
            return 200 - (((100 * diaInicio) / numeroDiasMesInicio) * 2) + (((mesFinal >= 9 ? mesFinal - 9 : 3 + mesFinal) * 200) - (((mesInicio >= 9 ? mesInicio - 9 : 3 + mesInicio) * 200))) - 200 + (((100 * diaFinal) / numeroDiasMesFinal) * 2);

        }
        private int calcularDias(int a, int mesInicio)
        {
            return mesInicio == 2 ? esBisiesto(a) : mesInicio % 2 != 0 ? 31 : 30; //calcula los dias de cada mes
        }
        private int esBisiesto(int a)
        {
            return a % 4 == 0 && a % 100 != 0 || a % 400 == 0 ? 29 : 28; //calcula si es bisiesto
        }
        private int generarColorAleatorio()
        {
            return 1;
        }
    }
}

