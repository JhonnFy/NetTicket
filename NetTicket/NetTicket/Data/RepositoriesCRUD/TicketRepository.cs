using MySqlConnector;
using NetTicket.Data.Connection;
using NetTicket.Models;

namespace NetTicket.Data.RepositoriesCRUD
{
    public class TicketRepository
    {
        private readonly Conexion _conexion;

        public TicketRepository(Conexion conexion)
        {
            _conexion = conexion;
        }

        public async Task<int> CountAllTickets()
        {
            try
            {
                await using MySqlConnection cn = _conexion.ObtenerConexion();
                await cn.OpenAsync();

                await using MySqlCommand cmd = new MySqlCommand("CountAllTickets", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                var countTick = Convert.ToInt32(await cmd.ExecuteScalarAsync());

                return countTick;

            }catch(Exception ex)
            {
                Console.WriteLine("TicketRepository CountAllTickets: " + ex.Message);
                throw;
            }
        }


        public async Task<List<Ticket>> ObtenerTodos()
        {
            List<Ticket> tickets = new List<Ticket>();
            
            try
            {
                await using MySqlConnection cn = _conexion.ObtenerConexion();
                await cn.OpenAsync();

                await using MySqlCommand cmd = new MySqlCommand("TicketRepository", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                await using MySqlDataReader reader = await cmd.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    tickets.Add(new Ticket
                    {
                        Id = reader.GetInt32(0),
                        Titulo = reader.GetString(1),
                        Descripcion = reader.GetString(2),
                        UsuarioId = reader.GetInt32(3),
                        CategoriaId = reader.GetInt32(4),
                        EstadoId = reader.GetInt32(5),
                        FechaCreacion = reader.GetDateTime(6)
                    });
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("TicketRepository ObtenerTodos" + ex.Message);
                throw;
            }
            return tickets;
        }

        public async Task<Ticket?> ObtenerPorId(int id)
        {
            try
            {
                await using MySqlConnection cn = _conexion.ObtenerConexion();
                await cn.OpenAsync();

                await using MySqlCommand cmd = new MySqlCommand("TicketRepositoryId", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("i", id);

                await using MySqlDataReader reader = await cmd.ExecuteReaderAsync();

                if (await reader.ReadAsync())
                {
                    return new Ticket
                    {
                        Id = reader.GetInt32("Id"),
                        Titulo = reader.GetString("Titulo"),
                        Descripcion = reader.GetString("Descripcion"),
                        UsuarioId = reader.GetInt32("UsuarioId"),
                        CategoriaId = reader.GetInt32("CategoriaId"),
                        EstadoId = reader.GetInt32("EstadoId"),
                        FechaCreacion = DateTime.MinValue
                    };
                }
                return null;
            }
            catch(Exception ex)
            {
                Console.WriteLine("TicketRepository ObtenerPorId" + ex.Message);
                throw;
            }
        }

        public async Task<Ticket?> Create(string titulo, string descripcion, int usuarioId, int categoriaId, int estadoId)
        {
            try
            {
                await using MySqlConnection cn = _conexion.ObtenerConexion();
                await cn.OpenAsync();

                await using MySqlCommand cmd = new MySqlCommand("TicketRepository_Create", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Titulo", titulo);
                cmd.Parameters.AddWithValue("Descripcion", descripcion);
                cmd.Parameters.AddWithValue("UsuarioId",usuarioId);
                cmd.Parameters.AddWithValue("CategoriaId",categoriaId);
                cmd.Parameters.AddWithValue("EstadoId", estadoId);

                var id = Convert.ToInt32(await cmd.ExecuteScalarAsync());

                return new Ticket
                {
                    Id = id,
                    Titulo = titulo,
                    Descripcion = descripcion,
                    UsuarioId = usuarioId,
                    CategoriaId = categoriaId,
                    EstadoId = estadoId,
                    FechaCreacion = DateTime.Now
                };
                
            }catch(Exception ex)
            {
                Console.WriteLine("TicketRepository Create" + ex.Message);
                throw;
            }
        }

        public async Task<bool> Update(int id, string titulo, string descripcion)
        {
            try
            {
                await using MySqlConnection cn = _conexion.ObtenerConexion();
                await cn.OpenAsync();

                await using MySqlCommand cmd = new MySqlCommand("TicketRepository_Update", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("p_Id", id);
                cmd.Parameters.AddWithValue("p_Titulo", titulo);
                cmd.Parameters.AddWithValue("p_Descripcion", descripcion);

                int registros = await cmd.ExecuteNonQueryAsync();
                return registros > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("TicketRepository Update: " + ex.Message);
                throw;
            }
        }
    }
}
