using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCApplication.Models
{
    public class OrdenPagoModel
    {
        public int Id_Orden_Pago { get; set; }
        public decimal Monto { get; set; }
        public string Moneda { get; set; }
        public string Estado { get; set; }
        public DateTime Fecha_Pago { get; set; }
        public int Id_Sucursal { get; set; }
        public string Nombre_Sucursal { get; set; }
        public string Direccion_Sucursal { get; set; }
    }
}