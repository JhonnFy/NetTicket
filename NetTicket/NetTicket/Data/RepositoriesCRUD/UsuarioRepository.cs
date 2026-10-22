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

            using MySqlConnection cn = _conexion.ObtenerConexion();
            cn.Open();

            using MySqlCommand cmd = new MySqlCommand("UsuarioRepository", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            using MySqlDataReader reader = cmd.ExecuteReader();

            while(reader.Read())
            {
                usuarios.Add(new Usuario
                {
                    Id = reader.GetInt32("Id"),
                    Nombre = reader.GetString("Nombre"),
                    Email = reader.GetString("Email"),
                    Area = reader.GetString("Area")
                });
            }

            return usuarios;

        }
    }
}
