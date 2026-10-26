using MySqlConnector;
using NetTicket.Data.Connection;
using NetTicket.Models;
using System.ComponentModel.DataAnnotations.Schema;

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
            try
            {
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
            }
            catch(Exception ex)
            {
                Console.WriteLine("EstadoRepository ObtenerTodos" + ex.ToString());
            }
            return estados;
        }


        public Estado? ObtenerPorId(int id)
        {
            using MySqlConnection cn = _conexion.ObtenerConexion();
            cn.Open();
            try
            {
                using MySqlCommand cmd = new MySqlCommand("EstadosRepositoryId", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("i", id);

                using MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new Estado
                    {
                        Id = reader.GetInt32("Id"),
                        Nombre = reader.GetString("Nombre")
                    };

                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("EstadoRepository ObtenerPorId" + ex.ToString());
            }
            return null;
        }


        public Estado? Create(string nombre)
        {
            try
            {
                using MySqlConnection cn = _conexion.ObtenerConexion();
                cn.Open();

                using MySqlCommand cmd = new MySqlCommand("EstadoRepository_Create", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Nombre", nombre);

                var id = Convert.ToInt32(cmd.ExecuteScalar());


                return new Estado
                {
                    Id = id,
                    Nombre = nombre
                };

            }catch(Exception ex)
            {
                Console.WriteLine("EstadoRepository Create" + ex.ToString());
            }
            return null;
        }

        public bool Update(int id, string nombre)
        {
            try
            {
                using MySqlConnection cn = _conexion.ObtenerConexion();
                cn.Open();

                using MySqlCommand cmd = new MySqlCommand("EstadoRepository_Update", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("p_Id", id);
                cmd.Parameters.AddWithValue("p_Nombre", nombre);

                int registros = cmd.ExecuteNonQuery();
                return registros > 0;
            }
            catch(Exception ex)
            {
                Console.WriteLine("EstadoRepository Update" + ex.ToString());
                return false;            
            }
        }

    }
}
