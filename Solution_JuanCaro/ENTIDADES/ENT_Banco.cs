using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES
{
    public class ENT_Banco
    {
        public int Id_Banco { get; set; }
        public string Nombre_Banco { get; set; }
        public string Direccion_Banco { get; set; }
        public DateTime Fecha_Registro { get; set; }
        public int Estado { get; set; }
    }
}
