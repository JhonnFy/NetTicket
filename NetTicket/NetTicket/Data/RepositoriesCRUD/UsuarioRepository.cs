using MySqlConnector;
using NetTicket.Data.Connection;
using NetTicket.Models;
using NetTicket.Services.DbRules;

namespace NetTicket.Data.RepositoriesCRUD
{
    public class UsuarioRepository
    {
        private readonly Conexion _conexion;

        public UsuarioRepository(Conexion conexion)
        {
            _conexion = conexion;
        }

        public async Task<int> CountAllUsuarios()
        {
            try
            {
                await using MySqlConnection cn = _conexion.ObtenerConexion();
                await cn.OpenAsync();

                await using MySqlCommand cmd = new MySqlCommand("CountAllUsuarios", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                var countUsr = Convert.ToInt32(await cmd.ExecuteScalarAsync());
                return countUsr;
            }
            catch(Exception ex)
            {
                Console.WriteLine("UsuarioRepository CountAllUsuarios: " + ex.Message);
                throw;
            }
        }


        public async Task<List<Usuario>> ObtenerTodos()
        {
            List<Usuario> usuarios = new List<Usuario>();

            try
            {
                await using MySqlConnection cn = _conexion.ObtenerConexion();
                await cn.OpenAsync();

                await using MySqlCommand cmd = new MySqlCommand("UsuarioRepository", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                await using MySqlDataReader reader = await cmd.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    usuarios.Add(new Usuario
                    {
                        Id = reader.GetInt32("Id"),
                        Nombre = reader.GetString("Nombre"),
                        Email = reader.GetString("Email"),
                        Area = reader.GetString("Area")
                    });
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("UsuarioRepository ObtenerTodos: " + ex.Message);
                throw;
            }
            return usuarios;
        }

        public async Task<Usuario?> ObtenerPorId(int id)
        {
            try
            {
                await using MySqlConnection cn = _conexion.ObtenerConexion();
                await cn.OpenAsync();

                await using MySqlCommand cmd = new MySqlCommand("UsuarioRepositoryId", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("i", id);

                await using MySqlDataReader reader = await cmd.ExecuteReaderAsync();

                if (await reader.ReadAsync())
                {
                    return new Usuario
                    {
                        Id = reader.GetInt32("Id"),
                        Nombre = reader.GetString("Nombre"),
                        Email = reader.GetString("Email"),
                        Area = reader.GetString("Area")
                    };
                }   
            }
            catch(Exception ex)
            {
                Console.WriteLine("UsuarioRepository ObtenerPorId: " + ex.Message);
                throw;
            }
            return null;
        }


        public async Task<Usuario?> Create(string nombre, string email, string area)
        {
            try
            {
                await using MySqlConnection cn = _conexion.ObtenerConexion();
                await cn.OpenAsync();

                await using MySqlCommand cmd = new MySqlCommand("UsuarioRepository_Create", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Nombre", nombre);
                cmd.Parameters.AddWithValue("Email", email);
                cmd.Parameters.AddWithValue("Area", area);

                var id = Convert.ToInt32(await cmd.ExecuteScalarAsync());

                return new Usuario
                {
                    Id = id,
                    Nombre = nombre,
                    Email = email,
                    Area = area
                };
            }catch(Exception ex)
            {
                Console.WriteLine($"UsuarioRepository Create: " + ex.Message);
                throw;
            }
        }

        public async Task<bool> Update(int id, string nombre,string email,string area)
        {
            try
            {
                await using MySqlConnection cn = _conexion.ObtenerConexion();
                await cn.OpenAsync();

                await using MySqlCommand cmd = new MySqlCommand("UsuarioRepository_Update", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("p_Id", id);
                cmd.Parameters.AddWithValue("p_Nombre", nombre);
                cmd.Parameters.AddWithValue("p_Email",email);
                cmd.Parameters.AddWithValue("p_Area",area);

                int registros = await cmd.ExecuteNonQueryAsync();
                return registros > 0;

            }
            catch(Exception ex)
            {
                Console.WriteLine("UsuarioRepository Update: " + ex.Message);
                throw;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                await using MySqlConnection cn = _conexion.ObtenerConexion();
                await cn.OpenAsync();

                await using MySqlCommand cmd = new MySqlCommand("UsuarioRepository_Delete", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("p_Id", id);

                int registros = await cmd.ExecuteNonQueryAsync();
                return registros > 0;

            }catch(Exception ex)
            {
                Console.WriteLine("UsuarioRepository Delete: " + ex.Message);
                throw;
            }
        }

        public async Task<bool> ExisteEmail (string email)
        {
            try
            {
                await using MySqlConnection cn = _conexion.ObtenerConexion();
                await cn.OpenAsync();

                await using MySqlCommand cmd = new MySqlCommand("ExisteEmail", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_Email", email);

                var countEmail = Convert.ToInt32(await cmd.ExecuteScalarAsync());
                return countEmail > 0;

            }catch(Exception ex)
            {
                Console.WriteLine("UsuarioRepository ExisteEmail: " + ex.Message);
                throw;
            }
        }

    }
}

