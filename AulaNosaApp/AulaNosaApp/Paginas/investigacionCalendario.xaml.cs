using AulaNosaApp.DTO;
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

namespace AulaNosaApp.Paginas
{
    /// <summary>
    /// Lógica de interacción para investigacionCalendario.xaml
    /// </summary>
    public partial class investigacionCalendario : Page
    {
        public investigacionCalendario()
        {
            InitializeComponent();
            generarCalendario();
        }

        private void generarCalendario() 
        {
            for (int i = 0; i < 1; i ++) {
                RowDefinition row = new RowDefinition();
                row.Height = new GridLength(30);
                grdLista.RowDefinitions.Add(row);

                AlumnoDTO alumno = new AlumnoDTO();
                alumno.nombre = "Federico Laurencio Elidoro";
                alumno.inicioPr = new DateTime(2023, 9, 19);
                alumno.finPr = new DateTime(2023, 11, 5);


                Border border = new Border();
                border.Background = new SolidColorBrush(Colors.Red);
                border.CornerRadius = new CornerRadius(15);
                border.Margin = new Thickness(calcularComienzo(alumno),3,0,3);
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
                tbkFechaInicio.Text = alumno.inicioPr.Day.ToString() + "/" + alumno.inicioPr.Month.ToString() + "/" + alumno.inicioPr.Year.ToString();
                tbkFechaInicio.Margin = new Thickness(20,0,10,0);
                tbkFechaInicio.Style = (Style) this.FindResource("fechasNombre");
                
                Grid.SetColumn(tbkFechaInicio, 0);
                grid.Children.Add(tbkFechaInicio);
                
                TextBlock tbkNombre = new TextBlock();
                tbkNombre.Text = alumno.nombre;
                tbkNombre.Style = (Style)this.FindResource("fechasNombre");
                tbkNombre.FontWeight = FontWeights.Bold;

                Grid.SetColumn(tbkNombre, 1);
                grid.Children.Add(tbkNombre);

                TextBlock tbkFechaFinal = new TextBlock();
                tbkFechaFinal.Text = alumno.finPr.Day.ToString() + "/" + alumno.finPr.Month.ToString() + "/" + alumno.finPr.Year.ToString();
                tbkFechaFinal.Margin = new Thickness(10, 0, 20, 0);
                tbkFechaFinal.Style = (Style)this.FindResource("fechasNombre");

                Grid.SetColumn(tbkFechaFinal, 2);
                grid.Children.Add(tbkFechaFinal);

                border.Child = grid;

                Grid.SetColumn(border, 1);
                Grid.SetRow(border, 2);

                grdLista.Children.Add(border);
            }
        
        
        }
        
        private int calcularComienzo(AlumnoDTO alumno)
        {
            int mesInicio = alumno.inicioPr.Month;
            int diaInicio = alumno.inicioPr.Day;
            int aInicio = alumno.inicioPr.Year; //es el año
            int numeroDiasMesInicio = calcularDias(aInicio, mesInicio);

            int mesFinal = alumno.finPr.Month;
            int diaFinal = alumno.finPr.Day;

            Trace.WriteLine("pixel inicio: " + ((mesInicio >= 9 ? mesInicio - 9 : 9 - mesInicio) * 200).ToString());
            Trace.WriteLine("diferencia meses: " + (((mesFinal >= 9 ? mesFinal - 9 : 3 + mesFinal) * 200) - (((mesInicio >= 9 ? mesInicio - 9 : 3 + mesInicio) * 200))).ToString());
            //calcula el pixel donde comienza el mes y añade el porcentaje de pixeles que se corresponden con el numero de dias que han pasado de ese mes
            return ((mesInicio >= 9 ? mesInicio - 9 : 3 + mesInicio) * 200) + ((100 * diaInicio) / numeroDiasMesInicio) * 2;


        }

        private int calcularFinal(AlumnoDTO alumno) 
        {
            int mesInicio = alumno.inicioPr.Month;
            int diaInicio = alumno.inicioPr.Day;
            int aInicio = alumno.inicioPr.Year; //es el año
            int numeroDiasMesInicio = calcularDias(aInicio, mesInicio);

            int mesFinal = alumno.finPr.Month;
            int diaFinal = alumno.finPr.Day;
            int aFinal = alumno.finPr.Year;
            int numeroDiasMesFinal = calcularDias(aFinal, mesFinal);


            //calcula el numero de pixeles restantes del mes inicial los suma al numero de meses y le añade el porcentaje de pixeles que se corresponden con el numnero de dias que han pasado desde el comienzo de mes
            return 200 - (((100 * diaInicio) / numeroDiasMesInicio) * 2) + (((mesFinal >= 9 ? mesFinal - 9 : 3 + mesFinal) * 200) - (((mesInicio >= 9 ? mesInicio - 9 : 3 + mesInicio) * 200))) -200 + (((100 * diaFinal) / numeroDiasMesFinal) * 2);

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
