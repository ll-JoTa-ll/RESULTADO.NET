using ACCESO_DATOS.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACCESO_DATOS
{
    public class ADO_Factory : IADO_Factory
    {
        public IADO_Banco ADO_Banco { get { return new ADO_Banco(); } }
        public IADO_Sucursal ADO_Sucursal { get { return new ADO_Sucursal(); } }
        public IADO_Orden_Pago ADO_Orden_Pago { get { return new ADO_Orden_Pago(); } }
    }
}
