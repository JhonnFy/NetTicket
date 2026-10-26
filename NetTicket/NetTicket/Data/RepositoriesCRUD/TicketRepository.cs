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

        public List<Ticket> ObtenerTodos()
        {
            List<Ticket> tickets = new List<Ticket>();
            
            try
            {
                using MySqlConnection cn = _conexion.ObtenerConexion();
                cn.Open();

                using MySqlCommand cmd = new MySqlCommand("TicketRepository", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                using MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
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
            }
            return tickets;
        }

        public Ticket? ObtenerPorId(int id)
        {
            using MySqlConnection cn = _conexion.ObtenerConexion();
            cn.Open();
            try
            {
                using MySqlCommand cmd = new MySqlCommand("TicketRepositoryId", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("i", id);

                using MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
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
            }
            return null;
        }

        public Ticket? Create(string titulo, string descripcion, int usuarioId, int categoriaId, int estadoId)
        {
            try
            {
                using MySqlConnection cn = _conexion.ObtenerConexion();
                cn.Open();

                using MySqlCommand cmd = new MySqlCommand("TicketRepository_Create", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Titulo", titulo);
                cmd.Parameters.AddWithValue("Descripcion", descripcion);
                cmd.Parameters.AddWithValue("UsuarioId",usuarioId);
                cmd.Parameters.AddWithValue("CategoriaId",categoriaId);
                cmd.Parameters.AddWithValue("EstadoId", estadoId);

                var id = Convert.ToInt32(cmd.ExecuteScalar());

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
                Console.WriteLine("TicketRepository ObtenerPorId" + ex.Message);
            }
            return null;
        }

        public bool Update(int id, string titulo, string descripcion)
        {
            try
            {
                using MySqlConnection cn = _conexion.ObtenerConexion();
                cn.Open();

                using MySqlCommand cmd = new MySqlCommand("TicketRepository_Update", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("p_Id", id);
                cmd.Parameters.AddWithValue("p_Titulo", titulo);
                cmd.Parameters.AddWithValue("p_Descripcion", descripcion);

                int registros = cmd.ExecuteNonQuery();
                return registros > 0;


            }
            catch (Exception ex)
            {
                Console.WriteLine("TicketRepository Update" + ex.Message);
                return false;
            }
        }


    }
}
