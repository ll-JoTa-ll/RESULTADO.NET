using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES
{
    public class ENT_Orden_Pago
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
