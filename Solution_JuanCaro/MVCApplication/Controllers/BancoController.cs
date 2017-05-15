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
    public class BancoController : Controller
    {
        public ActionResult Consulta()
        {
            var logic = new Logic.Logic_Banco();
            var model = logic.Listar_Bancos();

            return View(model);
        }

        public ActionResult Listado()
        {
            CTR_Banco o_ctr_banco = new CTR_Banco();
            var lst = o_ctr_banco.Listar_Bancos();

            return View(lst);
        }

        public ActionResult Registro()
        {
            ENT_Banco o_ent_banco = new ENT_Banco();

            return View(o_ent_banco);
        }

        public ActionResult Editar(int id)
        {
            CTR_Banco o_ctr_banco = new CTR_Banco();
            var o_ent_banco = o_ctr_banco.Listar_Banco(id);

            return View(o_ent_banco[0]);
        }

        public ActionResult Eliminar(int id)
        {
            ENT_Banco o_ent_banco = new ENT_Banco();
            o_ent_banco.Id_Banco = id;

            CTR_Banco o_ctr_banco = new CTR_Banco();
            int result = o_ctr_banco.Eliminar_Banco(o_ent_banco);

            var lst = o_ctr_banco.Listar_Bancos();

            return View("Listado", lst);
        }

        public JsonResult Guardar(string Nombre_Banco, string Direccion_Banco)
        {
            try
            {
                CTR_Banco o_ctr_banco = new CTR_Banco();

                ENT_Banco o_ent_banco = new ENT_Banco();
                o_ent_banco.Nombre_Banco = Nombre_Banco;
                o_ent_banco.Direccion_Banco = Direccion_Banco;

                int result = o_ctr_banco.Insertar_Banco(o_ent_banco);

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

        public JsonResult Actualizar(int Id_Banco, string Nombre_Banco, string Direccion_Banco)
        {
            try
            {
                CTR_Banco o_ctr_banco = new CTR_Banco();

                ENT_Banco o_ent_banco = new ENT_Banco();
                o_ent_banco.Id_Banco = Id_Banco;
                o_ent_banco.Nombre_Banco = Nombre_Banco;
                o_ent_banco.Direccion_Banco = Direccion_Banco;

                int result = o_ctr_banco.Actualizar_Banco(o_ent_banco);

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