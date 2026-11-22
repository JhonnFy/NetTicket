using MySqlConnector;
using NetTicket.Data.Connection;
using NetTicket.Models;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;

namespace NetTicket.Data.RepositoriesCRUD
{
    public class CategoriaRepository
    {
        private readonly Conexion _conexion;

        public CategoriaRepository(Conexion conexion)
        {
            _conexion = conexion;
        }

        public async Task<int> CountAllCategorias()
        {
            try
            {
                await using MySqlConnection cn = _conexion.ObtenerConexion();
                await cn.OpenAsync();

                await using MySqlCommand cmd = new MySqlCommand("CountAllCategorias", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                var countCat = Convert.ToInt32(await cmd.ExecuteScalarAsync());

                return countCat;
            }
            catch (Exception ex)
            {
                Console.WriteLine("CategoriaRepository CountAllCategorias: " + ex.Message);
                throw;
            }
        }

        public async Task<List<Categoria>> ObtenerTodos()
        {
            List<Categoria> categorias = new List<Categoria>();

            try
            {
                await using MySqlConnection cn = _conexion.ObtenerConexion();
                await cn.OpenAsync();

                await using MySqlCommand cmd = new MySqlCommand("CategoriaRepository", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                await using MySqlDataReader reader = await cmd.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    categorias.Add(new Categoria
                    {
                        Id = reader.GetInt32("Id"),
                        Nombre = reader.GetString("Nombre")
                    });
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("CategoriaRepository ObtenerTodos: " + ex.Message);
                throw;
            }
            return categorias;
        }

        public async Task<Categoria?> ObtenerPorId(int id)
        {

            try
            {
                await using MySqlConnection cn = _conexion.ObtenerConexion();
                await cn.OpenAsync();

                await using MySqlCommand cmd = new MySqlCommand("CategoriaRepositoryId", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("i", id);

                await using MySqlDataReader reader = await cmd.ExecuteReaderAsync();

                if (await reader.ReadAsync())
                {
                    return new Categoria
                    {
                        Id = reader.GetInt32("Id"),
                        Nombre = reader.GetString("Nombre")
                    };
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("CategoriaRepository ObtenerPorId: " + ex.Message);
                throw;
            }
            
            return null;
        }

        public async Task<Categoria?> Create(string nombre)
        {
            try
            {
                await using MySqlConnection cn = _conexion.ObtenerConexion();
                await cn.OpenAsync();

                await using MySqlCommand cmd = new MySqlCommand("CategoriaRepository_Create", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Nombre", nombre);

                var id = Convert.ToInt32(await cmd.ExecuteScalarAsync());

                return new Categoria
                {
                    Id = id,
                    Nombre = nombre
                };

            }
            catch(Exception ex)
            {
                Console.WriteLine("CategoriaRepository Create: " + ex.Message);
                throw;
            }
        }

        public async Task<bool> Update(int id, string nombre)
        {
            try
            {
                await using MySqlConnection cn = _conexion.ObtenerConexion();
                await cn.OpenAsync();

                await using MySqlCommand cmd = new MySqlCommand("CategoriaRepository_Update", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("p_Id", id);
                cmd.Parameters.AddWithValue("p_Nombre", nombre);

                int registros = await cmd.ExecuteNonQueryAsync();
                return registros > 0;


            }catch(Exception ex)
            {
                Console.WriteLine("CategoriaRepository Update: " + ex.Message);
                throw;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                await using MySqlConnection cn = _conexion.ObtenerConexion();
                await cn.OpenAsync();

                await using MySqlCommand cmd = new MySqlCommand("CategoriaRepository_Delete", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_Id", id);

                int registros = await cmd.ExecuteNonQueryAsync();
                return registros > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("CategoriaRepository Delete: " + ex.Message);
                throw;
            }
        }
    }
}
