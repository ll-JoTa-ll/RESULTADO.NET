using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CONTROLADORA;
using ENTIDADES;

namespace WebApi.Controllers
{
    [RoutePrefix("banco")]
    public class BancoController : ApiController
    {
        CTR_Banco o_ctr_banco = new CTR_Banco();

        [Route("ActualizarBanco")]
        [HttpPost]
        public IHttpActionResult ActualizarBanco([FromBody] ENT_Banco p_ent_banco)
        {
            int i_result = o_ctr_banco.Actualizar_Banco(p_ent_banco);

            if (i_result == 1)
            {
                var result = new
                {
                    MENSAJE = "OK",
                    CODIGO = 0
                };

                return Ok("OK");
                //return Ok(result);
            }
            else
            {
                var result = new
                {
                    MENSAJE = "ERROR",
                    CODIGO = 1
                };

                return Ok("ERROR");
                //return Ok(result);
            }
        }

        [Route("InsertarBanco")]
        [HttpPost]
        public IHttpActionResult InsertarBanco([FromBody] ENT_Banco p_ent_banco)
        {
            int i_result = o_ctr_banco.Insertar_Banco(p_ent_banco);

            if (i_result == 1)
            {
                var result = new
                {
                    MENSAJE = "OK",
                    CODIGO = 0
                };

                return Ok("OK");
                //return Ok(result);
            }
            else
            {
                var result = new
                {
                    MENSAJE = "ERROR",
                    CODIGO = 1
                };

                return Ok("ERROR");
                //return Ok(result);
            }
        }

        [Route("EliminarBanco")]
        [HttpPost]
        public IHttpActionResult EliminarBanco([FromBody] ENT_Banco p_ent_banco)
        {
            int i_result = o_ctr_banco.Eliminar_Banco(p_ent_banco);

            if (i_result == 1)
            {
                var result = new
                {
                    MENSAJE = "OK",
                    CODIGO = 0
                };

                return Ok("OK");
                //return Ok(result);
            }
            else
            {
                var result = new
                {
                    MENSAJE = "ERROR",
                    CODIGO = 1
                };

                return Ok("ERROR");
                //return Ok(result);
            }
        }

         [HttpGet]
        [Route("ListarBancos")]
        public IHttpActionResult ListarBancos()
        {
            List<ENT_Banco> lst = new List<ENT_Banco>();
            lst = o_ctr_banco.Listar_Bancos();

            return Json(lst);
        }
    }
}