using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Mvc.Routing;
using CONTROLADORA;
using ENTIDADES;


namespace MVCApplication.Controllers
{
    public class SucursalController : Controller
    {
        public ActionResult Listado()
        {
            CTR_Sucursal o_ctr_sucursal = new CTR_Sucursal();
            var lst = o_ctr_sucursal.Listar_Sucursales();

            return View(lst);
        }

        public ActionResult Registro()
        {
            ENT_Sucursal o_ent_sucursal = new ENT_Sucursal();

            CTR_Banco o_ctr_banco = new CTR_Banco();
            o_ent_sucursal.Lst_Bancos = o_ctr_banco.Listar_Bancos();

            return View(o_ent_sucursal);
        }

        public ActionResult Editar(int id)
        {
            CTR_Sucursal o_ctr_sucursal = new CTR_Sucursal();
            var o_ent_sucursal = o_ctr_sucursal.Listar_Sucursal(id)[0];

            CTR_Banco o_ctr_banco = new CTR_Banco();
            o_ent_sucursal.Lst_Bancos = o_ctr_banco.Listar_Bancos();

            return View(o_ent_sucursal);
        }

        public ActionResult Eliminar(int id)
        {
            ENT_Sucursal o_ent_sucursal = new ENT_Sucursal();
            o_ent_sucursal.Id_Sucursal = id;

            CTR_Sucursal o_ctr_sucursal = new CTR_Sucursal();
            int result = o_ctr_sucursal.Eliminar_Sucursal(o_ent_sucursal);

            var lst = o_ctr_sucursal.Listar_Sucursales();

            return View("Listado", lst);
        }

        public JsonResult Guardar(string Nombre_Sucursal, string Direccion_Sucursal, int Id_Banco)
        {
            try
            {
                CTR_Sucursal o_ctr_sucursal = new CTR_Sucursal();

                ENT_Sucursal o_ent_sucursal = new ENT_Sucursal();
                o_ent_sucursal.Nombre_Sucursal = Nombre_Sucursal;
                o_ent_sucursal.Direccion_Sucursal = Direccion_Sucursal;
                o_ent_sucursal.Id_Banco = Id_Banco;

                int result = o_ctr_sucursal.Insertar_Sucursal(o_ent_sucursal);

                if (result == 1)
                {
                    var result_json = new
                    {
                        CODIGO = 0,
                        MENSAJE = "OK"
                    };

                    return Json(result_json, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var result_json = new
                    {
                        CODIGO = 1,
                        MENSAJE = "ERROR"
                    };

                    return Json(result_json, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                var result_json = new
                {
                    CODIGO = -1,
                    MENSAJE = ex.Message
                };

                return Json(result_json, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult Actualizar(int Id_Sucursal, string Nombre_Sucursal, string Direccion_Sucursal, int Id_Banco)
        {
            try
            {
                CTR_Sucursal o_ctr_sucursal = new CTR_Sucursal();

                ENT_Sucursal o_ent_sucursal = new ENT_Sucursal();
                o_ent_sucursal.Id_Sucursal = Id_Sucursal;
                o_ent_sucursal.Nombre_Sucursal = Nombre_Sucursal;
                o_ent_sucursal.Direccion_Sucursal = Direccion_Sucursal;

                int result = o_ctr_sucursal.Actualizar_Sucursal(o_ent_sucursal);

                if (result == 1)
                {
                    var result_json = new
                    {
                        CODIGO = 0,
                        MENSAJE = "OK"
                    };

                    return Json(result_json, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var result_json = new
                    {
                        CODIGO = 1,
                        MENSAJE = "ERROR"
                    };

                    return Json(result_json, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                var result_json = new
                {
                    CODIGO = -1,
                    MENSAJE = ex.Message
                };

                return Json(result_json, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
