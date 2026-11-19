using DSWI_T1_6.Dtos;
using DSWI_T1_6.Models;

namespace DSWI_T1_6.Repositories
{
    public interface IProductoRepository
    {
        Task<IEnumerable<Producto>> GetProductos();
        Task<Producto?> GetProductoById(int id);
        Task SaveProducto(RegisterProductoDto dto);
        Task UpdateProducto(RegisterProductoDto dto);
    }
}
