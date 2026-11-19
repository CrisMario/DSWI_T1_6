using System.ComponentModel.DataAnnotations;

namespace DSWI_T1_6.Dtos
{
    public class RegisterProductoDto
    {
        public int ProductoId { get; set; }

        [Required(ErrorMessage = "Ingrese el nombre")]
        [StringLength(100)]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "Ingrese la categoría")]
        [StringLength(50)]
        public string? Categoria { get; set; }
    }
}
