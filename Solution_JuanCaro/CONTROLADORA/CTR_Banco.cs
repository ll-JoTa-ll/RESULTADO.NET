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
    public class CTR_Banco
    {
        static readonly string provider = "Ado.Net";
        static readonly IADO_Factory factory = ADO_Factories.GetFactory(provider);

        static readonly IADO_Banco o_ado_banco = factory.ADO_Banco;

        public CTR_Banco()
        {
        }

        public int Actualizar_Banco(ENT_Banco p_ent_banco)
        {
            return o_ado_banco.Actualizar_Banco(p_ent_banco);
        }

        public int Eliminar_Banco(ENT_Banco p_ent_banco)
        {
            return o_ado_banco.Eliminar_Banco(p_ent_banco);
        }

        public int Insertar_Banco(ENT_Banco p_ent_banco)
        {
            return o_ado_banco.Insertar_Banco(p_ent_banco);
        }

        public List<ENT_Banco> Listar_Bancos()
        {
            return o_ado_banco.Listar_Bancos();
        }

        public List<ENT_Banco> Listar_Banco(int p_id_banco)
        {
            return o_ado_banco.Listar_Banco(p_id_banco);
        }
    }
}
