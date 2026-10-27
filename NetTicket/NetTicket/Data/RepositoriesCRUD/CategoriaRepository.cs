using MySqlConnector;
using NetTicket.Data.Connection;
using NetTicket.Models;
using System.Linq.Expressions;
using System.Net.Http.Headers;


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
                Console.WriteLine("CategoriaRepository Create" + ex.Message);
            }
            return null;
        }


        public bool Update(int id, string nombre)
        {
            try
            {
                using MySqlConnection cn = _conexion.ObtenerConexion();
                cn.Open();

                using MySqlCommand cmd = new MySqlCommand("CategoriaRepository_Update", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("p_Id", id);
                cmd.Parameters.AddWithValue("p_Nombre", nombre);

                int registros = cmd.ExecuteNonQuery();
                return registros > 0;


            }catch(Exception ex)
            {
                Console.WriteLine("CategoriaRepository Update" + ex.Message);
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                using MySqlConnection cn = _conexion.ObtenerConexion();
                cn.Open();

                using MySqlCommand cmd = new MySqlCommand("CategoriaRepository_Delete", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("p_Id", id);


                int registros = cmd.ExecuteNonQuery();
                return registros > 0;

            }catch(Exception ex)
            {
                Console.WriteLine("CategoriaRepository Delete" + ex.Message);
                return false;
            }
        }
    }
}
