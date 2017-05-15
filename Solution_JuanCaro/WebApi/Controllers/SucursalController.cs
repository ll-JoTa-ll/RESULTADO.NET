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
    [RoutePrefix("sucursal")]
    public class SucursalController : ApiController
    {
        CTR_Sucursal o_ctr_sucursal = new CTR_Sucursal();

        [Route("ActualizarSucursal")]
        [HttpPost]
        public IHttpActionResult ActualizarSucursal([FromBody] ENT_Sucursal p_ent_sucursal)
        {
            int i_result = o_ctr_sucursal.Actualizar_Sucursal(p_ent_sucursal);

            if (i_result == 1)
            {
                var result = new
                {
                    MENSAJE = "OK",
                    CODIGO = 0
                };

                return Ok(result);
            }
            else
            {
                var result = new
                {
                    MENSAJE = "ERROR",
                    CODIGO = 1
                };

                return Ok(result);
            }
        }

        [Route("InsertarSucursal")]
        [HttpPost]
        public IHttpActionResult InsertarSucursal([FromBody] ENT_Sucursal p_ent_sucursal)
        {
            int i_result = o_ctr_sucursal.Insertar_Sucursal(p_ent_sucursal);

            if (i_result == 1)
            {
                var result = new
                {
                    MENSAJE = "OK",
                    CODIGO = 0
                };

                return Ok(result);
            }
            else
            {
                var result = new
                {
                    MENSAJE = "ERROR",
                    CODIGO = 1
                };

                return Ok(result);
            }
        }

        [Route("EliminarSucursal")]
        [HttpPost]
        public IHttpActionResult EliminarSucursal([FromBody] ENT_Sucursal p_ent_sucursal)
        {
            int i_result = o_ctr_sucursal.Eliminar_Sucursal(p_ent_sucursal);

            if (i_result == 1)
            {
                var result = new
                {
                    MENSAJE = "OK",
                    CODIGO = 0
                };

                return Ok(result);
            }
            else
            {
                var result = new
                {
                    MENSAJE = "ERROR",
                    CODIGO = 1
                };

                return Ok(result);
            }
        }

        [HttpGet]
        [Route("ListarSucursales")]
        public IHttpActionResult ListarSucursales()
        {
            List<ENT_Sucursal> lst = new List<ENT_Sucursal>();
            lst = o_ctr_sucursal.Listar_Sucursales();

            return Json(lst);
        }
    }
}
