using AulaNosaApp.DTO;
using AulaNosaApp.DTO.AdministracionCursos;
using AulaNosaApp.Util;
using iText.IO.Font.Constants;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Element;
using Microsoft.Win32;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace AulaNosaApp.Servicios
{
    public class ProyectoApi
    {
        static RestClient client;
        static RestRequest request;

        // Listar todos los proyectos
        public static List<ProyectoDTO> listarProyectos()
        {
            client = new RestClient(Constantes.client);
            request = new RestRequest("/api/proyectos", Method.Get);
            var response = client.Execute<List<ProyectoDTO>>(request);
            var apiResponse = response.Data;
            return apiResponse;
        }

        // Crear proyecto
        public static void crearProyecto(ProyectoDTO proyecto)
        {
            client = new RestClient(Constantes.client);
            request = new RestRequest("/api/proyectos/alta", Method.Post);
            request.AddJsonBody(proyecto);
            var response = client.Execute<ProyectoDTO>(request);
            MessageBox.Show("Proyecto creado", "Exito", MessageBoxButton.OK);
        }

        // Modificar proyecto
        public static void modificarProyecto(ProyectoDTO proyecto)
        {
            client = new RestClient(Constantes.client);
            request = new RestRequest("/api/proyectos", Method.Put);
            request.AddJsonBody(proyecto);
            var response = client.Execute<ProyectoDTO>(request);
            MessageBox.Show("Proyecto modificado", "Exito", MessageBoxButton.OK);
        }

        // Eliminar proyecto
        public static void eliminarProyecto(int idProyecto)
        {
            client = new RestClient(Constantes.client);
            request = new RestRequest("/api/proyectos/" + idProyecto, Method.Delete);
            var response = client.Execute(request);
        }

        // Buscar proyecto por ID
        public static ProyectoDTO filtrarProyectoId(int idProyecto)
        {
            client = new RestClient(Constantes.client);
            request = new RestRequest("/api/proyectos/" + idProyecto, Method.Get);
            var response = client.Execute<ProyectoDTO>(request);
            var apiResponse = response.Data;
            return apiResponse;
        }

        // Exportar a PDF
        public static void exportarPDF(List<ProyectoDTO> proyectos)
        {
            try
            {
                String fichero = "";
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.CheckFileExists = false;
                openFileDialog.Filter = "PDF (*.pdf)|*.pdf";
                if (openFileDialog.ShowDialog() == true)
                {
                    fichero = openFileDialog.FileName;
                }
                else
                {
                    return;
                }

                PdfWriter writer = new PdfWriter(fichero);

                PdfDocument pdf = new PdfDocument(writer);
                Document document = new Document(pdf);
                PdfFont font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
                PdfFont bold = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);

                iText.Layout.Element.Paragraph header = new iText.Layout.Element.Paragraph("INFORME NOTAS - PROYECTOS").SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).SetFontSize(20);
                document.Add(header);
                LineSeparator ls = new LineSeparator(new SolidLine());
                document.Add(ls);
                iText.Layout.Element.Paragraph subheader = new iText.Layout.Element.Paragraph("").SetFontSize(10);
                document.Add(subheader);

                iText.Layout.Element.Table table = new iText.Layout.Element.Table(4);

                table.AddCell(new iText.Layout.Element.Paragraph("ALUMNO").SetFont(bold).SetBackgroundColor(ColorConstants.LIGHT_GRAY).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));
                table.AddCell(new iText.Layout.Element.Paragraph("NOTA DOCUMENTACIÓN").SetFont(bold).SetBackgroundColor(ColorConstants.LIGHT_GRAY).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));
                table.AddCell(new iText.Layout.Element.Paragraph("NOTA PRESENTACIÓN").SetFont(bold).SetBackgroundColor(ColorConstants.LIGHT_GRAY).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));
                table.AddCell(new iText.Layout.Element.Paragraph("NOTA FINAL").SetFont(bold).SetBackgroundColor(ColorConstants.LIGHT_GRAY).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));

                foreach (ProyectoDTO proyecto in proyectos)
                {
                    table.AddCell(new iText.Layout.Element.Paragraph(proyecto.nombreAlumno).SetFont(font).SetBackgroundColor(ColorConstants.WHITE).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));
                    table.AddCell(new iText.Layout.Element.Paragraph(proyecto.notaDoc.ToString()).SetFont(font).SetBackgroundColor(ColorConstants.WHITE).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));
                    table.AddCell(new iText.Layout.Element.Paragraph(proyecto.notaPres.ToString()).SetFont(font).SetBackgroundColor(ColorConstants.WHITE).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));
                    table.AddCell(new iText.Layout.Element.Paragraph(proyecto.notaFinal.ToString()).SetFont(font).SetBackgroundColor(ColorConstants.WHITE).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));
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
