using MySqlConnector;
using NetTicket.Data.Connection;
using NetTicket.Models;
using System.Linq.Expressions;


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

            try
            {
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
            }
            catch(Exception ex)
            {
                Console.WriteLine("CategoriaRepository ObtenerTodos" + ex.Message);
            }

            return categorias;

        }

        public Categoria? ObtenerPorId(int id)
        {

            try
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
            }
            catch(Exception ex)
            {
                Console.WriteLine("CategoriaRepository ObtenerPorId" + ex.Message);
            }
            
            return null;
        }

        public Categoria? Create(string nombre)
        {
            try
            {
                using MySqlConnection cn = _conexion.ObtenerConexion();
                cn.Open();

                using MySqlCommand cmd = new MySqlCommand("CategoriaRepository_Create", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Nombre", nombre);

                var id = Convert.ToInt32(cmd.ExecuteScalar());

                return new Categoria
                {
                    Id = id,
                    Nombre = nombre
                };

            }
            catch(Exception ex)
            {
                Console.WriteLine("CategoriaRepository Create" + ex.ToString());
            }
            return null;
        }

    }
}
