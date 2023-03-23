using AulaNosaApp.DTO;
using AulaNosaApp.DTO.AdministracionCursos;
using AulaNosaApp.Util;
using Org.BouncyCastle.Asn1.Ocsp;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AulaNosaApp.Servicios
{
    public class PagosApi
    {
        static RestClient client;
        static RestRequest request;

        // Listar todos los pagos
        public static List<PagoDTO> listarPagos()
        {
            client = new RestClient(Constantes.client);
            request = new RestRequest("/api/pagos", Method.Get);
            var response = client.Execute<List<PagoDTO>>(request);
            var apiResponse = response.Data;
            return apiResponse;
        }

        // Listar los pagos de un ID concreto
        public static List<PagoDTO> listarPagosIdMatricula(int id)
        {
            List<PagoDTO> listaPagos = listarPagos();
            List<PagoDTO> listaPagosId = new List<PagoDTO>();
            if (listaPagos != null) { 
            foreach (PagoDTO pago in listaPagos)
            {
                if (pago.idMatricula == id)
                {
                    listaPagosId.Add(pago);
                }
            }
            }
            return listaPagosId;
        }

        // Crear pago
        public static void crearPago(PagoDTO pago)
        {
            client = new RestClient(Constantes.client);
            request = new RestRequest("/api/pagos", Method.Post);
            request.AddJsonBody(pago);
            client.Execute<PagoDTO>(request);
            MessageBox.Show("Pago creado", "Exito", MessageBoxButton.OK);
        }

        // Editar pago
        public static void editarPago(PagoDTO pago)
        {
            client = new RestClient(Constantes.client);
            request = new RestRequest("/api/pagos", Method.Put);
            request.AddJsonBody(pago);
            client.Execute<PagoDTO>(request);
            MessageBox.Show("Pago modificado", "Exito", MessageBoxButton.OK);
        }
    }
}
