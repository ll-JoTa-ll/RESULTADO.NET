using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACCESO_DATOS.Interface
{
    public interface IADO_Factory
    {
        IADO_Banco ADO_Banco { get; }
        IADO_Sucursal ADO_Sucursal { get; }
        IADO_Orden_Pago ADO_Orden_Pago { get; }
    }
}
