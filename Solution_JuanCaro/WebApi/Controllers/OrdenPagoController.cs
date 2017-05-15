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
    [RoutePrefix("ordenPago")]
    public class OrdenPagoController : ApiController
    {
        CTR_Orden_Pago o_ctr_orden = new CTR_Orden_Pago();

        [Route("ActualizarOrden")]
        [HttpPost]
        public IHttpActionResult ActualizarOrden([FromBody] ENT_Orden_Pago p_ent_orden)
        {
            int i_result = o_ctr_orden.Actualizar_Orden(p_ent_orden);

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

        [Route("InsertarOrden")]
        [HttpPost]
        public IHttpActionResult InsertarOrden([FromBody] ENT_Orden_Pago p_ent_orden)
        {
            int i_result = o_ctr_orden.Insertar_Orden(p_ent_orden);

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

        [Route("EliminarOrden")]
        [HttpPost]
        public IHttpActionResult EliminarOrden([FromBody] ENT_Orden_Pago p_ent_orden)
        {
            int i_result = o_ctr_orden.Eliminar_Orden(p_ent_orden);

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
        [Route("ListarOrdenes")]
        public IHttpActionResult ListarOrdenes()
        {
            List<ENT_Orden_Pago> lst = new List<ENT_Orden_Pago>();
            lst = o_ctr_orden.Listar_Ordenes();

            return Json(lst);
        }

        [HttpGet]
        [Route("ListarOrdenesSucursal/{SUCURSAL}/{MONEDA}")]
        public IHttpActionResult ListarOrdenesSucursal(int SUCURSAL, string MONEDA)
        {
            List<ENT_Orden_Pago> lst = new List<ENT_Orden_Pago>();
            lst = o_ctr_orden.Listar_Ordenes_Sucursal(SUCURSAL, MONEDA);

            return Json(lst);
        }
    }
}