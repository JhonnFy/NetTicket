using MySqlConnector;
using NetTicket.Data.Connection;
using NetTicket.Models;

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

        }

    }
}
