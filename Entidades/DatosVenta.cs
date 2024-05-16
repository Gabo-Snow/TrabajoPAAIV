using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DatosVenta
    {
        public int CodigoProducto { get; set; }
        public string NombreProducto { get; set; }
        public float PrecioUnitarioUf { get; set; } 
        public int UnidadesVenta { get; set; }
        public DateTime Fecha { get; set; }
    }
}
