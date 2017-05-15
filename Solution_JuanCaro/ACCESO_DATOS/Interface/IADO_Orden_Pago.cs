using ENTIDADES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACCESO_DATOS.Interface
{
    public interface IADO_Orden_Pago
    {
        int Insertar_Orden(ENT_Orden_Pago p_ent_orden);
        int Actualizar_Orden(ENT_Orden_Pago p_ent_orden);
        int Eliminar_Orden(ENT_Orden_Pago p_ent_orden);
        List<ENT_Orden_Pago> Listar_Ordenes();
        List<ENT_Orden_Pago> Listar_Ordenes_Sucursal(int p_id_sucursal, string p_moneda);
    }
}
