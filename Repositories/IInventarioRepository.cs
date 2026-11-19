using DSWI_T1_6.Dtos;
using DSWI_T1_6.Models;

namespace DSWI_T1_6.Repositories
{
    public interface IInventarioRepository
    {
        Task<IEnumerable<Inventario>> GetInventarios();
        Task<Inventario?> GetInventarioById(int id);
        Task SaveInventario(RegisterInventarioDto dto);
        Task UpdateInventario(RegisterInventarioDto dto);
    }
}
