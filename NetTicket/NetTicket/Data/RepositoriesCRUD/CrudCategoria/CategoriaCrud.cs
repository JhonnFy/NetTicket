using MySqlConnector;
using NetTicket.Data.Connection;
using NetTicket.Models;


namespace NetTicket.Data.RepositoriesCRUD.CrudCategoria
{
    public class CategoriaCrud
    {
        private readonly Conexion _conexion;

        public CategoriaCrud(Conexion conexion)
        {
            _conexion = conexion;
        }

        public List<Categoria> ObtenerTodos()
        {
            List<Categoria> categorias = new List<Categoria>();


            using MySqlConnection cn = _conexion.ObtenerConexion();
            cn.Open();

            string query = "SELECT Id, Nombre FROM categorias;";

            using MySqlCommand cmd = new MySqlCommand(query, cn);
            using MySqlDataReader reader = cmd.ExecuteReader();


            while (reader.Read())
            {
                categorias.Add(new Categoria
                {
                    Id = reader.GetInt32("Id"),
                    Nombre = reader.GetString("Nombre")
                });
            }

            return categorias;
        }

    }
}
