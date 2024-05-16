using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVCVentas.Models
{
    public class DatosVentaModel
    {
        [Required]
        [Range(1, 2147483647)]
        [DisplayName("Código del Producto")]
        public int CodigoProducto { get; set; }
        [Required]
        [StringLength(100), MinLength(5, ErrorMessage = "El Mínimo de carácteres es 5")]
        public string NombreProducto { get; set; }
        [Required]
        [Range(0.5, 1000)]
        [DisplayName("Precio Unitario en UF")]
        public float PrecioUnitarioUf { get; set; }  
        [DisplayName("El Valor de la UF Hoy es:")]
        [Editable(false)]
        public float ValorUfdia { get; set; }
        [Required]
        [Range(1, 100)]
        [DisplayName("Unidades a Vender")]
        public int UnidadesVenta { get; set; }
        [Editable(false)]
        public DateTime Fecha { get; set; }
        public float TotalVentaNetoUf { get; set; }
        [DisplayName("Total Neto de la Venta en Pesos")]
        public float TotalVentaNetoPesos { get; set; }
        [DisplayName("IVA = 19%")]
        public float MontoIva { get; set; }
        [DisplayName("Total Líquido de la Venta")]
        public float TotalVentaLiquido { get; set; }
    }


}