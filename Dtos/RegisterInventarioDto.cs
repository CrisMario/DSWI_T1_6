using System.ComponentModel.DataAnnotations;

namespace DSWI_T1_6.Dtos
{
    public class RegisterInventarioDto
    {
        public int InventarioId { get; set; }

        [Required(ErrorMessage = "Ingrese la fecha de ingreso")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaIngreso { get; set; }

        [Required(ErrorMessage = "Ingrese la cantidad")]
        [Range(0, 100000, ErrorMessage = "La cantidad no es válida")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "Ingrese la ubicación")]
        [StringLength(100)]
        public string? Ubicacion { get; set; }

        [Required(ErrorMessage = "Ingrese el estado")]
        [StringLength(50)]
        public string? Estado { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Seleccione un producto")]
        public int ProductoId { get; set; }
    }
}
