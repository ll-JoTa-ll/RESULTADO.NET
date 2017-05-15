using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Data;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace MVCApplication.Helpers
{
    public class HelperREST
    {
        public static HttpClient GetCliente(String Url)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

        public static String ObtenerStringResultadoJSON<T>(String Url, String controlador, String accion, T objeto)
        {
            String resultado = String.Empty;
            using (var cliente = GetCliente(Url))
            {
                cliente.DefaultRequestHeaders.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = cliente.PostAsJsonAsync(controlador + "/" + accion, objeto).Result;
                if (response.IsSuccessStatusCode)
                    resultado = response.Content.ReadAsStringAsync().Result.Replace("\"", "");
            }
            return resultado;
        }
    }
}