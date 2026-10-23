using MySqlConnector;
using NetTicket.Models;
using NetTicket.Data.Connection;


namespace NetTicket.Data.RepositoriesCRUD
{
    public class ComentarioRepository
    {

        private readonly Conexion _conexion;

        public ComentarioRepository(Conexion conexion)
        {
            _conexion = conexion;
        }

        public List<Comentario> ObtenerTodos()
        {
            List<Comentario> comentarios = new List<Comentario>();

            using MySqlConnection cn = _conexion.ObtenerConexion();
            cn.Open();

            using MySqlCommand cmd = new MySqlCommand("ComentarioRepository", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            using MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
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

            return comentarios;
        }


        public Comentario? ObtenerPorId(int id)
        {
            using MySqlConnection cn = _conexion.ObtenerConexion();
            cn.Open();

            using MySqlCommand cmd = new MySqlCommand("ComentariosRepositoryId", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("i", id);

            using MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
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
            return null;
        }
    }
}
