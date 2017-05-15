using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ENTIDADES;

namespace WcfService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService_Sucursal" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IService_Sucursal
    {
        [OperationContract]
        void DoWork();

        [OperationContract]
        List<ENT_Sucursal> Listar_Sucursales_Banco(int p_id_banco);
    }
}
