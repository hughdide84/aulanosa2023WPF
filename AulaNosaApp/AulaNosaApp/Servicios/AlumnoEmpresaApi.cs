using AulaNosaApp.DTO;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.IO.Font;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Kernel.Colors;
using iText.IO.Font.Constants;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;
using AulaNosaApp.Util;
using Org.BouncyCastle.Asn1.Ocsp;
using RestSharp;

namespace AulaNosaApp.Servicios
{
    public class AlumnoEmpresaApi
    {
        static RestClient client;
        static RestRequest request;

        public static List<AlumnoEmpresaDTO> listarAlumnoEmpresa(int idCurso, int idEstudio)
        {
            client = new RestClient(Constantes.client);
            request = new RestRequest("/api/alumno/empresa/"+idCurso.ToString()+"/"+idEstudio.ToString(), Method.Get);
            var response = client.Execute<List<AlumnoEmpresaDTO>>(request);
            var apiResponse = response.Data;
            return apiResponse;
        }

        public static void exportarPDF(List<AlumnoEmpresaDTO> alumnoEmpresaLista)
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

                iText.Layout.Element.Paragraph header = new iText.Layout.Element.Paragraph("INFORME ALUMNO - EMPRESA").SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetFontSize(20);
                document.Add(header);
                LineSeparator ls = new LineSeparator(new SolidLine());
                document.Add(ls);
                iText.Layout.Element.Paragraph subheader = new iText.Layout.Element.Paragraph("").SetFontSize(10);
                document.Add(subheader);

                iText.Layout.Element.Table table = new iText.Layout.Element.Table(2);

                table.AddCell(new iText.Layout.Element.Paragraph("ALUMNO").SetFont(bold).SetBackgroundColor(ColorConstants.LIGHT_GRAY).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));
                table.AddCell(new iText.Layout.Element.Paragraph("EMPRESA").SetFont(bold).SetBackgroundColor(ColorConstants.LIGHT_GRAY).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));

                foreach (AlumnoEmpresaDTO alumnoEmpresa in alumnoEmpresaLista)
                {
                    table.AddCell(new iText.Layout.Element.Paragraph(alumnoEmpresa.nombreAlumno).SetFont(font).SetBackgroundColor(ColorConstants.WHITE).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));
                    table.AddCell(new iText.Layout.Element.Paragraph(alumnoEmpresa.nombreEmpresa).SetFont(font).SetBackgroundColor(ColorConstants.WHITE).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));
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
