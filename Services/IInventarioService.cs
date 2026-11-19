using DSWI_T1_6.Dtos;
using DSWI_T1_6.Models;

namespace DSWI_T1_6.Services
{
    public interface IInventarioService
    {
        Task<IEnumerable<Inventario>> GetInventarios();
        Task<RegisterInventarioDto?> GetInventarioById(int id);
        Task SaveInventario(RegisterInventarioDto dto);
        Task UpdateInventario(RegisterInventarioDto dto);
    }
}
