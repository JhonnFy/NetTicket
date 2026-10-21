using MySqlConnector;
using NetTicket.Data.Connection;
using NetTicket.Models;


namespace NetTicket.Data.RepositoriesCRUD
{
    public class Categoria
    {
        private readonly Conexion _conexion;

        public Categoria(Conexion conexion)
        {
            _conexion = conexion;
        }

        public List<Models.Categoria> ObtenerTodos()
        {
            List<Models.Categoria> categorias = new List<Models.Categoria>();


            using MySqlConnection cn = _conexion.ObtenerConexion();
            cn.Open();

            string query = "SELECT Id, Nombre FROM categorias;";

            using MySqlCommand cmd = new MySqlCommand(query, cn);
            using MySqlDataReader reader = cmd.ExecuteReader();


            while (reader.Read())
            {
                categorias.Add(new Models.Categoria
                {
                    Id = reader.GetInt32("Id"),
                    Nombre = reader.GetString("Nombre")
                });
            }

            return categorias;
        }

    }
}
