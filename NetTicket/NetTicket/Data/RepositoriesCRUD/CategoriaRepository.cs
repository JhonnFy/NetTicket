using MySqlConnector;
using NetTicket.Data.Connection;
using NetTicket.Models;


namespace NetTicket.Data.RepositoriesCRUD
{
    public class CategoriaRepository
    {
        private readonly Conexion _conexion;

        public CategoriaRepository(Conexion conexion)
        {
            _conexion = conexion;
        }

        public List<Categoria> ObtenerTodos()
        {
            List<Categoria> categorias = new List<Categoria>();

            using MySqlConnection cn = _conexion.ObtenerConexion();
            cn.Open();

            using MySqlCommand cmd = new MySqlCommand("CategoriaRepository", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

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


        public Categoria? ObtenerPorId(int id)
        {

            using MySqlConnection cn = _conexion.ObtenerConexion();
            cn.Open();

            using MySqlCommand cmd = new MySqlCommand("CategoriaRepositoryId", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("i", id);

            using MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return new Categoria
                {
                    Id = reader.GetInt32("Id"),
                    Nombre = reader.GetString("Nombre")
                };
            }
            
            return null;
        }



    }
}
