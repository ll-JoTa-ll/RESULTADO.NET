using ENTIDADES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACCESO_DATOS.Interface
{
    public interface IADO_Sucursal
    {
        int Insertar_Sucursal(ENT_Sucursal p_ent_sucursal);
        int Actualizar_Sucursal(ENT_Sucursal p_ent_sucursal);
        int Eliminar_Sucursal(ENT_Sucursal p_ent_sucursal);
        List<ENT_Sucursal> Listar_Sucursales();
        List<ENT_Sucursal> Listar_Sucursal(int p_id_sucursal);
        List<ENT_Sucursal> Listar_Sucursales_Banco(int p_id_banco);
    }
}
