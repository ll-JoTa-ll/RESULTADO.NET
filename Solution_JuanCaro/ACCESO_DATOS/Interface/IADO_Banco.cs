using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDADES;

namespace ACCESO_DATOS.Interface
{
    public interface IADO_Banco
    {
        int Insertar_Banco(ENT_Banco p_ent_banco);
        int Actualizar_Banco(ENT_Banco p_ent_banco);
        int Eliminar_Banco(ENT_Banco p_ent_banco);
        List<ENT_Banco> Listar_Bancos();
        List<ENT_Banco> Listar_Banco(int p_id_banco);
    }
}
