using MySqlConnector;
using NetTicket.Models;
using NetTicket.Data.Connection;
using System.Security.Cryptography;

namespace NetTicket.Data.RepositoriesCRUD
{
    public class ComentarioRepository
    {
        private readonly Conexion _conexion;

        public ComentarioRepository(Conexion conexion)
        {
            _conexion = conexion;
        }

        public async Task<int> CountAllComentarios()
        {
            try
            {
                await using MySqlConnection cn = _conexion.ObtenerConexion();
                await cn.OpenAsync();

                await using MySqlCommand cmd = new MySqlCommand("CountAllComentarios", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                var countCom = Convert.ToInt32(await cmd.ExecuteScalarAsync());

                return countCom;

            }
            catch(Exception ex)
            {
                Console.WriteLine("ComentarioRepository CountAllComentarios: " + ex.Message);
                throw;
            }
        }

        public async Task<List<Comentario>> ObtenerTodos()
        {
            List<Comentario> comentarios = new List<Comentario>();

            try
            {
                await using MySqlConnection cn = _conexion.ObtenerConexion();
                await cn.OpenAsync();

                await using MySqlCommand cmd = new MySqlCommand("ComentarioRepository", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                await using MySqlDataReader reader = await cmd.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    comentarios.Add(new Comentario
                    {
                        Id = reader.GetInt32("Id"),
                        TicketId = reader.GetInt32("TicketId"),
                        UsuarioId = reader.GetInt32("UsuarioId"),
                        Texto = reader.GetString("Texto"),
                        Fecha = reader.GetDateTime("Fecha")
                    });
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("ComentarioRepository ObtenerTodos: " + ex.Message);
                throw;
            }
            return comentarios;
        }


        public async Task<Comentario?> ObtenerPorId(int id)
        {
            try
            {
                await using MySqlConnection cn = _conexion.ObtenerConexion();
                await cn.OpenAsync();

                await using MySqlCommand cmd = new MySqlCommand("ComentariosRepositoryId", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("i", id);

                await using MySqlDataReader reader = await cmd.ExecuteReaderAsync();

                if (await reader.ReadAsync())
                {
                    return new Comentario
                    {
                        Id = reader.GetInt32("Id"),
                        TicketId = reader.GetInt32("TicketId"),
                        UsuarioId = reader.GetInt32("UsuarioId"),
                        Texto = reader.GetString("Texto"),
                        Fecha = reader.GetDateTime("Fecha")
                    };
                }
                
            }
            catch(Exception ex)
            {
                Console.WriteLine("ComentarioRepository ObtenerPorId: " + ex.Message);
                throw;
            }
            return null;
        }

        public async Task<Comentario?> Create(int ticketId, int usuarioId, string texto)
        {
            try
            {
                await using MySqlConnection cn = _conexion.ObtenerConexion();
                await cn.OpenAsync();

                await using MySqlCommand cmd = new MySqlCommand("ComentarioRepository_Create", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("TicketId", ticketId);
                cmd.Parameters.AddWithValue("UsuarioId", usuarioId);
                cmd.Parameters.AddWithValue("Texto", texto);

                var id = Convert.ToInt32(await cmd.ExecuteScalarAsync());

                return new Comentario
                {
                    Id = id,
                    TicketId = ticketId,
                    UsuarioId = usuarioId,
                    Texto = texto,
                    Fecha = DateTime.Now
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine("ComentarioRepository Create: " + ex.Message);
                throw;
            }
        }

        public async Task<bool> Update(int id, string texto)
        {
            try
            {
                await using MySqlConnection cn = _conexion.ObtenerConexion();
                await cn.OpenAsync();

                await using MySqlCommand cmd = new MySqlCommand("ComentarioRepository_Update", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("p_Id", id);
                cmd.Parameters.AddWithValue("p_Texto", texto);

                int registros = await cmd.ExecuteNonQueryAsync();
                return registros > 0;
            }
            catch(Exception ex)
            {
                Console.WriteLine("ComentarioRepository Update: " + ex.Message);
                throw;
            }
        }
    }
}
