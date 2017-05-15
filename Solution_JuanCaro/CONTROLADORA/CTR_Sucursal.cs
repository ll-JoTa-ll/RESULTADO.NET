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
    public class CTR_Sucursal
    {
        static readonly string provider = "Ado.Net";
        static readonly IADO_Factory factory = ADO_Factories.GetFactory(provider);

        static readonly IADO_Sucursal o_ado_sucursal = factory.ADO_Sucursal;

        public CTR_Sucursal()
        {
        }

        public int Actualizar_Sucursal(ENT_Sucursal p_ent_sucursal)
        {
            return o_ado_sucursal.Actualizar_Sucursal(p_ent_sucursal);
        }

        public int Eliminar_Sucursal(ENT_Sucursal p_ent_sucursal)
        {
            return o_ado_sucursal.Eliminar_Sucursal(p_ent_sucursal);
        }

        public int Insertar_Sucursal(ENT_Sucursal p_ent_sucursal)
        {
            return o_ado_sucursal.Insertar_Sucursal(p_ent_sucursal);
        }

        public List<ENT_Sucursal> Listar_Sucursales()
        {
            return o_ado_sucursal.Listar_Sucursales();
        }

        public List<ENT_Sucursal> Listar_Sucursal(int p_id_sucursal)
        {
            return o_ado_sucursal.Listar_Sucursal(p_id_sucursal);
        }

        public List<ENT_Sucursal> Listar_Sucursales_Banco(int p_id_banco)
        {
            return o_ado_sucursal.Listar_Sucursales_Banco(p_id_banco);
        }
    }
}
