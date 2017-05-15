using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACCESO_DATOS.Interface;
using ACCESO_DATOS;
using ENTIDADES;

namespace CONTROLADORA
{
    public class CTR_Orden_Pago
    {
        static readonly string provider = "Ado.Net";
        static readonly IADO_Factory factory = ADO_Factories.GetFactory(provider);

        static readonly IADO_Orden_Pago o_ado_orden_pago = factory.ADO_Orden_Pago;

        public CTR_Orden_Pago()
        {
        }

        public int Actualizar_Orden(ENT_Orden_Pago p_ent_orden)
        {
            return o_ado_orden_pago.Actualizar_Orden(p_ent_orden);
        }

        public int Eliminar_Orden(ENT_Orden_Pago p_ent_orden)
        {
            return o_ado_orden_pago.Eliminar_Orden(p_ent_orden);
        }

        public int Insertar_Orden(ENT_Orden_Pago p_ent_orden)
        {
            return o_ado_orden_pago.Insertar_Orden(p_ent_orden);
        }

        public List<ENT_Orden_Pago> Listar_Ordenes()
        {
            return o_ado_orden_pago.Listar_Ordenes();
        }

        public List<ENT_Orden_Pago> Listar_Ordenes_Sucursal(int p_id_sucursal, string p_moneda)
        {
            return o_ado_orden_pago.Listar_Ordenes_Sucursal(p_id_sucursal, p_moneda);
        }
    }
}
