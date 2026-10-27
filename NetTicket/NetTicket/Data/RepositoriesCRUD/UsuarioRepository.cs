using MySqlConnector;
using NetTicket.Data.Connection;
using NetTicket.Models;
using NetTicket.Services.DbRules;

namespace NetTicket.Data.RepositoriesCRUD
{
    public class UsuarioRepository
    {
        private readonly Conexion _conexion;

        public UsuarioRepository(Conexion conexion)
        {
            _conexion = conexion;
        }

        public List<Usuario> ObtenerTodos()
        {
            List<Usuario> usuarios = new List<Usuario>();

            try
            {
                using MySqlConnection cn = _conexion.ObtenerConexion();
                cn.Open();

                using MySqlCommand cmd = new MySqlCommand("UsuarioRepository", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                using MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    usuarios.Add(new Usuario
                    {
                        Id = reader.GetInt32("Id"),
                        Nombre = reader.GetString("Nombre"),
                        Email = reader.GetString("Email"),
                        Area = reader.GetString("Area")
                    });
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("UsuarioRepository ObtenerTodos" + ex.Message);
            }
            return usuarios;
        }

        public Usuario? ObtenerPorId(int id)
        {
            try
            {
                using MySqlConnection cn = _conexion.ObtenerConexion();
                cn.Open();

                using MySqlCommand cmd = new MySqlCommand("UsuarioRepositoryId", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("i", id);

                using MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new Usuario
                    {
                        Id = reader.GetInt32("Id"),
                        Nombre = reader.GetString("Nombre"),
                        Email = reader.GetString("Email"),
                        Area = reader.GetString("Area")
                    };
                }   
            }
            catch(Exception ex)
            {
                Console.WriteLine("UsuarioRepository ObtenerPorId" + ex.Message);
            }
            return null;
        }


        public Usuario? Create(string nombre, string email, string area)
        {
            try
            {
                using MySqlConnection cn = _conexion.ObtenerConexion();
                cn.Open();

                using MySqlCommand cmd = new MySqlCommand("UsuarioRepository_Create", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Nombre", nombre);
                cmd.Parameters.AddWithValue("Email", email);
                cmd.Parameters.AddWithValue("Area", area);

                var id = Convert.ToInt32(cmd.ExecuteScalar());

                return new Usuario
                {
                    Id = id,
                    Nombre = nombre,
                    Email = email,
                    Area = area
                };
            }catch(Exception ex)
            {
                Console.WriteLine($"UsuarioRepository Create" + ex.Message);
            }
            return null;
        }

        public bool Update(int id, string nombre,string email,string area)
        {
            try
            {
                using MySqlConnection cn = _conexion.ObtenerConexion();
                cn.Open();

                using MySqlCommand cmd = new MySqlCommand("UsuarioRepository_Update", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("p_Id", id);
                cmd.Parameters.AddWithValue("p_Nombre", nombre);
                cmd.Parameters.AddWithValue("p_Email",email);
                cmd.Parameters.AddWithValue("p_Area",area);

                int registros = cmd.ExecuteNonQuery();
                return registros > 0;

            }
            catch(Exception ex)
            {
                Console.WriteLine("UsuarioRepository Update" + ex.Message);
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                using MySqlConnection cn = _conexion.ObtenerConexion();
                cn.Open();

                using MySqlCommand cmd = new MySqlCommand("UsuarioRepository_Delete", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("p_Id", id);

                int registros = cmd.ExecuteNonQuery();
                return registros > 0;

            }catch(Exception ex)
            {
                Console.WriteLine("UsuarioRepository Delete" + ex.Message);
                return false;
            }
        }
    }
}
