using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACCESO_DATOS
{
    public class Conexion
    {
        public static string CNX
        {
            get
            {
                return "Data Source=FU44211032-EXT\\SERVER_002; database=BD_EXAMEN; User ID=sa; Password=Idiota87;integrated security=False;";
                //FU44211032-EXT\SERVER_001
                //FU44211032-EXT\SERVER_002 - Idiota87
            }
        }
    }
}
