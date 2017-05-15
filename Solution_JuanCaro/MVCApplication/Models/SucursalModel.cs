using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCApplication.Models
{
    public class SucursalModel
    {
        public int Id_Sucursal { get; set; }
        public string Nombre_Sucursal { get; set; }
        public string Direccion_Sucursal { get; set; }
        public DateTime Fecha_Registro { get; set; }
        public int Estado { get; set; }
        public string Nombre_Banco { get; set; }
    }
}