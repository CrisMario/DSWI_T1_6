using System.Data;
using DSWI_T1_6.Data;
using DSWI_T1_6.Dtos;
using DSWI_T1_6.Models;
using Microsoft.Data.SqlClient;

namespace DSWI_T1_6.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly string _cadena;

        public ProductoRepository(AppDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _cadena = configuration.GetConnectionString("DefaultConnection")!;
        }

        public async Task<IEnumerable<Producto>> GetProductos()
        {
            var lista = new List<Producto>();

            using (var cn = new SqlConnection(_cadena))
            {
                await cn.OpenAsync();
                var cmd = new SqlCommand("usp_listar_productos", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = await cmd.ExecuteReaderAsync())
                {
                    while (await dr.ReadAsync())
                    {
                        lista.Add(new Producto
                        {
                            ProductoId = (int)dr["ProductoID"],
                            Nombre = dr["Nombre"] as string,
                            Categoria = dr["Categoria"] as string
                        });
                    }
                }
            }

            return lista;
        }

        public async Task<Producto?> GetProductoById(int id)
        {
            return await _dbContext.Productos.FindAsync(id);
        }

        public async Task SaveProducto(RegisterProductoDto dto)
        {
            using (var cn = new SqlConnection(_cadena))
            {
                await cn.OpenAsync();
                var cmd = new SqlCommand("usp_insertar_producto", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", dto.Nombre);
                cmd.Parameters.AddWithValue("@Categoria", dto.Categoria);
                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task UpdateProducto(RegisterProductoDto dto)
        {
            using (var cn = new SqlConnection(_cadena))
            {
                await cn.OpenAsync();
                var cmd = new SqlCommand("usp_actualizar_producto", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductoID", dto.ProductoId);
                cmd.Parameters.AddWithValue("@Nombre", dto.Nombre);
                cmd.Parameters.AddWithValue("@Categoria", dto.Categoria);
                await cmd.ExecuteNonQueryAsync();
            }
        }
    }
}
