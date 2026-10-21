using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTicket.Data.Connection
{
    public class Conexion
    {
        private readonly IConfiguration _iConfiguration;

        public Conexion(IConfiguration iConfiguration)
        {
            _iConfiguration = iConfiguration;
        }

        public MySqlConnection ObtenerConexion()
        {
            string cadena = _iConfiguration
                    .GetConnectionString("MySqlConnection");

            return new MySqlConnection(cadena);

        }

    }
}
