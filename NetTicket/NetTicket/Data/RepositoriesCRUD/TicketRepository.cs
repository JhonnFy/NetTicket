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
            return tickets;
        }

        public Ticket? ObtenerPorId(int id)
        {
            using MySqlConnection cn = _conexion.ObtenerConexion();
            cn.Open();


            using MySqlCommand cmd = new MySqlCommand("TicketRepositoryId", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("i", id);

            using MySqlDataReader reader = cmd.ExecuteReader();

            if(reader.Read())
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

    }
}
