using MySqlConnector;
using NetTicket.Data.Connection;
using NetTicket.Models;

namespace NetTicket.Data.RepositoriesCRUD
{
    public class EstadoRepository
    {
        private readonly Conexion _conexion;

        public EstadoRepository(Conexion conexion)
        {
            _conexion = conexion;
        }

        public List<Estado> ObtenerTodos()
        {
            List<Estado> estados = new List<Estado>();

            using MySqlConnection cn = _conexion.ObtenerConexion();
            cn.Open();

            using MySqlCommand cmd = new MySqlCommand("EstadosRepository", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            using MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                estados.Add(new Estado
                {
                    Id = reader.GetInt32("Id"),
                    Nombre = reader.GetString("Nombre")
                });
            }

            return estados;
        }
    }
}
