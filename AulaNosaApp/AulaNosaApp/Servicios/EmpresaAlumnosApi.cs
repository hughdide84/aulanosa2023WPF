using AulaNosaApp.DTO;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AulaNosaApp.Util;
using RestSharp;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.IO.Font;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Kernel.Colors;
using iText.IO.Font.Constants;
using System.Windows.Media;

namespace AulaNosaApp.Servicios
{
    public class EmpresaAlumnosApi
    {
        static RestClient client;
        static RestRequest request;

        // Listar todos los emprea-alumnos
        public static List<EmpresaAlumnosDTO> listarEmpresaAlumnos(int idCurso, int idEstudio)
        {
            client = new RestClient(Constantes.client);
            request = new RestRequest("/api/empresa/alumno/" + idCurso.ToString() + "/" + idEstudio.ToString(), Method.Get);
            var response = client.Execute<List<EmpresaAlumnosDTO>>(request);
            var apiResponse = response.Data;
            return apiResponse;
        }

        // Exportar a PDF
        public static void exportarPDF(List<EmpresaAlumnosDTO> empresaAlumnosLista)
        {
            try
            {
                String fichero = "";
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.CheckFileExists = false;
                openFileDialog.Filter = "PDF (*.pdf)|*.pdf";
                if (openFileDialog.ShowDialog() == true)
                    fichero = openFileDialog.FileName;
                else
                    return;
                PdfWriter writer = new PdfWriter(fichero);

                PdfDocument pdf = new PdfDocument(writer);
                Document document = new Document(pdf);
                PdfFont font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
                PdfFont bold = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);

                iText.Layout.Element.Paragraph header = new iText.Layout.Element.Paragraph("INFORME EMPRESA - ALUMNOS").SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetFontSize(20);
                document.Add(header);
                LineSeparator ls = new LineSeparator(new SolidLine());
                document.Add(ls);
                iText.Layout.Element.Paragraph subheader = new iText.Layout.Element.Paragraph("").SetFontSize(10);
                document.Add(subheader);

                iText.Layout.Element.Table table = new iText.Layout.Element.Table(2).SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);

                table.AddCell(new iText.Layout.Element.Paragraph("EMPRESA").SetFont(bold).SetFontColor(DeviceRgb.WHITE).SetBackgroundColor(backgroundColor: (DeviceRgb)new BrushConverter().ConvertFrom("#1A17A1")).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));
                table.AddCell(new iText.Layout.Element.Paragraph("ALUMNOS").SetFont(bold).SetFontColor(DeviceRgb.WHITE).SetBackgroundColor(backgroundColor: (DeviceRgb)new BrushConverter().ConvertFrom("#1A17A1")).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));

                int cont = 0;

                
                foreach (EmpresaAlumnosDTO empresaAlumno in empresaAlumnosLista)
                {
                    table.AddCell(new iText.Layout.Element.Paragraph(empresaAlumno.nombreEmpresa.ToString()).SetFont(font).SetBackgroundColor(cont % 2 == 0 ? (DeviceRgb)new BrushConverter().ConvertFrom("#FFFFFF") : (DeviceRgb)new BrushConverter().ConvertFrom("#E6E6E6")).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));
                    table.AddCell(new iText.Layout.Element.Paragraph(empresaAlumno.nombreAlumno).SetFont(font).SetBackgroundColor(cont % 2 == 0 ? (DeviceRgb)new BrushConverter().ConvertFrom("#FFFFFF") : (DeviceRgb)new BrushConverter().ConvertFrom("#E6E6E6")).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));

                    cont++;
                }

                document.Add(table);
                document.Close();

                MessageBox.Show("Informe generado correctamente.", "Informe generado", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido crear el fichero. Verifique que no esté en uso.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
    }
}
