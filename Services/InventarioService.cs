using DSWI_T1_6.Dtos;
using DSWI_T1_6.Models;
using DSWI_T1_6.Repositories;

namespace DSWI_T1_6.Services
{
    public class InventarioService : IInventarioService
    {
        private readonly IInventarioRepository _inventarioRepository;

        public InventarioService(IInventarioRepository inventarioRepository)
        {
            _inventarioRepository = inventarioRepository;
        }

        public async Task<IEnumerable<Inventario>> GetInventarios()
        {
            return await _inventarioRepository.GetInventarios();
        }

        public async Task<RegisterInventarioDto?> GetInventarioById(int id)
        {
            var inventario = await _inventarioRepository.GetInventarioById(id);

            if (inventario == null)
            {
                return null;
            }

            return new RegisterInventarioDto
            {
                InventarioId = inventario.InventarioId,
                FechaIngreso = inventario.FechaIngreso.HasValue
                    ? inventario.FechaIngreso.Value.ToDateTime(TimeOnly.MinValue)
                    : DateTime.Today,
                Cantidad = inventario.Cantidad ?? 0,
                Ubicacion = inventario.Ubicacion,
                Estado = inventario.Estado,
                ProductoId = inventario.ProductoId ?? 0
            };
        }

        public async Task SaveInventario(RegisterInventarioDto dto)
        {
            await _inventarioRepository.SaveInventario(dto);
        }

        public async Task UpdateInventario(RegisterInventarioDto dto)
        {
            await _inventarioRepository.UpdateInventario(dto);
        }
    }
}
