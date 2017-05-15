using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES
{
    public class ENT_Sucursal
    {
        public int Id_Sucursal { get; set; }
        public string Nombre_Sucursal { get; set; }
        public string Direccion_Sucursal { get; set; }
        public DateTime Fecha_Registro { get; set; }
        public int Estado { get; set; }


        public int Id_Banco { get; set; }
        public string Nombre_Banco { get; set; }
        public List<ENT_Banco> Lst_Bancos { get; set; }
    }
}