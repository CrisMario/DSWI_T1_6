using DSWI_T1_6.Dtos;
using DSWI_T1_6.Models;
using DSWI_T1_6.Repositories;

namespace DSWI_T1_6.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _productoRepository;

        public ProductoService(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public async Task<IEnumerable<Producto>> GetProductos()
        {
            return await _productoRepository.GetProductos();
        }

        public async Task<RegisterProductoDto?> GetProductoById(int id)
        {
            var producto = await _productoRepository.GetProductoById(id);

            if (producto == null)
            {
                return null;
            }

            return new RegisterProductoDto
            {
                ProductoId = producto.ProductoId,
                Nombre = producto.Nombre,
                Categoria = producto.Categoria
            };
        }

        public async Task SaveProducto(RegisterProductoDto dto)
        {
            await _productoRepository.SaveProducto(dto);
        }

        public async Task UpdateProducto(RegisterProductoDto dto)
        {
            await _productoRepository.UpdateProducto(dto);
        }
    }
}
