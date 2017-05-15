using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ENTIDADES;
using CONTROLADORA;

namespace WcfService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service_Sucursal" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service_Sucursal.svc o Service_Sucursal.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service_Sucursal : IService_Sucursal
    {
        public void DoWork()
        {
        }

        CTR_Sucursal o_ctr_sucursal = new CTR_Sucursal();

        public List<ENT_Sucursal> Listar_Sucursales_Banco(int p_id_banco)
        {
            return o_ctr_sucursal.Listar_Sucursales_Banco(p_id_banco);
        }
    }
}
