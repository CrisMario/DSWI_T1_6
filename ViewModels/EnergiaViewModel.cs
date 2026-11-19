using System.ComponentModel.DataAnnotations;

namespace DSWI_T1_6.ViewModels
{
    public class EnergiaViewModel
    {
        [Required(ErrorMessage = "Ingrese los kWh consumidos")]
        [Range(0, 100000, ErrorMessage = "Los kWh deben estar entre 0 y 100000")]
        public decimal Kwh { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Impuesto { get; set; }
        public decimal Total { get; set; }
    }
}
