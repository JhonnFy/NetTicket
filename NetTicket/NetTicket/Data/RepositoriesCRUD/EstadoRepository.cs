using MySqlConnector;
using NetTicket.Data.Connection;
using NetTicket.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices.Swift;

namespace NetTicket.Data.RepositoriesCRUD
{
    public class EstadoRepository
    {
        private readonly Conexion _conexion;

        public EstadoRepository(Conexion conexion)
        {
            _conexion = conexion;
        }

        public async Task<int> CountAllEstados()
        {
            try
            {
                await using MySqlConnection cn = _conexion.ObtenerConexion();
                await cn.OpenAsync();

                await using MySqlCommand cmd = new MySqlCommand("CountAllEstados", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                var countEst = Convert.ToInt32(await cmd.ExecuteScalarAsync());

                return countEst;

            }catch(Exception ex)
            {
                Console.WriteLine("EstadoRepository CountAllEstados: " + ex.Message);
                throw;
            }
        }


        public async Task<List<Estado>> ObtenerTodos()
        {
            List<Estado> estados = new List<Estado>();
            try
            {
                await using MySqlConnection cn = _conexion.ObtenerConexion();
                await cn.OpenAsync();

                await using MySqlCommand cmd = new MySqlCommand("EstadosRepository", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                await using MySqlDataReader reader = await cmd.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    estados.Add(new Estado
                    {
                        Id = reader.GetInt32("Id"),
                        Nombre = reader.GetString("Nombre")
                    });
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("EstadoRepository ObtenerTodos: " + ex.Message);
                throw;
            }
            return estados;
        }


        public async Task<Estado?> ObtenerPorId(int id)
        {
            try
            {
                await using MySqlConnection cn = _conexion.ObtenerConexion();
                await cn.OpenAsync();

                await using MySqlCommand cmd = new MySqlCommand("EstadosRepositoryId", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("i", id);

                await using MySqlDataReader reader = await cmd.ExecuteReaderAsync();

                if (await reader.ReadAsync())
                {
                    return new Estado
                    {
                        Id = reader.GetInt32("Id"),
                        Nombre = reader.GetString("Nombre")
                    };

                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("EstadoRepository ObtenerPorId: " + ex.Message);
                throw;
            }
            return null;
        }


        public async Task<Estado?> Create(string nombre)
        {
            try
            {
                await using MySqlConnection cn = _conexion.ObtenerConexion();
                await cn.OpenAsync();

                await using MySqlCommand cmd = new MySqlCommand("EstadoRepository_Create", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Nombre", nombre);

                var id = Convert.ToInt32(await cmd.ExecuteScalarAsync());

                return new Estado
                {
                    Id = id,
                    Nombre = nombre
                };

            }catch(Exception ex)
            {
                Console.WriteLine("EstadoRepository Create: " + ex.Message);
                throw;
            }
        }

        public async Task<bool> Update(int id, string nombre)
        {
            try
            {
                await using MySqlConnection cn = _conexion.ObtenerConexion();
                await cn.OpenAsync();

                await using MySqlCommand cmd = new MySqlCommand("EstadoRepository_Update", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("p_Id", id);
                cmd.Parameters.AddWithValue("p_Nombre", nombre);

                int registros = await cmd.ExecuteNonQueryAsync();
                return registros > 0;
            }
            catch(Exception ex)
            {
                Console.WriteLine("EstadoRepository Update: " + ex.Message);
                throw;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                await using MySqlConnection cn = _conexion.ObtenerConexion();
                await cn.OpenAsync();

                await using MySqlCommand cmd = new MySqlCommand("EstadoRepository_Delete", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_Id", id);

                int registros = await cmd.ExecuteNonQueryAsync();
                return registros > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("EstadoRepository Delete: " + ex.Message);
                throw;
            }
        }
    }
}
