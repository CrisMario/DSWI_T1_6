using DSWI_T1_6.Dtos;
using DSWI_T1_6.Models;

namespace DSWI_T1_6.Services
{
    public interface IProductoService
    {
        Task<IEnumerable<Producto>> GetProductos();
        Task<RegisterProductoDto?> GetProductoById(int id);
        Task SaveProducto(RegisterProductoDto dto);
        Task UpdateProducto(RegisterProductoDto dto);
    }
}
