using System.Data;
using DSWI_T1_6.Data;
using DSWI_T1_6.Dtos;
using DSWI_T1_6.Models;
using Microsoft.Data.SqlClient;

namespace DSWI_T1_6.Repositories
{
    public class InventarioRepository : IInventarioRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly string _cadena;

        public InventarioRepository(AppDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _cadena = configuration.GetConnectionString("DefaultConnection")!;
        }

        public async Task<IEnumerable<Inventario>> GetInventarios()
        {
            var lista = new List<Inventario>();

            using (var cn = new SqlConnection(_cadena))
            {
                await cn.OpenAsync();
                var cmd = new SqlCommand("usp_listar_inventario", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = await cmd.ExecuteReaderAsync())
                {
                    while (await dr.ReadAsync())
                    {
                        lista.Add(new Inventario
                        {
                            InventarioId = (int)dr["InventarioID"],
                            FechaIngreso = dr["FechaIngreso"] is DateTime fecha ? DateOnly.FromDateTime(fecha) : null,
                            Cantidad = dr["Cantidad"] as int?,
                            Ubicacion = dr["Ubicacion"] as string,
                            Estado = dr["Estado"] as string,
                            ProductoId = dr["ProductoID"] as int?
                        });
                    }
                }
            }

            return lista;
        }

        public async Task<Inventario?> GetInventarioById(int id)
        {
            return await _dbContext.Inventarios.FindAsync(id);
        }

        public async Task SaveInventario(RegisterInventarioDto dto)
        {
            using (var cn = new SqlConnection(_cadena))
            {
                await cn.OpenAsync();
                var cmd = new SqlCommand("usp_insertar_inventario", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FechaIngreso", dto.FechaIngreso);
                cmd.Parameters.AddWithValue("@Cantidad", dto.Cantidad);
                cmd.Parameters.AddWithValue("@Ubicacion", dto.Ubicacion);
                cmd.Parameters.AddWithValue("@Estado", dto.Estado);
                cmd.Parameters.AddWithValue("@ProductoID", dto.ProductoId);
                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task UpdateInventario(RegisterInventarioDto dto)
        {
            using (var cn = new SqlConnection(_cadena))
            {
                await cn.OpenAsync();
                var cmd = new SqlCommand("usp_actualizar_inventario", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@InventarioID", dto.InventarioId);
                cmd.Parameters.AddWithValue("@FechaIngreso", dto.FechaIngreso);
                cmd.Parameters.AddWithValue("@Cantidad", dto.Cantidad);
                cmd.Parameters.AddWithValue("@Ubicacion", dto.Ubicacion);
                cmd.Parameters.AddWithValue("@Estado", dto.Estado);
                cmd.Parameters.AddWithValue("@ProductoID", dto.ProductoId);
                await cmd.ExecuteNonQueryAsync();
            }
        }
    }
}
