using ACCESO_DATOS.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACCESO_DATOS
{
    public class ADO_Factories
    {
        public static IADO_Factory GetFactory(string dataProvider)
        {
            switch (dataProvider.ToLower())
            {
                case "ado.net": return new ADO_Factory();

                default: return new ADO_Factory();
            }
        }
    }
}
