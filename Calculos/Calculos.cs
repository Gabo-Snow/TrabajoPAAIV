using System.Runtime.InteropServices;

namespace Calculos
{
    public class Calculos
    {

        public float PrecioUnitarioUf { get; set; }
        public int UnidadesVenta { get; set; }
        public float ValorUfDia { get; set; }

        public float TotalVentaNetoUf(float PrecioUnitarioUf, int UnidadesVenta)
        {
            return PrecioUnitarioUf * UnidadesVenta;
        }

        public float TotalVentaNetoPesos(float TotalVentaNetoUf, float ValorUfDia)
        {
            return TotalVentaNetoUf * ValorUfDia;
        }

        public float MontoIva(float TotalVentaNetoPesos, float Iva)
        {
            return TotalVentaNetoPesos * Iva;
        }

        public float TotalVentaLiquido(float TotalVentaNetoPesos, float MontoIva)
        {
            return TotalVentaNetoPesos + MontoIva;
        }

    }
}
