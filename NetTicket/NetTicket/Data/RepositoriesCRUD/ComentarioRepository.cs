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

        public List<Comentario> ObtenerTodos()
        {
            List<Comentario> comentarios = new List<Comentario>();

            try
            {
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
            }
            catch(Exception ex)
            {
                Console.WriteLine("ComentarioRepository ObtenerTodos" + ex.ToString());
            }
            return comentarios;
        }


        public Comentario? ObtenerPorId(int id)
        {
            try
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
                
            }
            catch(Exception ex)
            {
                Console.WriteLine("ComentarioRepository ObtenerPorId" + ex.ToString());
            }
            return null;
        }

        public Comentario? Create(int TicketId, int UsuarioId, string Texto)
        {
            try
            {
                using MySqlConnection cn = _conexion.ObtenerConexion();
                cn.Open();

                using MySqlCommand cmd = new MySqlCommand("ComentarioRepository_Create", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("TicketId", TicketId);
                cmd.Parameters.AddWithValue("UsuarioId", UsuarioId);
                cmd.Parameters.AddWithValue("Texto", Texto);

                var id = Convert.ToInt32(cmd.ExecuteScalar());

                return new Comentario
                {
                    Id = id,
                    TicketId = TicketId,
                    UsuarioId = UsuarioId,
                    Texto = Texto,
                    Fecha = DateTime.Now
                };
            }catch(Exception ex)
            {
                Console.WriteLine("ComentarioRepository_Create " + ex.ToString());
            }
            return null;
        }

        public Comentario? Update(string texto)
        {
            try
            {

            }catch(Exception ex)
            {
                Console.WriteLine("ComentarioRepository Update " + ex.ToString());
            }
            return null;
        }
        


    }
}
