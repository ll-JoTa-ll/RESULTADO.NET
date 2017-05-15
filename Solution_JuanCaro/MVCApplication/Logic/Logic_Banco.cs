using MVCApplication.Helpers;
using MVCApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVCApplication.Logic
{
    public class Logic_Banco
    {
        public string Insertar_Banco(BancoModel param)
        {
            string URL = "http://localhost:40142/";

            var resultado = Helpers.HelperREST.ObtenerStringResultadoJSON
                                                                                                                            (
                                                                                                                                URL,
                                                                                                                                "banco",
                                                                                                                                "InsertarBanco",
                                                                                                                                param
                                                                                                                            );
            return resultado;
        }

        public string Actualizar_Banco(BancoModel param)
        {
            string URL = "http://localhost:40142/";

            var resultado = Helpers.HelperREST.ObtenerStringResultadoJSON
                                                                                                                            (
                                                                                                                                URL,
                                                                                                                                "banco",
                                                                                                                                "ActualizarBanco",
                                                                                                                                param
                                                                                                                            );
            return resultado;
        }

        public string Eliminar_Banco(BancoModel param)
        {
            string URL = "http://localhost:40142/";

            var resultado = Helpers.HelperREST.ObtenerStringResultadoJSON
                                                                                                                            (
                                                                                                                                URL,
                                                                                                                                "banco",
                                                                                                                                "EliminarBanco",
                                                                                                                                param
                                                                                                                            );
            return resultado;
        }

        public List<BancoModel> Listar_Bancos()
        {
            string URL = "http://localhost:40142/";

            using (var client = Helpers.HelperREST.GetCliente(URL))
            {
                var lst = client.GetAsync(String.Format("ListarBancos"))
                                      .Result
                                      .Content.ReadAsAsync<List<Models.BancoModel>>().Result;

                return lst;
            }
        }
    }
}